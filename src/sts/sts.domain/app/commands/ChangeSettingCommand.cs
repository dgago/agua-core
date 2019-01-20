using System.Threading.Tasks;
using sts.domain.data;
using sts.domain.model.settings;
using core.domain.app;
using core.domain.extensions;
using core.domain.services;

namespace sts.domain.app.commands
{
  public class ChangeSettingCommand : ItemCommand
  {

    public ChangeSettingCommand(string id, object values) : base(id)
    {
      Values = values;
    }

    public object Values { get; set; }

  }

  public class ChangeSettingCommandHandler : SettingCommandHandler<ChangeSettingCommand>
  {

    internal ChangeSettingCommandHandler(ISettingRepository settingRepository)
      : base(settingRepository)
    {
    }

    public override async Task<CommandResult> HandleAsync(ChangeSettingCommand command)
    {
      SettingRoot item = (SettingRoot)command.Item;

      item.ChangeValues(command.Values);

      await _repository.ReplaceAsync(command.Id, item)
        .ConfigureAwait(false);

      return new CommandResult(item.Id);
    }

  }
}