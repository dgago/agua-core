using System;
using System.Threading.Tasks;
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
      _handler = handler ?? throw new ArgumentNullException(nameof(handler));
      _eventAdapter = eventAdapter
        ?? throw new ArgumentNullException(nameof(eventAdapter));
    }

    public CommandResult Handle(TCommand command)
    {
      CommandResult res = _handler.Handle(command);

      _eventAdapter.Publish(res.DomainEvents);

      return res;
    }

    public async Task<CommandResult> HandleAsync(TCommand command)
    {
      CommandResult res = await _handler.HandleAsync(command)
        .ConfigureAwait(false);

      _eventAdapter.Publish(res.DomainEvents);

      // TODO: should we return the events !!??!?!?!?
      return new CommandResult(res.Id, null, res.Message);
    }
  }
}