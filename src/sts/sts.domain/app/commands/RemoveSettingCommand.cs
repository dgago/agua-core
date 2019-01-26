using System.Threading;
using System.Threading.Tasks;
using core.domain.app;
using core.domain.services;
using sts.domain.data;
using sts.domain.model.settings;

namespace sts.domain.app.commands
{
  [CommandConfig(AuthorizationType.Client, CommandBehavior.Record)]
  public class RemoveSettingCommand : Command
  {
    public RemoveSettingCommand(string id, object values) : base(id)
    {
    }
  }

  public class RemoveSettingCommandHandler
    : SettingCommandHandler<RemoveSettingCommand>
  {
    internal RemoveSettingCommandHandler(
      ISettingRepository settingRepository)
      : base(settingRepository)
    {
    }

    public override CommandResult Handle(
      RemoveSettingCommand command,
      CancellationToken cancellationToken)
    {
      SettingRoot item = (SettingRoot)command.Item;

      _repository.RemoveAsync(item.Id).Wait(cancellationToken);

      return new CommandResult(item.Id);
    }

    public override async Task<CommandResult> HandleAsync(
      RemoveSettingCommand command,
      CancellationToken cancellationToken)
    {
      SettingRoot item = (SettingRoot)command.Item;

      await _repository.RemoveAsync(item.Id)
        .ConfigureAwait(false);

      return new CommandResult(item.Id);
    }
  }
}