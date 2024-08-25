using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Cardboard.Net.Entities.Users;

/// <summary>
/// Class representing Misskey's UserLite
/// </summary>
public class UserLite : MisskeyObject
{
    /// <summary>
    /// Optional display name of the current user
    /// </summary>
    [JsonProperty("name", Required = Required.AllowNull)]
    public string? Name { get; init; }
    
    /// <summary>
    /// The username of the current user
    /// </summary>
    [JsonProperty("username", Required = Required.Always)]
    public required string Username { get; init; }

    /// <summary>
    /// The hostname of the current user, null if it's local to us
    /// </summary>
    [JsonProperty("host", Required = Required.AllowNull)]
    public string? Host { get; init; }
    
    /// <summary>
    /// The url corresponding to this user's avatar
    /// </summary>
    [JsonProperty("avatarUrl", Required = Required.AllowNull)]
    public Uri? AvatarUrl { get; init; }

    /// <summary>
    /// The blurhash for the avatar
    /// </summary>
    [JsonProperty("avatarBlurhash", Required = Required.AllowNull)]
    public string? AvatarBlurhash { get; init; }
    
    /// <summary>
    /// List of avatar decorations in the profile
    /// </summary>
    [JsonIgnore]
    public IReadOnlyList<UserDecoration> AvatarDecorations
        => this.avatarDecorations;

    [JsonProperty("decorations")] 
    internal List<UserDecoration> avatarDecorations = [];
    
    /// <summary>
    /// Whether the user is an administrator
    /// </summary>
    [JsonProperty("isAdministrator")]
    public bool IsAdministrator { get; internal set; }

    /// <summary>
    /// Whether the user is a moderator
    /// </summary>
    [JsonProperty("isModerator")]
    public bool IsModerator { get; internal set; }
    
    /// <summary>
    /// Whether the user is silenced
    /// </summary>
    [JsonProperty("isSilenced")]
    public bool IsSilenced { get; internal set; }
    
    /// <summary>
    /// Whether the user has indexing enabled
    /// </summary>
    [JsonProperty("noindex")]
    public bool NoIndex { get; internal set; }
    
    /// <summary>
    /// Whether the user is a bot
    /// </summary>
    [JsonProperty("isBot")]
    public bool IsBot { get; internal set; }

    /// <summary>
    /// Whether the user is a cat
    /// </summary>
    [JsonProperty("isCat")]
    public bool IsCat { get; internal set; }

    /// <summary>
    /// Whether the user speaks like a cat
    /// </summary>
    [JsonProperty("speakAsCat")]
    public bool IsCatSpeak { get; internal set; }
    
    /// <summary>
    /// The status for the user
    /// </summary>
    [JsonProperty("onlineStatus")]
    public StatusType Status { get; internal set; }
    
    /// <summary>
    /// List of badge roles
    /// </summary>
    [JsonIgnore]
    public IReadOnlyList<BadgeRoles> BadgeRoles
        => this.badgeRoles;
    
    [JsonProperty("badgeRoles")] 
    internal List<BadgeRoles> badgeRoles = [];
    
    /// <summary>
    /// Gets a full user
    /// </summary>
    /// <returns>User or null</returns>
    public async Task<User?> GetUserAsync()
        => await this.Misskey.ApiClient.GetUserAsync(userId: this.Id);
}

/// <summary>
/// A class representing badge roles
/// </summary>
public class BadgeRoles
{
    /// <summary>
    /// The name of the badge
    /// </summary>
    [JsonProperty("name", Required = Required.Always)]
    public string Name { get; init; }
    
    /// <summary>
    /// The optional icon url of the badge
    /// </summary>
    [JsonProperty("iconUrl", Required = Required.AllowNull)]
    public Uri? IconUrl { get; init; }
    
    /// <summary>
    /// The display order of the badge
    /// </summary>
    [JsonProperty("displayOrder", Required = Required.Always)]
    public int DisplayOrder { get; init; }
}