using Newtonsoft.Json;

namespace Cardboard.Net.Entities;

/// <summary>
/// Represents an invite to the instance
/// </summary>
public class Invite
{
    /// <summary>
    /// misskey:id of the invite
    /// </summary>
    [JsonProperty("id", Required = Required.Always)]
#pragma warning disable CS8618
    public string Id { get; protected set; }
#pragma warning restore CS8618

    /// <summary>
    /// Invite code
    /// </summary>
    [JsonProperty("code")]
#pragma warning disable CS8618
    public string Code { get; protected set; }
#pragma warning restore CS8618

    /// <summary>
    /// DateTime representing when the invite expires
    /// </summary>
    [JsonProperty("expiresAt")]
    public DateTime? ExpiresAt { get; protected set; }

    /// <summary>
    /// DateTime representing when the invite was created at
    /// </summary>
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; protected set; }

    /// <summary>
    /// User object representing the creator
    /// </summary>
    [JsonProperty("createdBy")]
#pragma warning disable CS8618
    public User CreatedBy { get; protected set; }
#pragma warning restore CS8618

    [JsonProperty("usedBy")]
#pragma warning disable CS8618
    public User UsedBy { get; protected set; }
#pragma warning restore CS8618

    /// <summary>
    /// DateTime of when the invite was used
    /// </summary>
    [JsonProperty("usedAt")]
    public DateTime? UsedAt { get; protected set; }

    /// <summary>
    /// Whether the invite has been used
    /// </summary>
    [JsonProperty("used")]
    public bool Used { get; protected set; }
}
