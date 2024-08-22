using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Cardboard.Net.Entities.Notes;

/// <summary>
/// Represents visibility type
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<VisibilityType>))]
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
