using Microsoft.Extensions.Logging;

namespace Cardboard.Logging;

internal sealed class DefaultLogger : ILogger
{
    private readonly string name;
    private readonly LogLevel minimumLogLevel;
    private readonly object @lock = new();

    public DefaultLogger(string name, LogLevel minimumLogLevel)
    {
        this.name = name;
        this.minimumLogLevel = minimumLogLevel;
    }
    
    public IDisposable? BeginScope<TState>(TState state) 
        where TState : notnull 
        => default;

    public bool IsEnabled(LogLevel logLevel)
        => logLevel >= this.minimumLogLevel && logLevel != LogLevel.None;
    
    public void Log<TState>
    (
        LogLevel logLevel, 
        EventId eventId, 
        TState state, 
        Exception? exception, 
        Func<TState, Exception?, string> formatter
    )
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        lock (this.@lock)
        {
            Console.ForegroundColor = logLevel switch
            {
                LogLevel.Trace => ConsoleColor.Gray,
                LogLevel.Debug => ConsoleColor.Green,
                LogLevel.Information => ConsoleColor.Magenta,
                LogLevel.Warning => ConsoleColor.Yellow,
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Critical => ConsoleColor.DarkRed,
                _ => throw new ArgumentException("Invalid log level specified.", nameof(logLevel))
            };

            Console.Write
            (
                logLevel switch
                {
                    LogLevel.Trace => "[Trace] ",
                    LogLevel.Debug => "[Debug] ",
                    LogLevel.Information => "[Info]  ",
                    LogLevel.Warning => "[Warn]  ",
                    LogLevel.Error => "[Error] ",
                    LogLevel.Critical => "[Crit]  ",
                    _ => "This code path is unreachable."
                }
            );

            Console.ResetColor();

            Console.WriteLine(formatter(state, exception));

            if (exception != null)
            {
                Console.WriteLine($"{exception} : {exception.Message}\n{exception.StackTrace}");
            }
        }
    }
}