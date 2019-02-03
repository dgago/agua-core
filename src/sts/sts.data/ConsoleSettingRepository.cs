using System;
using System.Threading.Tasks;
using core.domain.model;
using sts.domain.data;
using sts.domain.model.settings;

namespace sts.data
{
  public class ConsoleSettingRepository : ISettingRepository
  {
    public string Create(SettingRoot item)
    {
      return "1";
    }

    public Task<string> CreateAsync(SettingRoot item)
    {
      return Task.FromResult("1");
    }

    public SettingRoot FindOne(string id)
    {
      return new SettingRoot("1", "me", new { a = 4 }, 1);
    }

    public Task<SettingRoot> FindOneAsync(string id)
    {
      return Task.FromResult(
        (SettingRoot)new SettingRoot("1", "me", new { a = 4 }, 1)
      );
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

    public bool Replace(string id, SettingRoot item)
    {
      return true;
    }

    public Task<bool> ReplaceAsync(string id, SettingRoot item)
    {
      return Task.FromResult(true);
    }
  }
}
