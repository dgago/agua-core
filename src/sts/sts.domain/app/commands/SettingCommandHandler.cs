using System;
using System.Threading.Tasks;
using sts.domain.data;
using core.domain.app;
using core.domain.services;
using System.Threading;
using core.domain.data;

namespace sts.domain.app.commands
{
  public abstract class SettingCommandHandler<TCommand>
    : ICommandHandler<TCommand>
    where TCommand : Command
  {
    protected ISettingRepository _repository { get; }

    IRepository ICommandHandler<TCommand>.Repository => _repository;

    protected SettingCommandHandler(ISettingRepository settingRepository)
    {
      _repository = settingRepository
        ?? throw new ArgumentNullException(nameof(settingRepository));
    }

    public abstract CommandResult Handle(TCommand command,
      CancellationToken cancellationToken);

    public abstract Task<CommandResult> HandleAsync(TCommand command,
      CancellationToken cancellationToken);
  }
}