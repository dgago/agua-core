namespace core.domain.services.accessControl
{
  public class AccessControlRule
  {

    public string[] Clients { get; }

    public string[] Roles { get; }

    public AccessControlType Type { get; }

  }
}
