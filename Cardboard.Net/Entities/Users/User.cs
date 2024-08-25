using Cardboard.Net.Entities.Users;
using Cardboard.Net.Rest;
using Newtonsoft.Json;

namespace Cardboard.Net.Entities;

/// <summary>
/// Class representing a misskey user
/// </summary>
public class User : MisskeyObject
{
    /// <summary>
    /// Optional display name of the current user
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; init; }

    /// <summary>
    /// The username of the current user
    /// </summary>
    [JsonProperty("username")]
    public required string Username { get; init; }

    /// <summary>
    /// The hostname of the current user, null if it's local to us
    /// </summary>
    [JsonProperty("host")]
    public string? Host { get; init; }
    
    /// <summary>
    /// List of fields configurable in the profile
    /// </summary>
    [JsonIgnore]
    public IReadOnlyList<Users.Field> Fields
        => this.fields;

    [JsonProperty("fields")] 
    internal List<Users.Field> fields = [];

    /// <summary>
    /// The url corresponding to this user's avatar
    /// </summary>
    [JsonProperty("avatarUrl")]
    public Uri? AvatarUrl { get; init; }

    /// <summary>
    /// The blurhash for the avatar
    /// </summary>
    [JsonProperty("avatarBlurhash")]
    public string AvatarBlurhash { get; internal set; }
    
    /// <summary>
    /// List of avatar decorations in the profile
    /// </summary>
    [JsonIgnore]
    public IReadOnlyList<UserDecoration> AvatarDecorations
        => this.avatarDecorations;

    [JsonProperty("decorations")] 
    internal List<UserDecoration> avatarDecorations = [];
    
    /// <summary>
    /// The AP url, aka https://transfem.social/@puppygirlhornypost
    /// </summary>
    [JsonProperty("url")]
    public Uri ApUrl { get; internal set; }
    
    /// <summary>
    /// The ID based url, aka https://transfem.social/users/9py50pj1e9wy0033
    /// </summary>
    [JsonProperty("uri")]
    public Uri InstanceUrl { get; internal set; }
    
    /// <summary>
    /// Whether the user is an administrator
    /// </summary>
    [JsonProperty("isAdministrator")]
    public bool IsAdministrator { get; init; }

    /// <summary>
    /// Whether the user is a moderator
    /// </summary>
    [JsonProperty("isModerator")]
    public bool IsModerator { get; init; }

    /// <summary>
    /// Whether the user is silenced
    /// </summary>
    [JsonProperty("isSilenced")]
    public bool IsSilenced { get; internal set; }

    /// <summary>
    /// Whether the user is suspended
    /// </summary>
    [JsonProperty("isSuspended")]
    public bool IsSuspended { get; internal set; }
    
    /// <summary>
    /// Whether the user has indexing enabled
    /// </summary>
    [JsonProperty("noindex")]
    public bool NoIndex { get; init; }
    
    /// <summary>
    /// Whether the user is a bot
    /// </summary>
    [JsonProperty("isBot")]
    public bool IsBot { get; init; }

    /// <summary>
    /// Whether the user is a cat
    /// </summary>
    [JsonProperty("isCat")]
    public bool IsCat { get; init; }

    /// <summary>
    /// Whether the user speaks like a cat
    /// </summary>
    [JsonProperty("speakAsCat")]
    public bool IsCatSpeak { get; init; }
    
    /// <summary>
    /// The amount of users this user follows, 0 if private
    /// </summary>
    [JsonProperty("followingCount")]
    public int FollowingCount { get; init; }

    /// <summary>
    /// The amount of users following this user
    /// </summary>
    [JsonProperty("followersCount")]
    public int FollowerCount { get; init; }
    
    /// <summary>
    /// The visibility setting for following
    /// </summary>
    [JsonProperty("followingVisibility")]
    public FollowVisibilityType FollowingVisibility { get; init; }

    /// <summary>
    /// The visibility setting for followers
    /// </summary>
    [JsonProperty("followerVisibility")]
    public FollowVisibilityType FollowerVisibility { get; init; }

    /// <summary>
    /// Sends a follow request to the user stored
    /// </summary>
    /// <param name="withReplies">Whether to display replies on timeline</param>
    public async Task SendFollowRequestAsync(bool withReplies = false)
        => await this.Misskey.ApiClient.SendRequestAsync(Endpoints.FOLLOW_CREATE, 
            JsonConvert.SerializeObject(new { userId = this.Id, withReplies = withReplies }));

    /// <summary>
    /// Silence a user, preventing them from showing up without being directly looked for.
    /// </summary>
    public async Task SilenceUserAsync() 
    {
        if (this.IsSuspended) return;
        
        this.IsSilenced = true;
        
        // TODO: Throw an exception if we do not have permission, *BEFORE* sending the request
        await this.Misskey.ApiClient.SilenceUserAsync(this.Id);
    }

    /// <summary>
    /// Unsilence a user, allowing for the user to be found in feeds.
    /// </summary>
    public async Task UnsilenceUserAsync() 
    {
        if (!this.IsSilenced) return;
        
        this.IsSilenced = false;
        
        // TODO: Throw an exception if we do not have permission, *BEFORE* sending the request
        await this.Misskey.ApiClient.UnsilenceUserAsync(this.Id);
    }

    /// <summary>
    /// Suspend a user from being able to use the host server altogether, showing up in feeds, or otherwise creating objects.
    /// </summary>
    public async Task SuspendUserAsync()
    {
        if (this.IsSuspended) return;

        this.IsSuspended = true;
        
        // TODO: Throw an exception if we do not have permission, *BEFORE* sending the request
        await this.Misskey.ApiClient.SuspendUserAsync(this.Id);
    }

    /// <summary>
    /// Unsuspend a user, allowing them to login to misskey, show up in feeds, use the drive, etc.
    /// </summary>
    public async Task UnsuspendUserAsync()
    {
        if (!this.IsSuspended) return;

        this.IsSuspended = false;
        
        // TODO: Throw an exception if we do not have permission, *BEFORE* sending the request
        await this.Misskey.ApiClient.UnsuspendUserAsync(this.Id);
    }
}