using System.Collections.Generic;

namespace core.domain.model
{
  public interface IAggregateRoot : IEntity
  {

    IReadOnlyList<DomainEvent> DomainEvents { get; }

    string Owner { get; }

    IReadOnlyList<string> SharedList { get; }

    void ClearEvents();

  }
}