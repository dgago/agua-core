using core.domain.model;

namespace core.domain.data
{
  public abstract class Mapper<TRoot, TData>
    where TRoot : IAggregateRoot
    where TData : IEntity
  {

    public abstract TData MapToData(TRoot item);

    public abstract TRoot MapToDomain(TData item);

  }
}