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

      var commandBehavior = typeof(TCommand).GetAttributeValue(
        (CommandSettingsAttribute x) => x.Behavior);

      IAggregateRoot item = null;
      if (commandBehavior == CommandBehavior.ItemCommand)
      {
        item = _handler.Repository.FindOne(command.Id);
        item.Exists(item.GetType().Name, command.Id);
        command.Item = item;
      }

      bool hasAccess = command.Username.IsNows() ?
        _accessControl.HasAccess(
          command.ResourceName,
          command.Client)
        : _accessControl.HasAccess(
          command.ResourceName,
          command.Username,
          command.UserRoles,
          command.Item);

      if (!hasAccess)
      {
        // Audit log
        _logger.Warning("Unauthorized",
          command.ResourceName,
          command.Username,
          command.UserRoles,
          command.Item);

        throw new UnauthorizedAccessException(command.ResourceName);
      }
    }
  }
}