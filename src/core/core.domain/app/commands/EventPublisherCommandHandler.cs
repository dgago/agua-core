using System.Threading.Tasks;
using core.domain.extensions;
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
      this._handler = handler.NotNull(nameof(handler));
      this._eventAdapter = eventAdapter.NotNull(nameof(eventAdapter));
    }

    public CommandResult Handle(TCommand command)
    {
      CommandResult res = this._handler.Handle(command);

      this._eventAdapter.Publish(res.DomainEvents);

      return res;
    }

    public async Task<CommandResult> HandleAsync(TCommand command)
    {
      CommandResult res = await this._handler.HandleAsync(command)
        .ConfigureAwait(false);

      this._eventAdapter.Publish(res.DomainEvents);

      // TODO: should we return the events !!??!?!?!?
      return new CommandResult(res.Id, null, res.Message);
    }
  }
}