using System;
using core.domain.services.log;

namespace sts.console
{
  public class ConsoleLogAdapter : ILogAdapter
  {
    public void Debug(string messageTemplate, params object[] propertyValues)
    {
      Console.WriteLine($"{messageTemplate}");
    }

    public void Debug(Exception exception, string messageTemplate, params object[] propertyValues)
    {
      throw new NotImplementedException();
    }

    public void Error(string messageTemplate, params object[] propertyValues)
    {
      Console.WriteLine($"{messageTemplate}");
    }

    public void Error(Exception exception, string messageTemplate, params object[] propertyValues)
    {
      throw new NotImplementedException();
    }

    public void Information(string messageTemplate, params object[] propertyValues)
    {
      Console.WriteLine($"{messageTemplate}");
    }

    public void Information(Exception exception, string messageTemplate, params object[] propertyValues)
    {
      throw new NotImplementedException();
    }

    public void Warning(string messageTemplate, params object[] propertyValues)
    {
      Console.WriteLine($"{messageTemplate}");
    }

    public void Warning(Exception exception, string messageTemplate, params object[] propertyValues)
    {
      throw new NotImplementedException();
    }

    public void Write(LogLevel type, string messageTemplate, params object[] propertyValues)
    {
      throw new NotImplementedException();
    }
  }
}
