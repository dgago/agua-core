using System;
using core.domain.app.commands;

namespace sts.console
{
  internal class ConsoleAuthorizationContext : IAuthorizationContext
  {
    internal ConsoleAuthorizationContext(string client)
    {
      this.Client = client ?? throw new ArgumentNullException(nameof(client));
    }

    internal ConsoleAuthorizationContext(string client, string username, string[] userRoles)
    {
      this.Client = client ?? throw new ArgumentNullException(nameof(client));
      this.Username = username ?? throw new ArgumentNullException(nameof(username));
      this.UserRoles = userRoles ?? throw new ArgumentNullException(nameof(userRoles));
    }

    public string Client { get; }

    public string Username { get; }

    public string[] UserRoles { get; }
  }
}
