using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Charts;

/// <summary>
/// Represents chart type (day, or hour)
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
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