using System;
using System.Threading.Tasks;
using core.domain.data;
using core.domain.extensions;
using core.domain.model;
using core.domain.services;
using core.domain.services.accessControl;
using core.domain.services.log;

namespace core.domain.app.commands
{
  public class AuthorizeCommandHandler<TCommand, TRoot> : ICommandHandler<TCommand>
    where TCommand : Command
    where TRoot : AggregateRoot
  {
    private readonly AccessControlDomainService _accessControl;
    private readonly IAuthorizationContext _context;
    private readonly ILogAdapter _logger;
    private readonly IRepository<TRoot> _repository;
    private readonly ICommandHandler<TCommand> _handler;

    public AuthorizeCommandHandler(
      AccessControlDomainService accessControl,
      IAuthorizationContext context,
      ILogAdapter logAdapter,
      IRepository<TRoot> repository,
      ICommandHandler<TCommand> handler)
    {
      this._accessControl = accessControl.NotNull(nameof(accessControl));
      this._context = context.NotNull(nameof(context));
      this._logger = logAdapter.NotNull(nameof(logAdapter));
      this._repository = repository.NotNull(nameof(repository));
      this._handler = handler.NotNull(nameof(handler));
    }

    public CommandResult Handle(TCommand command)
    {
      this.Authorize(command);

      return this._handler.Handle(command);
    }

    public async Task<CommandResult> HandleAsync(TCommand command)
    {
      this.Authorize(command);

      return await this._handler.HandleAsync(command).ConfigureAwait(false);
    }

    private void Authorize(TCommand command)
    {
      if (command.ResourceName.IsNows())
      {
        throw new ArgumentException("No se especifica el recurso a validar.");
      }

      CommandBehavior? behavior = GetCommandBehavior();
      AuthorizationType? authType = GetAuthorizationType();

      IAggregateRoot item = null;
      if (behavior == CommandBehavior.Record)
      {
        item = this._repository?.FindOne(command.Id);
        item.Exists(item.GetType().Name, command.Id);
        command.Item = item;
      }

      bool hasAccess = this.HasAccess(command, authType);
      if (!hasAccess)
      {
        // Audit log
        this._logger.Warning("Unauthorized",
          command.ResourceName,
          this._context.Client,
          this._context.Username,
          this._context.UserRoles,
          command.Item);

        throw new UnauthorizedAccessException(command.ResourceName);
      }
    }

    private bool HasAccess(TCommand command, AuthorizationType? authType)
    {
      bool hasAccess = false;
      switch (authType)
      {
        case AuthorizationType.None:
          hasAccess = true;
          break;
        case AuthorizationType.Client:
          hasAccess = this._accessControl.HasAccess(
            command.ResourceName,
            this._context.Client);
          break;
        case AuthorizationType.User:
          hasAccess = this._accessControl.HasAccess(
            command.ResourceName,
            this._context.Username,
            this._context.UserRoles,
            command.Item);
          break;
      }

      return hasAccess;
    }

    private static AuthorizationType? GetAuthorizationType()
    {
      return typeof(TCommand).GetAttributeValue(
        (CommandConfigAttribute x) => x.Type);
    }

    private static CommandBehavior GetCommandBehavior()
    {
      CommandBehavior behavior = typeof(TCommand).GetAttributeValue(
        (CommandConfigAttribute x) => x.Behavior);

      return behavior == CommandBehavior.None
        ? CommandBehavior.Action : behavior;
    }
  }
}