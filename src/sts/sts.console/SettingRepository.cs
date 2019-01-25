using System;
using System.Threading.Tasks;
using core.domain.model;
using sts.domain.data;
using sts.domain.model.settings;

namespace sts.console
{
  class SettingRepository : ISettingRepository
  {
    public string Create(IAggregateRoot item)
    {
      throw new NotImplementedException();
    }

    public Task<string> CreateAsync(IAggregateRoot item)
    {
      throw new NotImplementedException();
    }

    public IAggregateRoot FindOne(string id)
    {
      return new SettingRoot("1", "me", new { a = 4 });
    }

    public Task<IAggregateRoot> FindOneAsync(string id)
    {
      throw new NotImplementedException();
    }

    public IEntity FindOneData(string id)
    {
      throw new NotImplementedException();
    }

    public Task<IEntity> FindOneDataAsync(string id)
    {
      throw new NotImplementedException();
    }

    public void Remove(string id)
    {
      throw new NotImplementedException();
    }

    public Task RemoveAsync(string id)
    {
      throw new NotImplementedException();
    }

    public bool Replace(string id, IAggregateRoot item)
    {
      return true;
    }

    public Task<bool> ReplaceAsync(string id, IAggregateRoot item)
    {
      throw new NotImplementedException();
    }
  }
}
