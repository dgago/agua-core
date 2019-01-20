using System.Threading.Tasks;
using sts.domain.data;
using sts.domain.model.settings;
using core.domain.app;
using core.domain.services;

namespace sts.domain.app.commands
{
  public class CreateSettingCommand : Command
  {

    public CreateSettingCommand(string id, object values)
    {
      Id = id;
      Values = values;
    }

    public string Id { get; set; }

    public object Values { get; set; }

  }

  public class CreateSettingCommandHandler
    : SettingCommandHandler<CreateSettingCommand>
  {

    internal CreateSettingCommandHandler(ISettingRepository settingRepository)
      : base(settingRepository)
    {
    }

    public override async Task<CommandResult> HandleAsync(
      CreateSettingCommand command)
    {
      SettingRoot item = new SettingRoot(
        command.Id,
        command.Username,
        command.Values);

      string id = await _repository.CreateAsync(item)
        .ConfigureAwait(false);

      return new CommandResult(id);
    }

  }

}