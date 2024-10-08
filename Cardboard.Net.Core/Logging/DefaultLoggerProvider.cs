using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace Cardboard.Logging;

internal class DefaultLoggerProvider : ILoggerProvider
{
    private readonly ConcurrentDictionary<string, DefaultLogger> loggers = new(StringComparer.Ordinal);
    private readonly LogLevel minimum;

    public DefaultLoggerProvider(LogLevel minimum = LogLevel.Information)
    {
        this.minimum = minimum;
    }

    public ILogger CreateLogger(string categoryName)
    {
        if (this.loggers.TryGetValue(categoryName, out DefaultLogger? value))
        {
            return value;
        }
        else
        {
            DefaultLogger logger = new(categoryName, this.minimum);

            return this.loggers.AddOrUpdate
            (
                categoryName,
                logger,
                (_, _) => logger
            );
        }
    }
    
    public void Dispose() { }
}