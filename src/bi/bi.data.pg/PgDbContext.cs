using System.Threading.Tasks;

using core.domain.data;

namespace bi.data.pg
{
  public class PgDbContext : DbContext
  {
    public PgDbContext(string connectionString) : base(connectionString)
    {
    }

    public override Task Close(bool force = false)
    {
      throw new System.NotImplementedException();
    }

    public override Task<TClient> GetClient<TClient>()
    {
      throw new System.NotImplementedException();
    }

    public override Task<TDb> GetDb<TDb>()
    {
      throw new System.NotImplementedException();
    }

    public override Task<TPool> GetPool<TPool>()
    {
      throw new System.NotImplementedException();
    }

    public override Task Release<TClient>(TClient client)
    {
      throw new System.NotImplementedException();
    }
  }
}