using core.domain.app.commands;
using core.domain.extensions;

namespace bi.console
{
  /// <summary>
  /// Permite realizar tareas de ACL en los comandos.
  /// Esta implementación es particular para una app de consola.
  /// </summary>
  internal class ConsoleAuthorizationContext : IAuthorizationContext
  {
    internal ConsoleAuthorizationContext(string client)
    {
      this.Client = client.NotNull(nameof(client));
    }

    internal ConsoleAuthorizationContext(string client, string username, string[] userRoles)
    {
      this.Client = client.NotNull(nameof(client));
      this.Username = username.NotNull(nameof(username));
      this.UserRoles = userRoles.NotNull(nameof(userRoles));
    }

    public string Client { get; }

    public string Username { get; }

    public string[] UserRoles { get; }
  }
}