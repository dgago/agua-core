using System.Collections.Generic;
using core.domain.model;
using System.Linq;
using core.domain.extensions;

namespace core.domain.services.accessControl
{
  public class AccessControlDomainService : DomainService
  {
    public readonly Dictionary<string, AccessControlRule> _rules;

    public AccessControlDomainService(IAccessControlConfig config)
    {
      this._rules = config.GetRules();
    }

    public bool HasAccess(string resource, string username, string[] roles, IAggregateRoot item)
    {
      AccessControlRule rule = _rules[resource];

      return HasAccess(rule, username, roles, item);
    }

    public bool HasAccess(string resource, string client)
    {
      AccessControlRule rule = _rules[resource];

      return HasAccess(rule, client);
    }

    private static bool AcceptsOwner(AccessControlRule rule)
    {
      return (rule.Type & UserAccessControlType.Owner) != 0;
    }

    private static bool AcceptsRoleList(AccessControlRule rule)
    {
      return (rule.Type & UserAccessControlType.Role) != 0;
    }

    private static bool AcceptsSharedList(AccessControlRule rule)
    {
      return (rule.Type & UserAccessControlType.SharedList) != 0;
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

    private static bool HasAccess(
      AccessControlRule rule,
      string client)
    {
      // rule is null
      if (rule == null)
      {
        return false;
      }

      // rule is for clients and client is not present
      if (client.IsNows())
      {
        return false;
      }

      // rule accepts roles
      if (IsInClientList(rule, client))
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

    private static bool IsInClientList(AccessControlRule rule, string client)
    {
      return rule.Clients.Contains(client);
    }
  }
}
