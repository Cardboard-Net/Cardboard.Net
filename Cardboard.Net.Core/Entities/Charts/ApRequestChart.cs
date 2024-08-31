namespace Cardboard.Charts;

public class ApRequestChart : IChart
{
    /// <inheritdoc/>
    public ChartType Type { get; internal init; }
    
    /// <summary>
    ///     The amount of deliver jobs failed
    /// </summary>
    public IReadOnlyCollection<int> DeliverFailed { get; internal init; } = [];
    
    /// <summary>
    ///     The amount of deliver jobs successful
    /// </summary>
    public IReadOnlyCollection<int> DeliveredSucceeded { get; internal init; } = [];
    
    /// <summary>
    ///     The amount of inbox jobs received
    /// </summary>
    public IReadOnlyCollection<int> InboxReceived { get; internal init; } = [];
}