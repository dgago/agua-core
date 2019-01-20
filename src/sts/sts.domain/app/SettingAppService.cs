using System;
using System.Threading.Tasks;
using sts.domain.app.commands;
using sts.domain.data;
using sts.domain.model.settings;
using core.domain.app;
using core.domain.services;

namespace sts.domain.app
{
  //public class SettingAppService : ApplicationService
  //{
  //  private readonly ISettingRepository _settingRepository;

  //  // TODO: Constructor

  //  public async Task<CommandResult> CreateSetting(CreateSettingCommand command)
  //  {
  //    SettingRoot item = new SettingRoot(
  //      command.Id, 
  //      command.Username, 
  //      command.Values);

  //    Acl(command, item);

  //    await _settingRepository.CreateAsync(item).ConfigureAwait(false);

  //    PublishAsync(item);

  //    return new CommandResult(item.Id, null);
  //  }

  //  public async Task<CommandResult> ChangeSetting(ChangeSettingCommand command)
  //  {
  //    SettingRoot item = await _settingRepository.FindOneAsync(command.Id);

  //    Acl(command, item);

  //    if (item == null)
  //    {
  //      throw new ApplicationException("La configuración a actualizar no existe");
  //    }

  //    await _settingRepository.RemoveAsync(command.Id).ConfigureAwait(false);

  //    // TODO: nunca se produjo el evento
  //    PublishAsync(item);

  //    return new CommandResult(item.Id, null);
  //  }

  //  public async Task<CommandResult> RemoveSetting(RemoveSettingCommand command)
  //  {
  //    // TODO: validaciones del command?
  //    SettingRoot item = new SettingRoot(command.Id, command.Username, null);

  //    Acl(command, item);

  //    if (item == null)
  //    {
  //      throw new ApplicationException("La configuración a eliminiar no existe");
  //    }

  //    await _settingRepository.CreateAsync(item).ConfigureAwait(false);

  //    PublishAsync(item);

  //    return new CommandResult(item.Id, null);
  //  }
  //}
}