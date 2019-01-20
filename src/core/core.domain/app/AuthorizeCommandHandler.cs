using System;
using System.Threading.Tasks;
using core.domain.extensions;
using core.domain.model;
using core.domain.services;
using core.domain.services.accessControl;

namespace core.domain.app
{
  public class AuthorizeCommandHandler<TCommand> : ICommandHandler<TCommand>
      where TCommand : ItemCommand
  {
    private readonly ICommandHandler<TCommand> _handler;

    public AuthorizeCommandHandler(
      ICommandHandler<TCommand> handler)
    {
      _handler = handler;
    }

    public async Task<CommandResult> HandleAsync(TCommand command)
    {
      if (command.ResourceName.IsNows())
      {
        throw new ArgumentException("No se especifica el recurso a validar.");
      }

      IAggregateRoot item = null;
      if (_handler is IItemCommandHandler<TCommand> itemHandler)
      {
        item = itemHandler.Repository.FindOne(command.Id);
        item.Exists(item.GetType().Name, command.Id);
        command.Item = item;
      }

      bool hasAccess = AccessControlDomainService.HasAccess(
        command.ResourceName,
        command.Username,
        command.UserRoles,
        command.Item);

      if (!hasAccess)
      {
        // TODO: Audit log

        throw new UnauthorizedAccessException(command.ResourceName);
      }

      return await _handler.HandleAsync(command).ConfigureAwait(false);
    }
  }
}