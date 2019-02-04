namespace core.domain.services
{
  public class CommandResult
  {
    public CommandResult(string id, string message)
    {
      Id = id;
      Message = message;
    }

    public CommandResult(string id)
    {
      Id = id;
    }

    public string Id { get; }

    public string Message { get; }
  }
}