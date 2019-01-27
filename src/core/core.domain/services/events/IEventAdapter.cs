using System.Collections.Generic;
using core.domain.model;

namespace core.domain.services.events
{
  public interface IEventAdapter
  {
    void Publish(IEnumerable<IDomainEvent> domainEvents);
  }
}