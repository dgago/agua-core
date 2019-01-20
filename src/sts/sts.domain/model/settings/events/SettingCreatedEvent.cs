using System;
using core.domain.model;

namespace sts.domain.model.settings.events
{
  internal class SettingCreatedEvent : DomainEvent
  {


    internal SettingCreatedEvent(string id, object values, DateTime createdDate)
        : base(createdDate)
    {
      Id = id;
      Values = values;
    }





    public string Id { get; }

    public object Values { get; }


  }
}