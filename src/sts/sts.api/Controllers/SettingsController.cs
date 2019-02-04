using System.Threading;
using System.Threading.Tasks;
using core.domain.app;
using core.domain.services;
using Microsoft.AspNetCore.Mvc;
using sts.domain.app.commands;

namespace sts.api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SettingsController : ControllerBase
  {
    private readonly ICommandHandler<CreateSettingCommand> _createSetting;
    private readonly ICommandHandler<ChangeSettingCommand> _changeSetting;

    public SettingsController(
      ICommandHandler<CreateSettingCommand> createSettingCommand,
      ICommandHandler<ChangeSettingCommand> changeSettingCommand
      )
    {
      _createSetting = createSettingCommand;
      _changeSetting = changeSettingCommand;
    }

    // POST api/settings
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SettingModel setting)
    {
      CreateSettingCommand command = new CreateSettingCommand(
        null,
        setting.Values);
      CommandResult res = await _createSetting.HandleAsync(
        command).ConfigureAwait(false);
      return Ok(res.Id);
    }
  }
}
