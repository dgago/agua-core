using System;
using System.Threading;
using System.Threading.Tasks;
using core.domain.data;
using core.domain.model;
using core.domain.services;
using core.domain.services.events;

namespace core.domain.app.commands
{
  public class EventPublisherCommandHandler<TCommand>
    : ICommandHandler<TCommand>
    where TCommand : Command
  {
    private readonly IEventAdapter _eventAdapter;

    private readonly ICommandHandler<TCommand> _handler;

    public EventPublisherCommandHandler(
      IEventAdapter eventAdapter,
      ICommandHandler<TCommand> handler)
    {
      _handler = handler;
      _eventAdapter = eventAdapter;
    }

    public CommandResult Handle(TCommand command,
      CancellationToken cancellationToken)
    {
      CommandResult res = _handler.Handle(command, cancellationToken);

      _eventAdapter.Publish(command.Item.DomainEvents);

      return res;
    }

    public async Task<CommandResult> HandleAsync(TCommand command,
      CancellationToken cancellationToken)
    {
      CommandResult res = await _handler.HandleAsync(command,
        cancellationToken).ConfigureAwait(false);

      _eventAdapter.Publish(command.Item.DomainEvents);

      return res;
    }
  }
}