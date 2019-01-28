using System;
using System.Threading.Tasks;
using core.domain.model;

namespace core.domain.data
{
  public abstract class Repository<TRoot> : IRepository<TRoot>
    where TRoot : AggregateRoot
  {
    protected Mapper<TRoot, IEntity> Mapper { get; }

    protected IStore<IEntity, string> Store { get; }

    public virtual string Create(TRoot item)
    {
      IEntity ritem = Mapper.MapToData(item);
      return Store.Create(ritem);
    }

    public virtual Task<string> CreateAsync(TRoot item)
    {
      IEntity ritem = Mapper.MapToData(item);
      return Store.CreateAsync(ritem);
    }

    public virtual TRoot FindOne(string id)
    {
      IEntity item = Store.FindOne(id);
      if (item == null)
      {
        return null;
      }

      return Mapper.MapToDomain(item);
    }

    public virtual async Task<TRoot> FindOneAsync(string id)
    {
      IEntity item = await Store.FindOneAsync(id).ConfigureAwait(false);
      if (item == null)
      {
        return null;
      }

      return Mapper.MapToDomain(item);
    }

    public virtual IEntity FindOneData(string id)
    {
      return Store.FindOne(id);
    }

    public virtual Task<IEntity> FindOneDataAsync(string id)
    {
      return Store.FindOneAsync(id);
    }

    public void Remove(string id)
    {
      IEntity ditem = Store.FindOne(id);
      if (ditem == null)
      {
        throw new ApplicationException($"El registro a eliminar no existe.");
      }

      Store.Remove(id);
    }

    public async Task RemoveAsync(string id)
    {
      IEntity ditem = await Store.FindOneAsync(id).ConfigureAwait(false);
      if (ditem == null)
      {
        throw new ApplicationException($"El registro a eliminar no existe.");
      }

      Store.Remove(id);
    }

    public virtual bool Replace(string id, TRoot item)
    {
      IEntity ditem = GetItem(id);

      ValidateItemVersion(item, ditem);

      IEntity ritem = Mapper.MapToData(item);
      return Store.Replace(id, ritem);
    }

    public virtual async Task<bool> ReplaceAsync(string id, TRoot item)
    {
      IEntity ditem = await GetItemAsync(id);

      ValidateItemVersion(item, ditem);

      IEntity ritem = Mapper.MapToData(item);
      return await Store.ReplaceAsync(id, ritem).ConfigureAwait(false);
    }

    private static void ValidateItemVersion(TRoot item, IEntity ditem)
    {
      if (ditem.Version > item.Version)
      {
        throw new ApplicationException($"El registro a actualizar está obsoleto. Versiones {ditem.Version} <> {item.Version}.");
      }
    }

    private IEntity GetItem(string id)
    {
      IEntity ditem = Store.FindOne(id);
      if (ditem == null)
      {
        throw new ApplicationException($"El registro a actualizar no existe.");
      }

      return ditem;
    }

    private async Task<IEntity> GetItemAsync(string id)
    {
      IEntity ditem = await Store.FindOneAsync(id).ConfigureAwait(false);
      if (ditem == null)
      {
        throw new ApplicationException($"El registro a actualizar no existe.");
      }

      return ditem;
    }
  }
}