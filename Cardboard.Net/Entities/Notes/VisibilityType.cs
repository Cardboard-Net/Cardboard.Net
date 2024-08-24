using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Net.Entities.Notes;

/// <summary>
/// Represents visibility type
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum VisibilityType
{
    /// <summary>
    /// Public, no restriction
    /// </summary>
    [EnumMember(Value = "public")]
    Public,
    /// <summary>
    /// Home timeline, unlisted on *oma
    /// </summary>
    [EnumMember(Value = "home")]
    Home,
    /// <summary>
    /// Followers only
    /// </summary>
    [EnumMember(Value = "followers")]
    Followers,
    /// <summary>
    /// Direct message
    /// </summary>
    [EnumMember(Value = "specified")]
    Specified
}