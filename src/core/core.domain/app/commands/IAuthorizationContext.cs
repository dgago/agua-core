namespace core.domain.app.commands
{
  public interface IAuthorizationContext
  {
    string Client { get; set; }

    string Username { get; set; }

    string[] UserRoles { get; set; }
  }
}