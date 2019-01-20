using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using core.domain.model;

namespace core.domain.data
{
  public interface IStore<T, K>
    where T : IEntity
  {

    K Create(T ritem);

    Task<K> CreateAsync(T ritem);

    bool Exists(Expression<Func<T, bool>> exp);

    Task<bool> ExistsAsync(Expression<Func<T, bool>> exp);

    IEnumerable<T> Find(Expression<Func<T, bool>> exp, object sortBy = null);

    Results<T> Find(Expression<Func<T, bool>> exp, int pageIndex, int pageSize, object sortBy = null);

    IEnumerable<T> FindAll(object sortBy = null);

    Results<T> FindAll(int pageIndex, int pageSize, object sortBy = null);

    Task<IEnumerable<T>> FindAllAsync(object sortBy = null);

    Task<Results<T>> FindAllAsync(int pageIndex, int pageSize, object sortBy = null);

    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> exp, object sortBy = null);

    Task<Results<T>> FindAsync(Expression<Func<T, bool>> exp, int pageIndex, int pageSize, object sortBy = null);

    T FindOne(K id);

    T FindOne(Expression<Func<T, bool>> exp, object sortBy = null);

    Task<T> FindOneAsync(K id);

    Task<T> FindOneAsync(Expression<Func<T, bool>> exp, object sortBy = null);

    void Remove(K id);

    void Remove(Expression<Func<T, bool>> exp);

    Task RemoveAsync(K id);

    Task RemoveAsync(Expression<Func<T, bool>> exp);

    bool Replace(K id, T ritem);

    Task<bool> ReplaceAsync(K id, T ritem);

  }
}