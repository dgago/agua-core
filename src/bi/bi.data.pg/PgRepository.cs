using System.Threading.Tasks;
using core.domain.data;
using core.domain.model;

namespace bi.data.pg
{
  public class PgRepository<TRoot> : IRepository<TRoot>
    where TRoot : IAggregateRoot
  {
    protected readonly DbContext _context;

    public PgRepository(DbContext context)
    {
      this._context = context;
    }

    public virtual string Create(TRoot item)
    {
      throw new System.NotImplementedException();
    }

    public virtual Task<string> CreateAsync(TRoot item)
    {
      throw new System.NotImplementedException();
    }

    public virtual TRoot FindOne(string id)
    {
      throw new System.NotImplementedException();
    }

    public virtual Task<TRoot> FindOneAsync(string id)
    {
      throw new System.NotImplementedException();
    }

    public virtual Task RemoveAsync(string id)
    {
      throw new System.NotImplementedException();
    }

    public virtual bool Replace(string id, TRoot item)
    {
      throw new System.NotImplementedException();
    }

    public virtual Task<bool> ReplaceAsync(string id, TRoot item)
    {
      throw new System.NotImplementedException();
    }
  }
}
