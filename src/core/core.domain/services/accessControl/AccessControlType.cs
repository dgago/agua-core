using System;

namespace core.domain.services.accessControl
{
  [Flags]
  public enum AccessControlType
  {
    Role = 1,
    Owner = 2,
    SharedList = 4,
    RoleOwner = Role | Owner,
    RoleSharedList = Role | SharedList,
    OwnerSharedList = Owner | SharedList,
    RoleOwnerSharedList = Role | Owner | SharedList,
  }
}
