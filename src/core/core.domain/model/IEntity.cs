namespace core.domain.model
{
  public interface IEntity
  {
    string Id { get; }

    uint Version { get; }

    bool Equals(object obj);

    int GetHashCode();
  }
}