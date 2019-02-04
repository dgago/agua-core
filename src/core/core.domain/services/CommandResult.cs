using System.Collections.Generic;
using core.domain.model;

namespace core.domain.services
{
  public class CommandResult
  {
    public CommandResult(string id, IReadOnlyList<IDomainEvent> domainEvents,
      string message)
    {
      Id = id;
      DomainEvents = domainEvents;
      Message = message;
    }

    public CommandResult(string id, IReadOnlyList<IDomainEvent> domainEvents)
    {
      Id = id;
      DomainEvents = domainEvents;
    }

    public string Id { get; }

    public string Message { get; }

    public IReadOnlyList<IDomainEvent> DomainEvents { get; }
  }
}