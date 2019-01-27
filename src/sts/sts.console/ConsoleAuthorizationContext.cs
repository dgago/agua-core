using core.domain.app.commands;

namespace sts.console
{
  internal class ConsoleAuthorizationContext : IAuthorizationContext
  {
    internal ConsoleAuthorizationContext(string client)
    {
      this.Client = client;
    }

    internal ConsoleAuthorizationContext(string client, string username, string[] userRoles)
    {
      this.Client = client;
      this.Username = username;
      this.UserRoles = userRoles;
    }

    public string Client { get; set; }

    public string Username { get; set; }

    public string[] UserRoles { get; set; }
  }
}
