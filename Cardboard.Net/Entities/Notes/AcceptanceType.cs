using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Net.Entities.Notes;

/// <summary>
/// Reaction acceptance
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum AcceptanceType
{
    /// <summary>
    /// Disables custom reacts
    /// </summary>
    [EnumMember(Value = "likeOnly")]
    LikeOnly,
    /// <summary>
    /// Disables custom reacts for remote instances only
    /// </summary>
    [EnumMember(Value = "likeOnlyForRemote")]
    LikeOnlyForRemote,
    /// <summary>
    /// Disables sensitive reacts
    /// </summary>
    [EnumMember(Value = "nonSensitiveOnly")]
    NonSensitiveOnly,
    /// <summary>
    /// Disables sensitive reacts for local only, while disabling custom 
    /// reacts for remote
    /// </summary>
    [EnumMember(Value = "nonSensitiveOnlyForLocalLikeOnlyForRemote")]
    NonSensitiveOnlyForLocalLikeOnlyForRemote
}
