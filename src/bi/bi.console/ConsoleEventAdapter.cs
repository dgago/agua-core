using System;
using System.Collections.Generic;

using core.domain.model;
using core.domain.services.events;

namespace bi.console
{
  internal class ConsoleEventAdapter : IEventAdapter
  {
    public void Publish(IEnumerable<IDomainEvent> domainEvents)
    {
      foreach(var item in domainEvents)
      {
        string eventName = item.GetType().FullName;
        Console.WriteLine($"Event {eventName} raised on {item.Date}. " +
          "Data: {JsonConvert.SerializeObject(item)}");
      }
    }
  }
}