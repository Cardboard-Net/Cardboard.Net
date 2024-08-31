namespace Cardboard.Charts;

public class FederationChart : IChart
{
    /// <inheritdoc/>
    public ChartType Type { get; }
    
    /// <summary>
    ///     Activity delivered instances
    /// </summary>
    public IReadOnlyCollection<int> DeliveredInstances { get; internal init; } = [];
    
    /// <summary>
    ///     Activity received instances
    /// </summary>
    public IReadOnlyCollection<int> ReceivedInstances { get; internal init; } = [];

    /// <summary>
    ///     Stalled instances (whether they're not responding, defed etc)
    /// </summary>
    public IReadOnlyCollection<int> StalledInstances { get; internal init; } = [];

    /// <summary>
    ///     Subscribed instances
    /// </summary>
    public IReadOnlyCollection<int> SubInstances { get; internal init; } = [];

    /// <summary>
    ///     Published instances
    /// </summary>
    public IReadOnlyCollection<int> PubInstances { get; internal init; } = [];

    /// <summary>
    ///     Aggregate total
    /// </summary>
    public IReadOnlyCollection<int> PubSubInstances { get; internal init; } = [];

    /// <summary>
    ///     Active subscribing instances
    /// </summary>
    public IReadOnlyCollection<int> SubActiveInstances { get; internal init; } = [];

    /// <summary>
    ///     Active publishing instances
    /// </summary>
    public IReadOnlyCollection<int> PubActiveInstances { get; internal init; } = [];
}