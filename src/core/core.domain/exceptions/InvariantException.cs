using System;

namespace core.domain.exceptions
{
  public class InvariantException : ApplicationException
  {
    public string Code { get; set; }

    public InvariantException(string code, string message)
      : base(message)
    {
      this.Code = code;
    }

    public InvariantException(string code, string message, Exception ex)
      : base(message, ex)
    {
      this.Code = code;
    }
  }
}