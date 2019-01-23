namespace core.domain.app
{
  public abstract class Command
  {
    public virtual string ResourceName
    {
      get
      {
        return GetType().AssemblyQualifiedName;
      }
    }

    public string Client { get; set; }

    public string Username { get; set; }

    public string[] UserRoles { get; set; }
  }
}