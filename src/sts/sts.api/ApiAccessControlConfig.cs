using System.Collections.Generic;
using core.domain.services.accessControl;

namespace sts.api
{
  public class ApiAccessControlConfig : IAccessControlConfig
  {
    public Dictionary<string, AccessControlRule> GetRules()
    {
      var dic = new Dictionary<string, AccessControlRule>();

      dic.Add(
        "sts.domain.app.commands.CreateSettingCommand",
        new AccessControlRule(
          new[] { "sts-api" })
        );

      dic.Add(
        "sts.domain.app.commands.ChangeSettingCommand",
        new AccessControlRule(
          new[] { "sts-api" })
        );

      return dic;
    }
  }
}
