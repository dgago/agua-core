using System.Collections.Generic;
using core.domain.model;
using System.Linq;
using core.domain.extensions;

namespace core.domain.services.accessControl
{
  // TODO: don't like this to be static
  // TODO: should be a singleton, yes, but not static
  public class AccessControlDomainService : DomainService
  {

    // TODO: restrict access to this rules
    public static Dictionary<string, AccessControlRule> _rules;

    public static bool HasAccess(string resource, string username, string[] roles, IAggregateRoot item)
    {
      AccessControlRule rule = _rules[resource];

      return HasAccess(rule, username, roles, item);
    }

    private static bool AcceptsOwner(AccessControlRule rule)
    {
      return (rule.Type & AccessControlType.Owner) != 0;
    }

    private static bool AcceptsRoleList(AccessControlRule rule)
    {
      return (rule.Type & AccessControlType.Role) != 0;
    }

    private static bool AcceptsSharedList(AccessControlRule rule)
    {
      return (rule.Type & AccessControlType.SharedList) != 0;
    }

    private static bool HasAccess(
      AccessControlRule rule,
      string username,
      string[] roles,
      IAggregateRoot item)
    {
      // rule is null
      if (rule == null)
      {
        return false;
      }

      // rule is for users and username is not present
      if (username.IsNows())
      {
        return false;
      }

      // rule accepts roles
      if (AcceptsRoleList(rule) && HasRole(rule, roles))
      {
        return true;
      }

      // rule accepts owner
      if (item != null && AcceptsOwner(rule) && IsOwner(username, item))
      {
        return true;
      }

      // rule accepts shared list
      if (item != null && AcceptsSharedList(rule) && IsInSharedList(username, item))
      {
        return true;
      }

      return false;
    }

    private static bool HasRole(AccessControlRule rule, string[] roles)
    {
      return rule.Roles.Any(x => roles.Contains(x));
    }

    private static bool IsInSharedList(string username, IAggregateRoot item)
    {
      return item.SharedList.Contains(username);
    }

    private static bool IsOwner(string username, IAggregateRoot item)
    {
      return username == item.Owner;
    }

  }
}
