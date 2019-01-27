using System;

namespace core.domain.model
{
  public interface IDomainEvent
  {
    DateTime Date { get; }
  }
}