using Cardboard.Net.Entities.Users;
using Cardboard.Net.Rest;
using Cardboard.Users;
using Newtonsoft.Json;

namespace Cardboard.Net.Entities;

/// <summary>
/// Class representing Misskey's User
/// </summary>
public class User : UserLite
{
    /// <summary>
    /// List of fields configurable in the profile
    /// </summary>
    [JsonIgnore]
    public IReadOnlyList<Users.Field> Fields
        => this.fields;

    [JsonProperty("fields")] 
    internal List<Users.Field> fields = [];

    /// <summary>
    /// A list of read-only pinned notes. Pin more through the note function Note.pinAsync().
    /// </summary>
    [JsonIgnore]
    public IReadOnlyList<Note> PinnedNotes
        => this.pinnedNotes;

    [JsonProperty("pinnedNotes")]
    internal List<Note> pinnedNotes = [];
    
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
    /// Whether the user is suspended
    /// </summary>
    [JsonProperty("isSuspended")]
    public bool IsSuspended { get; internal set; }
    
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
    [JsonProperty("followersVisibility")]
    public FollowVisibilityType FollowersVisibility { get; init; }

    /// <summary>
    /// The current roles of the user
    /// </summary>
    [JsonIgnore]
    public IReadOnlyList<RoleLite> Roles
        => this.roles;
    
    [JsonProperty("roles")]
    internal List<RoleLite> roles = [];
    
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
    /// <returns>void</returns>
    /// <param name="selfsilence">overrides default behavior (throwing an exception) to allow user to silence itself</param>
    public async Task SilenceUserAsync(bool selfsilence = false) {
        if (this.IsSuspended) return;
        
        // TODO: Throw an exception if we do not have permission, *BEFORE* sending the request
        await this.Misskey.ApiClient.SilenceUserAsync(this.Id, selfsilence);
        
        this.IsSilenced = true;
    }

    /// <summary>
    /// Unsilence a user, allowing for the user to be found in feeds.
    /// </summary>
    /// <returns>void</returns>
    public async Task UnsilenceUserAsync() {
        if (!this.IsSilenced) return;
        
        // TODO: Throw an exception if we do not have permission, *BEFORE* sending the request
        await this.Misskey.ApiClient.UnsilenceUserAsync(this.Id);
        
        this.IsSilenced = false;
    }

    /// <summary>
    /// Suspend a user from being able to use the host server altogether, showing up in feeds, or otherwise creating objects.
    /// </summary>
    /// <param name="selfsuspend">overrides default behavior (throwing an exception) to allow user to suspend itself</param> 
    public async Task SuspendUserAsync(bool selfsuspend = false)
    {
        if (this.IsSuspended) return;

        // TODO: Throw an exception if we do not have permission, *BEFORE* sending the request
        await this.Misskey.ApiClient.SuspendUserAsync(this.Id, selfsuspend);
        
        this.IsSuspended = true;
    }

    /// <summary>
    /// Unsuspend a user, allowing them to login to misskey, show up in feeds, use the drive, etc.
    /// </summary>
    public async Task UnsuspendUserAsync()
    {
        if (!this.IsSuspended) return;
        
        // TODO: Throw an exception if we do not have permission, *BEFORE* sending the request
        await this.Misskey.ApiClient.UnsuspendUserAsync(this.Id);
        
        this.IsSuspended = false;
    }

    /// <summary>
    /// Gets a list of ips for this user
    /// </summary>
    /// <returns></returns>
    public async Task<IReadOnlyList<AdminUserIp>> GetIpsAsync()
        => await this.Misskey.ApiClient.GetUserIpsAsync(this.Id);

    /// <summary>
    /// Deletes the current user
    /// </summary>
    /// <param name="selfdelete">overrides default behavior (throwing an exception) to allow user to delete itself</param>
    public async Task DeleteAsync(bool selfdelete = false)
        => await this.Misskey.ApiClient.DeleteUserAsync(this.Id, selfdelete);
}