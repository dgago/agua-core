using System.Collections.Generic;
using System.Threading.Tasks;

namespace core.domain.data
{
  public abstract class DbContext
  {
    public string ConnectionString { get; private set; }

    public abstract Task<TClient> GetClient<TClient>();

    public abstract Task<TPool> GetPool<TPool>();

    public abstract Task<TDb> GetDb<TDb>();

    public abstract Task Release<TClient>(TClient client);

    public abstract Task Close(bool force = false);
  }
}