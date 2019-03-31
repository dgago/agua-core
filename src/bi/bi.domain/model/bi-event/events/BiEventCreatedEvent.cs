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
      Dictionary<string, dynamic> payload,
      //BiEventStatus status,
      DateTime createdDate)
      : base(createdDate)
    {
      this.Id = id.NotNull(nameof(id));
      this.Name = name.NotNull(nameof(name));
      this.Payload = payload.NotNull(nameof(payload));
      //this.Status = status;
    }

    public string Id { get; }
    public string Name { get; }
    public Dictionary<string, dynamic> Payload { get; }
    //public BiEventStatus Status{ get; }
  }
}