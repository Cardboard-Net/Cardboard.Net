using Microsoft.Extensions.Logging;

namespace Cardboard.Logging;

public static class LoggerEvents
{
    /// <summary>
    ///     Misc events
    /// </summary>
    public static EventId Misc { get; } = new EventId(100, "Cardboard.NET");
    
    /// <summary>
    ///     Login event (initialization of self user)
    /// </summary>
    public static EventId Login { get; } = new EventId(101, nameof(Login));

    /// <summary>
    ///     Events emitted when rest processing fails
    /// </summary>
    public static EventId RestError { get; } = new EventId(102, nameof(RestError));
    
    /// <summary>
    ///     Events containing raw payloads, as they're received from Misskey's REST API.
    /// </summary>
    public static EventId RestRx { get; } = new EventId(103, "REST ↓");

    /// <summary>
    ///     Events containing raw payloads, as they're sent to Misskey's REST API.
    /// </summary>
    public static EventId RestTx { get; } = new EventId(104, "REST ↑");
}