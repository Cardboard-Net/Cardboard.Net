using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Net.Entities;

/// <summary>
/// Class representing relay status
/// </summary>
public class Relay : MisskeyObject
{
    [JsonProperty("inbox")]
    public required Uri Inbox { get; init; }
    [JsonProperty("status")]
    public required RelayStatusType Status { get; init; }
}

/// <summary>
/// The status for a relay
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum RelayStatusType
{
    /// <summary>
    /// Default state, requesting
    /// </summary>
    [EnumMember(Value = "requesting")]
    Requesting,
    /// <summary>
    /// Relay accepted
    /// </summary>
    [EnumMember(Value = "accepted")]
    Accepted,
    /// <summary>
    /// Relay rejected
    /// </summary>
    [EnumMember(Value = "rejected")]
    Rejected
}