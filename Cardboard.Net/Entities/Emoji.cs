using System.Text.Json.Serialization;

namespace Cardboard.Net.Entities;

/// <summary>
/// Class representing a misskey emoji
/// </summary>
public class Emoji : MisskeyObject
{
    /// <summary>
    /// List of aliases this emoji is known by
    /// </summary>
    [JsonPropertyName("aliases")]
    public List<string>? Aliases { get; init; }
    
    /// <summary>
    /// The name of this emoji
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    
    /// <summary>
    /// The category this emoji is under if there is any
    /// </summary>
    [JsonPropertyName("category")]
    public string? Category { get; init; }
    
    /// <summary>
    /// The host this emoji is from (null if local)
    /// </summary>
    [JsonPropertyName("host")]
    public string? Host { get; init; }
    
    /// <summary>
    /// The url corresponding to the emoji
    /// </summary>
    [JsonPropertyName("url")]
    public required Uri Url { get; init; }
    
    /// <summary>
    /// The license of the emoji if there is one
    /// </summary>
    [JsonPropertyName("license")]
    public string? License { get; init; }
    
    /// <summary>
    /// Whether the emoji is marked as sensitive
    /// </summary>
    [JsonPropertyName("isSensitive")]
    public bool IsSensitive { get; init; }
    
    /// <summary>
    /// Whether the emoji is only displayable locally
    /// </summary>
    [JsonPropertyName("localOnly")]
    public bool IsLocalOnly { get; init; }
    
    /// <summary>
    /// A list of roles that can use this emoji as a reaction
    /// </summary>
    [JsonPropertyName("roleIdsThatCanBeUsedThisEmojiAsReaction")]
    public List<string>? AllowedRoleIds { get; init; }
}