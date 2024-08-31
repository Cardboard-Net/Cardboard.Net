namespace Cardboard.Charts;

public class UsersChart : IChart
{
    /// <inheritdoc/>
    public ChartType Type { get; internal init; }

    /// <summary>
    ///     Users local to us
    /// </summary>
    public GenericChart Local { get; internal init; } = new GenericChart();
    
    /// <summary>
    ///     Aggregate amount of users from all federated servers
    /// </summary>
    public GenericChart Remote { get; internal init; } = new GenericChart();
}