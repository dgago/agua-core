using System.Threading.Tasks;
using sts.domain.data;
using sts.domain.model.settings;
using core.domain.app;
using core.domain.extensions;
using core.domain.services;
using Dawn;

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

    public ChangeSettingCommandHandler(ISettingRepository settingRepository)
      : base(settingRepository)
    {
    }

    public override async Task<CommandResult> HandleAsync(ChangeSettingCommand command)
    {
      SettingRoot item = (SettingRoot)command.Item;

      Guard.Argument(item).NotNull(nameof(item));

      item.ChangeValues(command.Values);

      await _repository.ReplaceAsync(command.Id, item)
        .ConfigureAwait(false);

      return new CommandResult(item.Id);
    }

  }
}