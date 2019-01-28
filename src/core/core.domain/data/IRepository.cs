using System.Threading.Tasks;
using core.domain.model;

namespace core.domain.data
{
  public interface IRepository<TRoot>
    where TRoot : IAggregateRoot
  {
    string Create(TRoot item);

    Task<string> CreateAsync(TRoot item);

    TRoot FindOne(string id);

    Task<TRoot> FindOneAsync(string id);

    //IEntity FindOneData(string id);

    //Task<IEntity> FindOneDataAsync(string id);

    //void Remove(string id);

    Task RemoveAsync(string id);

    bool Replace(string id, TRoot item);

    Task<bool> ReplaceAsync(string id, TRoot item);
  }
}