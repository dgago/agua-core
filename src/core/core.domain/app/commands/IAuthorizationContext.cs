namespace core.domain.app.commands
{
  public interface IAuthorizationContext
  {
    string Client { get; }

    string Username { get; }

    string[] UserRoles { get; }
  }
}