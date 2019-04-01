using System.Collections.Generic;
using core.domain.services.accessControl;

namespace bi.console
{
  public class ConsoleAccessControlConfig : IAccessControlConfig
  {
    public Dictionary<string, AccessControlRule> GetRules()
    {
      Dictionary<string, AccessControlRule> dic = new Dictionary<string, AccessControlRule>
      {
        {
          "bi.domain.app.commands.ChangeSettingCommand",
          new AccessControlRule(
          new[] { "console" })
        }
      };

      return dic;
    }
  }
}