using System;
using System.Threading.Tasks;
using sts.domain.data;
using core.domain.app;
using core.domain.services;

namespace sts.domain.app.commands
{

  public abstract class SettingCommandHandler<TCommand> : ICommandHandler<TCommand>
    where TCommand : Command
  {
    protected readonly ISettingRepository _repository;

    protected SettingCommandHandler(ISettingRepository settingRepository)
    {
      _repository = settingRepository
        ?? throw new ArgumentNullException(nameof(settingRepository));
    }

    public abstract Task<CommandResult> HandleAsync(TCommand command);
  }
}