using System;
using System.Collections.Generic;
using core.domain.extensions;

namespace core.domain.model
{
  public abstract class AggregateRoot : Entity, IAggregateRoot
  {
    private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

    private readonly List<string> _sharedList = new List<string>();

    protected AggregateRoot(
      string id,
      string owner,
      List<string> sharedList = null,
      uint version = 0)
      : base(id, version)
    {
      this.Owner = owner.NotNull(nameof(owner));
      this._sharedList = sharedList ?? new List<string>();
    }

    public virtual IReadOnlyList<IDomainEvent> DomainEvents => this._domainEvents;

    public string Owner { get; }

    public virtual IReadOnlyList<string> SharedList => this._sharedList;

    protected bool IsNew => this.Version <= 0;

    public virtual void ClearEvents()
    {
      this._domainEvents.Clear();
    }

    protected void AddEvent(IDomainEvent newEvent)
    {
      this._domainEvents.Add(newEvent);
    }

    protected abstract TData ToData<TData>();
  }
}