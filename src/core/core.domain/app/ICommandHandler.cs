using System.Threading;
using System.Threading.Tasks;
using core.domain.data;
using core.domain.services;

namespace core.domain.app
{
  public interface ICommandHandler<TCommand>
    where TCommand : Command
  {
    IRepository Repository { get; }

    CommandResult Handle(TCommand command,
      CancellationToken cancellationToken);

    Task<CommandResult> HandleAsync(TCommand command,
      CancellationToken cancellationToken);
  }
}