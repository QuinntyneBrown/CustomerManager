namespace CustomerManager.Utils
{
    public interface ILoggerProvider
    {
        ILogger CreateLogger(string name);
    }
}
