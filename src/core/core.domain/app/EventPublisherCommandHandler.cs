using System.Threading.Tasks;
using core.domain.services;

namespace core.domain.app
{
  public class EventPublisherCommandHandler<TCommand> : ICommandHandler<TCommand>
      where TCommand : ItemCommand
  {



    private readonly IEventAdapter _eventAdapter;

    private readonly ICommandHandler<TCommand> _handler;





    public EventPublisherCommandHandler(ICommandHandler<TCommand> handler,
        IEventAdapter eventAdapter)
    {
      _handler = handler;
      _eventAdapter = eventAdapter;
    }





    public async Task<CommandResult> HandleAsync(TCommand command)
    {
      CommandResult res = await _handler.HandleAsync(command)
          .ConfigureAwait(false);

      _eventAdapter.Publish(command.Item.DomainEvents);

      return res;
    }



  }
}