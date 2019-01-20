using System;
using sts.domain.model.settings.events;
using core.domain.model;

namespace sts.domain.model.settings
{
  public sealed class SettingRoot : AggregateRoot
  {


    internal SettingRoot(string id, string owner, object values, uint version = 0)
    : base(id, owner, null, version)
    {
      Values = values;

      if (IsNew)
      {
        AddEvent(new SettingCreatedEvent(id.ToString(), values, DateTime.Now));
      }
    }





    public object Values { get; private set; }



    #region Internal Methods

    internal void ChangeValues(object values)
    {
      Values = values;

      AddEvent(new SettingChangedEvent(Id.ToString(), values, DateTime.Now));
    }

    #endregion Internal Methods
  }
}