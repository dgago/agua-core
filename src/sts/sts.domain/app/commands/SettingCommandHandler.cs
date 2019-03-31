using System.Threading.Tasks;
using sts.domain.data;
using core.domain.app;
using core.domain.services;
using core.domain.extensions;

namespace sts.domain.app.commands
{
  public abstract class SettingCommandHandler<TCommand>
    : ICommandHandler<TCommand>
    where TCommand : Command
  {
    protected ISettingRepository _repository { get; }

    protected SettingCommandHandler(ISettingRepository settingRepository)
    {
      _repository = settingRepository.NotNull(nameof(settingRepository));
    }

    public abstract CommandResult Handle(TCommand command);

    public abstract Task<CommandResult> HandleAsync(TCommand command);
  }
}