using System.Collections.Generic;

namespace core.domain.services.accessControl
{
  public interface IAccessControlConfigDomainService
  {
    Dictionary<string, AccessControlRule> GetRules();
  }
}
