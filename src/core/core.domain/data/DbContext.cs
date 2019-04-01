using System.Threading.Tasks;

namespace core.domain.data
{
  public abstract class DbContext : IDbContext
  {
    protected DbContext(string connectionString)
    {
      this.ConnectionString = connectionString;
    }

    public string ConnectionString { get; private set; }

    public abstract Task Close(bool force = false);

    public abstract Task<TClient> GetClient<TClient>();

    public abstract Task<TDb> GetDb<TDb>();

    public abstract Task<TPool> GetPool<TPool>();

    public abstract Task Release<TClient>(TClient client);
  }
}