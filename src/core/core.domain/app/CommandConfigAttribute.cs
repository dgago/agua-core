using System;

namespace core.domain.app
{
  public enum AuthorizationType
  {
    None = 0,
    Client = 1,
    User = 2,
    // Both = 3
  }

  public enum CommandBehavior
  {
    None = 0,
    Record = 1,
    Action = 2
  }

  [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
  public sealed class CommandConfigAttribute : Attribute
  {
    // See the attribute guidelines at
    //  http://go.microsoft.com/fwlink/?LinkId=85236
    readonly AuthorizationType _type;
    readonly CommandBehavior _behavior;

    // This is a positional argument
    public CommandConfigAttribute(
      AuthorizationType type,
      CommandBehavior behavior)
    {
      this._type = type;
      this._behavior = behavior;
    }

    public AuthorizationType Type
    {
      get { return _type; }
    }

    public CommandBehavior Behavior
    {
      get { return _behavior; }
    }

    // This is a named argument
    // public int NamedInt { get; set; }
  }
}