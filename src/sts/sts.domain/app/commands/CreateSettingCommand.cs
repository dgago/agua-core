using System.Threading.Tasks;
using sts.domain.data;
using sts.domain.model.settings;
using core.domain.app;
using core.domain.services;
using System.Threading;

namespace sts.domain.app.commands
{
  [CommandConfig(AuthorizationType.Client, CommandBehavior.Action)]
  public class CreateSettingCommand : Command
  {
    public CreateSettingCommand(string id, object values) : base(id)
    {
      Values = values;
    }

    public object Values { get; set; }
  }

  public class CreateSettingCommandHandler
    : SettingCommandHandler<CreateSettingCommand>
  {

    internal CreateSettingCommandHandler(ISettingRepository settingRepository)
      : base(settingRepository)
    {
    }

    public override CommandResult Handle(
      CreateSettingCommand command,
      CancellationToken cancellationToken)
    {
      SettingRoot item = new SettingRoot(
        command.Id,
        command.Username,
        command.Values);

      string id = _repository.Create(item);

      return new CommandResult(id);
    }

    public override async Task<CommandResult> HandleAsync(
      CreateSettingCommand command,
      CancellationToken cancellationToken)
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