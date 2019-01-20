using System;
using System.Collections.Generic;

namespace core.domain.model
{
  public abstract class DomainEvent : ValueObject
  {
    public DomainEvent(DateTime date)
    {
      this.Date = date;
    }

    public DateTime Date { get; }
  }
}