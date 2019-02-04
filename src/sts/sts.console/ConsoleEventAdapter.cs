using System;
using System.Collections.Generic;
using core.domain.app;
using core.domain.model;
using core.domain.services.events;
using Newtonsoft.Json;

namespace sts.console
{
  internal class ConsoleEventAdapter : IEventAdapter
  {
    public void Publish(IEnumerable<IDomainEvent> domainEvents)
    {
      foreach (var item in domainEvents)
      {
        string eventName = item.GetType().FullName;
        Console.WriteLine($"Event {eventName} raised on {item.Date}. " +
          "Data: {JsonConvert.SerializeObject(item)}");
      }
    }
  }
}