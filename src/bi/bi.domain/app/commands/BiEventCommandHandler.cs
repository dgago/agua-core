using System.Threading.Tasks;
using bi.domain.data;
using core.domain.app;
using core.domain.app.commands;
using core.domain.extensions;
using core.domain.services;

namespace bi.domain.app.commands
{
  public abstract class BiEventCommandHandler<TCommand>
    : ICommandHandler<TCommand>
    where TCommand : Command
  {
    protected readonly IAuthorizationContext _context;

    protected readonly IBiEventRepository _repository;

    protected BiEventCommandHandler(
      IBiEventRepository BiEventRepository,
      IAuthorizationContext context)
    {
      this._repository = BiEventRepository.NotNull(nameof(BiEventRepository));
      this._context = context.NotNull(nameof(context));
    }

    public abstract CommandResult Handle(TCommand command);

    public abstract Task<CommandResult> HandleAsync(TCommand command);
  }
}