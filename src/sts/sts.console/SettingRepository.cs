using System;
using System.Threading.Tasks;
using core.domain.model;
using sts.domain.data;

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
      throw new NotImplementedException();
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
      throw new NotImplementedException();
    }

    public Task<bool> ReplaceAsync(string id, IAggregateRoot item)
    {
      throw new NotImplementedException();
    }
  }
}
