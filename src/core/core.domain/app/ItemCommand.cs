using core.domain.model;

namespace core.domain.app
{
  public abstract class ItemCommand : Command
  {

    public ItemCommand(string id)
    {
      Id = id;
    }

    public string Id { get; set; }

    public IAggregateRoot Item { get; internal set; }

  }
}