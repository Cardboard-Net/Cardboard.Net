namespace Cardboard.Charts;

public interface IChart
{
    /// <summary>
    ///     Determines the interval in which this chart was polled over
    /// </summary>
    ChartType Type { get; }
}