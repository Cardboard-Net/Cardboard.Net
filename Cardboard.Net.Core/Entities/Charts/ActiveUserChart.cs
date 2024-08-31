namespace Cardboard.Charts;

public class ActiveUserChart : IChart
{
    /// <inheritdoc/>
    public ChartType Type { get; internal init; }
    
    /// <summary>
    ///     The amount of users lurking and posting
    /// </summary>
    public IReadOnlyCollection<int> ReadWrite { get; internal init; } = [];
    
    /// <summary>
    ///     The amount of users lurking
    /// </summary>
    public IReadOnlyCollection<int> Read { get; internal init; } = [];
    
    /// <summary>
    ///     The amount of users posting
    /// </summary>
    public IReadOnlyCollection<int> Write { get; internal init; } = [];
    
    /// <summary>
    ///     The amount of users registered within the past week
    /// </summary>
    public IReadOnlyCollection<int> RegisteredPastWeek { get; internal init; } = [];
    
    /// <summary>
    ///     The amount of users registered within the past month
    /// </summary>
    public IReadOnlyCollection<int> RegisteredPastMonth { get; internal init; } = [];
    
    /// <summary>
    ///     The amount of users registered within the past year 
    /// </summary>
    public IReadOnlyCollection<int> RegisteredPastYear { get; internal init; } = [];
    
    /// <summary>
    ///     The amount of users registered prior to the past week
    /// </summary>
    public IReadOnlyCollection<int> RegisteredBeforeWeek { get; internal init; } = [];
    
    /// <summary>
    ///     The amount of users registered prior to the past month
    /// </summary>
    public IReadOnlyCollection<int> RegisteredBeforeMonth { get; internal init; } = [];
    
    /// <summary>
    ///     The amount of users registered prior to the past year
    /// </summary>
    public IReadOnlyCollection<int> RegisteredBeforeYear { get; internal init; } = [];
}