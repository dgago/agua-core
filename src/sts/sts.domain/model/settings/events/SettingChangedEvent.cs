using System;
using core.domain.extensions;
using core.domain.model;

namespace sts.domain.model.settings.events
{
  internal class SettingChangedEvent : DomainEvent
  {
    internal SettingChangedEvent(string id, object values, DateTime createdDate)
        : base(createdDate)
    {
      Id = id.NotNull(nameof(id));
      Values = values.NotNull(nameof(values));
    }

    public string Id { get; }

    public object Values { get; }
  }
}