using System.Runtime.Serialization;

namespace Cardboard.Charts;

/// <summary>
/// Represents chart type (day, or hour)
/// </summary>
public enum ChartType
{
    /// <summary>
    /// Daily polling interval for the chart
    /// </summary>
    [EnumMember(Value = "day")]
    Day,
    /// <summary>
    /// Hourly polling interval for the chart
    /// </summary>
    [EnumMember(Value = "hour")]
    Hour
}