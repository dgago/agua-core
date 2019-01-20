using System.Threading.Tasks;
using core.domain.model;

namespace core.domain.data
{
  public interface IRepository
  {

    //string Create(IAggregateRoot item);

    Task<string> CreateAsync(IAggregateRoot item);

    IAggregateRoot FindOne(string id);

    Task<IAggregateRoot> FindOneAsync(string id);

    //IEntity FindOneData(string id);

    //Task<IEntity> FindOneDataAsync(string id);

    //void Remove(string id);

    Task RemoveAsync(string id);

    //bool Replace(string id, IAggregateRoot item);

    Task<bool> ReplaceAsync(string id, IAggregateRoot item);

  }
}