using System.Threading.Tasks;
using core.domain.data;
using core.domain.services;

namespace core.domain.app
{
  public interface IItemCommandHandler<TCommand>
    : ICommandHandler<TCommand>
    where TCommand : Command
  {
    IRepository Repository { get; }
  }
}