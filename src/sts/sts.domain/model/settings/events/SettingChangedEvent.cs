using System;
using core.domain.model;

namespace sts.domain.model.settings.events
{
  internal class SettingChangedEvent : DomainEvent
  {


    internal SettingChangedEvent(string id, object values, DateTime createdDate)
        : base(createdDate)
    {
      Id = id;
      Values = values;
    }





    public string Id { get; }

    public object Values { get; }


  }
}