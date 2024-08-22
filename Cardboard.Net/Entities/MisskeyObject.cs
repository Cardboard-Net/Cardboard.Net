using System.Text.Json.Serialization;
using Cardboard.Net.Clients;

namespace Cardboard.Net.Entities;

/// <summary>
/// Represents a misskey object
/// </summary>
public abstract class MisskeyObject
{
    /// <summary>
    /// The misskey:id of the current object
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }
    
    /// <summary>
    /// Gets the client instance this object is tied to
    /// </summary>
    [JsonIgnore]
    internal BaseMisskeyClient Misskey { get; set; }
}
