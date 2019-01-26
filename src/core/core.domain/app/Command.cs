using core.domain.model;

namespace core.domain.app
{
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