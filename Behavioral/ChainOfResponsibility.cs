namespace Behavioral;
// request flows through series of handlers. the handlers can either simply pass it or perform any actions.
public enum LogLevelEnum
{
    Info = 1,
    Warning,
    Error
}
public abstract class Logger
{
    public Logger _next;
    public void SetNext(Logger next)
    {
        _next = next;
    }
    public void Forward(string message, LogLevelEnum logLevel)
    {
        if (_next != null)
            _next.Log(message, logLevel);
    }
    public abstract void Log(string message, LogLevelEnum loglevel);
}
public class InfoLogger : Logger
{
    public override void Log(string message, LogLevelEnum loglevel)
    {
        if (loglevel == LogLevelEnum.Info)
        {
            Console.WriteLine($"{loglevel}: {message}");
        }
        Forward(message, loglevel);
    }
}
public class WarningLogger : Logger
{
    public override void Log(string message, LogLevelEnum loglevel)
    {
        if (loglevel == LogLevelEnum.Warning)
        {
            Console.WriteLine($"{loglevel}: {message}");
        }
        Forward(message, loglevel);
    }
}
public class ErrorLogger : Logger
{
    public override void Log(string message, LogLevelEnum loglevel)
    {
        if (loglevel == LogLevelEnum.Error)
        {
            Console.WriteLine($"{loglevel}: {message}");
        }
        Forward(message, loglevel);

    }
}
public class BaseLogger : Logger
{
    public override void Log(string message, LogLevelEnum loglevel)
    {
        Forward(message, loglevel);
    }
}