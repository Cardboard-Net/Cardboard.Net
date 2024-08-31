namespace Cardboard.Charts;

public class DriveChart : IChart
{
    /// <inheritdoc/>
    public ChartType Type { get; internal init; }

    /// <summary>
    ///     The local drive chart
    /// </summary>
    public GenericDriveChart Local { get; internal init; } = new GenericDriveChart();
    
    /// <summary>
    ///     The remote drive chart (aggregate of all remote instances)
    /// </summary>
    public GenericDriveChart Remote { get; internal init; } = new GenericDriveChart();
}