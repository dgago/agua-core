using System.Threading.Tasks;

namespace core.domain.data
{
  public interface IDbContext
  {
    string ConnectionString { get; }

    Task Close(bool force = false);
    Task<TClient> GetClient<TClient>();
    Task<TDb> GetDb<TDb>();
    Task<TPool> GetPool<TPool>();
    Task Release<TClient>(TClient client);
  }
}