using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Instances;

/// <summary>
///     Type for sensitive media detection
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum SensitiveMediaType
{
    /// <summary>
    ///     No detection
    /// </summary>
    [EnumMember(Value = "none")]
    None,
    /// <summary>
    ///     All (remote and local)
    /// </summary>
    [EnumMember(Value = "all")]
    All,
    /// <summary>
    ///     Local only media detection
    /// </summary>
    [EnumMember(Value = "local")]
    Local,
    /// <summary>
    ///     Remote only media detection
    /// </summary>
    [EnumMember(Value = "remote")]
    Remote
}