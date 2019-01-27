using System.Collections.Generic;

namespace core.domain.services.accessControl
{
  public interface IAccessControlConfig
  {
    Dictionary<string, AccessControlRule> GetRules();
  }
}
