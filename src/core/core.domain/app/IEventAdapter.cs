using System.Collections.Generic;
using core.domain.model;

namespace core.domain.app
{
  public interface IEventAdapter
  {
    void Publish(IReadOnlyList<DomainEvent> domainEvents);
  }
}