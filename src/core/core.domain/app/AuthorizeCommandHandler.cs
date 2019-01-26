using System;
using System.Threading;
using System.Threading.Tasks;
using core.domain.data;
using core.domain.extensions;
using core.domain.model;
using core.domain.services;
using core.domain.services.accessControl;
using core.domain.services.log;

namespace core.domain.app
{
  public class AuthorizeCommandHandler<TCommand> : ICommandHandler<TCommand>
      where TCommand : Command
  {
    private readonly AccessControlDomainService _accessControl;
    private readonly ILogAdapter _logger;
    private readonly ICommandHandler<TCommand> _handler;

    public AuthorizeCommandHandler(
      AccessControlDomainService accessControl,
      ILogAdapter logAdapter,
      ICommandHandler<TCommand> handler)
    {
      _accessControl = accessControl;
      _logger = logAdapter;
      _handler = handler;
    }

    IRepository ICommandHandler<TCommand>.Repository => throw new NotImplementedException();

    public CommandResult Handle(TCommand command,
      CancellationToken cancellationToken)
    {
      Authorize(command);

      return _handler.Handle(command, cancellationToken);
    }

    public async Task<CommandResult> HandleAsync(TCommand command,
      CancellationToken cancellationToken)
    {
      Authorize(command);

      return await _handler.HandleAsync(command,
        cancellationToken).ConfigureAwait(false);
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
        item = _handler.Repository?.FindOne(command.Id);
        item.Exists(item.GetType().Name, command.Id);
        command.Item = item;
      }

      bool hasAccess = HasAccess(command, authType);
      if (!hasAccess)
      {
        // Audit log
        _logger.Warning("Unauthorized",
          command.Client,
          command.ResourceName,
          command.Username,
          command.UserRoles,
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
          hasAccess = _accessControl.HasAccess(
            command.ResourceName,
            command.Client);
          break;
        case AuthorizationType.User:
          hasAccess = _accessControl.HasAccess(
            command.ResourceName,
            command.Username,
            command.UserRoles,
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

      behavior = behavior == CommandBehavior.None
        ? CommandBehavior.Action : behavior;
      return behavior;
    }
  }
}