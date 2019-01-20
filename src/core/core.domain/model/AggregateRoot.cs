using System.Collections.Generic;

namespace core.domain.model
{
  public abstract class AggregateRoot : Entity, IAggregateRoot
  {

    private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();

    private readonly List<string> _sharedList = new List<string>();

    public AggregateRoot(
      string id,
      string owner,
      List<string> sharedList = null,
      uint version = 0)
      : base(id, version)
    {
      this.Owner = owner;
      this._sharedList = sharedList ?? new List<string>();
    }

    public virtual IReadOnlyList<DomainEvent> DomainEvents => _domainEvents;

    public string Owner { get; }

    public virtual IReadOnlyList<string> SharedList => _sharedList;

    protected bool IsNew => this.Version <= 0;

    public virtual void ClearEvents()
    {
      _domainEvents.Clear();
    }

    protected void AddEvent(DomainEvent newEvent)
    {
      _domainEvents.Add(newEvent);
    }

  }
}