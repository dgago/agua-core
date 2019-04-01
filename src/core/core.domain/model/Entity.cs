using core.domain.extensions;

namespace core.domain.model
{
  public abstract class Entity : IEntity
  {
    public Entity(string id, uint version = 0)
    {
      if(id == null)
      {
        Version = version.Zero(nameof(version));
      }
      else
      {
        Version = version.NotZero(nameof(version));
      }

      Id = id;
    }

    public virtual string Id { get; protected set; }

    public uint Version { get; protected set; }

    public static bool operator !=(Entity a, Entity b)
    {
      return !(a == b);
    }

    public static bool operator ==(Entity a, Entity b)
    {
      if(ReferenceEquals(a, null) && ReferenceEquals(b, null))
      {
        return true;
      }

      if(ReferenceEquals(a, null) || ReferenceEquals(b, null))
      {
        return false;
      }

      return a.Equals(b);
    }

    public override bool Equals(object obj)
    {
      Entity other = obj as Entity;

      if(ReferenceEquals(other, null))
      {
        return false;
      }

      if(ReferenceEquals(this, other))
      {
        return true;
      }

      if(GetType() != other.GetType())
      {
        return false;
      }

      if(Id == null || other.Id == null)
      {
        return false;
      }

      return Id == other.Id;
    }

    public override int GetHashCode()
    {
      return (GetType().Name + Id).GetHashCode();
    }
  }
}