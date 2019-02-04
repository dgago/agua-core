using System.Threading.Tasks;
using sts.domain.data;
using sts.domain.model.settings;
using core.domain.app;
using core.domain.extensions;
using core.domain.services;
using Dawn;
using System.Threading;
using core.domain.data;

namespace sts.domain.app.commands
{
  [CommandConfig(AuthorizationType.Client, CommandBehavior.Record)]
  public class ChangeSettingCommand : Command
  {
    public ChangeSettingCommand(string id, object values) : base(id)
    {
      Values = values;
    }

    public object Values { get; set; }
  }

  public class ChangeSettingCommandHandler
    : SettingCommandHandler<ChangeSettingCommand>
  {
    public ChangeSettingCommandHandler(
      ISettingRepository settingRepository)
      : base(settingRepository)
    {
    }

    public override CommandResult Handle(ChangeSettingCommand command)
    {
      SettingRoot item = (SettingRoot)command.Item;

      Guard.Argument(item).NotNull(nameof(item));

      item.ChangeValues(command.Values);

      _repository.Replace(command.Id, item);

      return new CommandResult(item.Id, item.DomainEvents);
    }

    public override async Task<CommandResult> HandleAsync(
      ChangeSettingCommand command)
    {
      SettingRoot item = (SettingRoot)command.Item;

      Guard.Argument(item).NotNull(nameof(item));

      item.ChangeValues(command.Values);

      await _repository.ReplaceAsync(command.Id, item)
        .ConfigureAwait(false);

      return new CommandResult(item.Id, item.DomainEvents);
    }
  }
}