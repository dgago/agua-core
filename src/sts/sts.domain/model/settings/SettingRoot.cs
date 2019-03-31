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
      this.Values = values;

      if (this.IsNew)
      {
        this.AddEvent(new SettingCreatedEvent(id, values, DateTime.Now));
      }
    }

    public object Values { get; private set; }

    internal void ChangeValues(object values)
    {
      this.Values = values;

      this.AddEvent(new SettingChangedEvent(this.Id, values, DateTime.Now));
    }

    protected override TData ToData<TData>()
    {
      throw new NotImplementedException();
    }
  }
}