using System;
using System.Collections.Generic;

namespace core.domain.model
{
  public abstract class AggregateRoot : Entity, IAggregateRoot
  {
    private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

    private readonly List<string> _sharedList = new List<string>();

    public AggregateRoot(
      string id,
      string owner,
      List<string> sharedList = null,
      uint version = 0)
      : base(id, version)
    {
      this.Owner = owner ?? throw new ArgumentNullException(nameof(owner));
      this._sharedList = sharedList ?? new List<string>();
    }

    public virtual IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

    public string Owner { get; }

    public virtual IReadOnlyList<string> SharedList => _sharedList;

    protected bool IsNew => this.Version <= 0;

    public virtual void ClearEvents()
    {
      _domainEvents.Clear();
    }

    protected void AddEvent(IDomainEvent newEvent)
    {
      _domainEvents.Add(newEvent);
    }
  }
}