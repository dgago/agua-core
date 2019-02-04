using System;
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
      this.Id = id ?? throw new ArgumentNullException(nameof(id));
    }

    public virtual string ResourceName
    {
      get
      {
        return GetType().FullName;
      }
    }

    public string Id { get; internal set; }

    public IAggregateRoot Item { get; internal set; }
  }
}