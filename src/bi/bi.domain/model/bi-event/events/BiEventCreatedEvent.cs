using System;
using System.Collections.Generic;
using core.domain.extensions;
using core.domain.model;

namespace bi.domain.model.bi_event
{
  internal class BiEventCreatedEvent : DomainEvent
  {
    internal BiEventCreatedEvent(
      string id,
      string name,
      IDictionary<string, IDictionary<string, object>> payload,
      DateTime createdDate)
      : base(createdDate)
    {
      this.Id = id;
      this.Name = name;
      this.Payload = payload;
    }

    public string Id { get; }
    public string Name { get; }
    public IDictionary<string, IDictionary<string, object>> Payload { get; }
  }
}