using System.Threading.Tasks;
using core.domain.app;
using core.domain.services;
using sts.domain.data;
using sts.domain.model.settings;

namespace sts.domain.app.commands
{
  public class RemoveSettingCommand : ItemCommand
  {
    public RemoveSettingCommand(string id, object values) : base(id)
    {
    }
  }

  public class RemoveSettingCommandHandler
    : SettingCommandHandler<RemoveSettingCommand>
  {
    internal RemoveSettingCommandHandler(ISettingRepository settingRepository)
      : base(settingRepository)
    {
    }

    public override async Task<CommandResult> HandleAsync(
      RemoveSettingCommand command)
    {
      SettingRoot item = (SettingRoot)command.Item;

      await _repository.RemoveAsync(item.Id)
        .ConfigureAwait(false);

      return new CommandResult(item.Id);
    }
  }
}