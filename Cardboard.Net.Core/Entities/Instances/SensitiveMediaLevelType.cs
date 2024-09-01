using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Instances;

/// <summary>
///     Type for sensitive media detection levels
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum SensitiveMediaLevelType
{
    /// <summary>
    ///     Very low detection sensitivity
    /// </summary>
    [EnumMember(Value = "veryLow")]
    VeryLow,
    /// <summary>
    ///     Low detection sensitivity
    /// </summary>
    [EnumMember(Value = "low")]
    Low,
    /// <summary>
    ///     Medium detection sensitivity
    /// </summary>
    [EnumMember(Value = "medium")]
    Medium,
    /// <summary>
    ///     High detection sensitivity
    /// </summary>
    [EnumMember(Value = "high")]
    High,
    /// <summary>
    ///     Very high detection sensitivity
    /// </summary>
    [EnumMember(Value = "veryHigh")]
    VeryHigh
}