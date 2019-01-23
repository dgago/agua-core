using System;

namespace core.domain.services.log
{
  public enum LogLevel
  {
    Verbose,
    Debug,
    Information,
    Warning,
    Error,
  }

  public interface ILogAdapter
  {
    void Write(LogLevel type, string messageTemplate, params object[] propertyValues);

    void Information(string messageTemplate, params object[] propertyValues);

    void Warning(string messageTemplate, params object[] propertyValues);

    void Error(string messageTemplate, params object[] propertyValues);

    void Debug(string messageTemplate, params object[] propertyValues);

    void Information(Exception exception, string messageTemplate, params object[] propertyValues);

    void Warning(Exception exception, string messageTemplate, params object[] propertyValues);

    void Error(Exception exception, string messageTemplate, params object[] propertyValues);

    void Debug(Exception exception, string messageTemplate, params object[] propertyValues);
  }
}