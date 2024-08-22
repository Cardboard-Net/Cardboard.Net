using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Cardboard.Net.Entities.Users;

/// <summary>
/// Represents the status of a user
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<StatusType>))]
public enum StatusType
{
    /// <summary>
    /// Unknown
    /// </summary>
    [EnumMember(Value = "unknown")]
    Unknown,
    /// <summary>
    /// Online
    /// </summary>
    [EnumMember(Value = "online")]
    Online,
    /// <summary>
    /// Active
    /// </summary>
    [EnumMember(Value = "active")]
    Active,
    /// <summary>
    /// Offline
    /// </summary>
    [EnumMember(Value = "offline")]
    Offline
}