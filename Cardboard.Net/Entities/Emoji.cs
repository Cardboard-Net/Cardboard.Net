using Newtonsoft.Json;

namespace Cardboard.Net.Entities;

/// <summary>
/// Class representing a misskey emoji
/// </summary>
public class Emoji : MisskeyObject
{
    /// <summary>
    /// List of aliases this emoji is known by
    /// </summary>
    [JsonIgnore]
    public IReadOnlyList<string> Aliases
        => this.aliases;

    [JsonProperty("aliases")]
    internal List<string> aliases = [];
    
    /// <summary>
    /// The name of this emoji
    /// </summary>
    [JsonProperty("name")]
    public required string Name { get; init; }
    
    /// <summary>
    /// The category this emoji is under if there is any
    /// </summary>
    [JsonProperty("category")]
    public string? Category { get; init; }
    
    /// <summary>
    /// The host this emoji is from (null if local)
    /// </summary>
    [JsonProperty("host")]
    public string? Host { get; init; }
    
    /// <summary>
    /// The url corresponding to the emoji
    /// </summary>
    [JsonProperty("url")]
    public required Uri Url { get; init; }
    
    /// <summary>
    /// The license of the emoji if there is one
    /// </summary>
    [JsonProperty("license")]
    public string? License { get; init; }
    
    /// <summary>
    /// Whether the emoji is marked as sensitive
    /// </summary>
    [JsonProperty("isSensitive")]
    public bool IsSensitive { get; init; }
    
    /// <summary>
    /// Whether the emoji is only displayable locally
    /// </summary>
    [JsonProperty("localOnly")]
    public bool IsLocalOnly { get; init; }

    /// <summary>
    /// A list of roles that can use this emoji as a reaction
    /// </summary>
    [JsonIgnore]
    public IReadOnlyList<string> AllowedRoleIds
        => this.allowedRoleIds;
    
    [JsonProperty("roleIdsThatCanBeUsedThisEmojiAsReaction")]
    internal List<string> allowedRoleIds = [];
}