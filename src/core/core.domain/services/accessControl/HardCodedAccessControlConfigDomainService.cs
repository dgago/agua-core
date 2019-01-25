using System.Collections.Generic;

namespace core.domain.services.accessControl
{
  public class HardCodedAccessControlConfigDomainService : IAccessControlConfigDomainService
  {
    public Dictionary<string, AccessControlRule> GetRules()
    {
      var dic = new Dictionary<string, AccessControlRule>();

      dic.Add("sts.domain.app.commands.ChangeSettingCommand", new AccessControlRule(new[] { "console" }));

      return dic;
    }
  }
}
