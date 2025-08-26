namespace Creational;
// shares single instance throught the lifetime
public sealed class Singleton
{
    private static Singleton? _singleton;
    static int count = 0;
    private Singleton() { }
    public static Singleton GetInstance()
    {
        if (_singleton == null)
        {
            count++;
            _singleton = new Singleton();
        }
        return _singleton;
    }
    public static void ShowInstanceCount()
    {
        Console.WriteLine(count);
    }
}
public sealed class Logger
{
    private string filePath;
    private static readonly Lazy<Logger> logger = new Lazy<Logger>(() => new Logger()); // Thread Safe
    private Logger() { this.filePath = "log.txt"; }
    public static Logger instance => logger.Value;
    public void Log(string message)
    {
        Console.WriteLine($"Log : {message} to {filePath}");
    }

}