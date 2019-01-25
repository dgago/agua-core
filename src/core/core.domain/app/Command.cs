using core.domain.model;

namespace core.domain.app
{
  public enum AuthorizationType
  {
    None = 0,
    Client = 1,
    User = 2
  }

  public enum CommandBehavior
  {
    ItemCommand = 1,
    NonItemCommand = 2
  }

  [System.AttributeUsage(System.AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
  sealed class CommandSettingsAttribute : System.Attribute
  {
    // See the attribute guidelines at
    //  http://go.microsoft.com/fwlink/?LinkId=85236
    readonly AuthorizationType _type;
    readonly CommandBehavior _behavior;

    // This is a positional argument
    public CommandSettingsAttribute(
      AuthorizationType type,
      CommandBehavior behavior)
    {
      this._type = type;
      this._behavior = behavior;
    }

    public AuthorizationType Type
    {
      get { return _type; }
    }

    public CommandBehavior Behavior
    {
      get { return _behavior; }
    }

    // This is a named argument
    // public int NamedInt { get; set; }
  }

  public abstract class Command
  {
    public Command()
    {
    }

    public Command(string id)
    {
      this.Id = id;
    }

    public virtual string ResourceName
    {
      get
      {
        return GetType().FullName;
      }
    }

    public string Client { get; set; }

    public string Username { get; set; }

    public string[] UserRoles { get; set; }

    public string Id { get; internal set; }

    public IAggregateRoot Item { get; internal set; }
  }
}