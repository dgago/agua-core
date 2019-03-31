using core.domain.extensions;
using core.domain.model;

namespace bi.domain.model.bi_event
{
  internal class BiEventExecutedEvent : DomainEvent
  {
    internal BiEventExecutedEvent(
      string id,
      string result
      )
      : base(DataExtensions.Now())
    {
      this.Id = id.NotNull(nameof(id));
      this.Result = result.NotNull(nameof(result));
    }

    public string Id { get; }

    public string Result { get; }
  }
}