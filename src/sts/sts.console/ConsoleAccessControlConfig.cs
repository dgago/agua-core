using System.Collections.Generic;
using core.domain.services.accessControl;

namespace sts.console
{
  public class ConsoleAccessControlConfig : IAccessControlConfig
  {
    public Dictionary<string, AccessControlRule> GetRules()
    {
      var dic = new Dictionary<string, AccessControlRule>();

      dic.Add(
        "sts.domain.app.commands.ChangeSettingCommand",
        new AccessControlRule(
          new[] { "console" })
        );

      return dic;
    }
  }
}
