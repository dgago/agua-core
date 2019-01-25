namespace core.domain.services.accessControl
{
  public class AccessControlRule
  {
    public AccessControlRule(UserAccessControlType type, string[] roles)
    {
      this.Type = type;
      this.Roles = roles;
    }

    public AccessControlRule(string[] clients)
    {
      this.Clients = clients;
    }

    public string[] Clients { get; }

    public string[] Roles { get; }

    public UserAccessControlType Type { get; }
  }
}
