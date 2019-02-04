using System;
using sts.domain.model.settings.events;
using core.domain.model;

namespace sts.domain.model.settings
{
  public sealed class SettingRoot : AggregateRoot
  {
    public SettingRoot(string id, string owner, object values, uint version = 0)
      : base(id, owner, null, version)
    {
      Values = values;

      if (IsNew)
      {
        AddEvent(new SettingCreatedEvent(id, values, DateTime.Now));
      }
    }

    public object Values { get; private set; }

    internal void ChangeValues(object values)
    {
      Values = values;

      AddEvent(new SettingChangedEvent(Id, values, DateTime.Now));
    }
  }
}