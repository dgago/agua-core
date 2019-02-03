using System.Threading;
using System.Threading.Tasks;
using core.domain.app;
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
      this._createSetting = createSettingCommand;
      this._changeSetting = changeSettingCommand;
    }

    // POST api/settings
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Setting setting)
    {
      CreateSettingCommand command = new CreateSettingCommand(
        null,
        setting.Values);
      var id = await this._createSetting.HandleAsync(command, new CancellationToken());
      return Ok(id);
    }
  }

  public class Setting
  {
    public string Id { get; set; }

    public string Values { get; set; }
  }
}
