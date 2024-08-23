using System.Text.Json;
using System.Text.Json.Serialization;
using Cardboard.Net.Entities.Users;
using Cardboard.Net.Rest;

namespace Cardboard.Net.Entities;

/// <summary>
/// Class representing a misskey user
/// </summary>
public class User : MisskeyObject
{
    /// <summary>
    /// Optional display name of the current user
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// The username of the current user
    /// </summary>
    [JsonPropertyName("username")]
    public required string Username { get; init; }

    /// <summary>
    /// The hostname of the current user, null if it's local to us
    /// </summary>
    [JsonPropertyName("host")]
    public string? Host { get; init; }
    
    /// <summary>
    /// List of fields configurable in the profile
    /// </summary>
    [JsonPropertyName("fields")]
    // [JsonProperty("mentions", NullValueHandling = NullValueHandling.Ignore)]
    // TODO: Figure out the text.json equiv of internal List<Users.Field> _Fields = [];
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public List<Users.Field> _Fields {get; init;}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    //[JsonIgnore]
    //public IReadOnlyList<Users.Field> Fields
    //=> this.Fields;

    /// <summary>
    /// The url corresponding to this user's avatar
    /// </summary>
    [JsonPropertyName("avatarUrl")]
    public Uri? AvatarURL { get; init; }

    /// <summary>
    /// Whether the user is an administrator
    /// </summary>
    [JsonPropertyName("isAdministrator")]
    public bool IsAdministrator { get; init; }

    /// <summary>
    /// Whether the user is a moderator
    /// </summary>
    [JsonPropertyName("isModerator")]
    public bool IsModerator { get; init; }

    /// <summary>
    /// Whether the user is silenced
    /// </summary>
    [JsonPropertyName("isSilenced")]
    public bool IsSilenced { get; init; }

    /// <summary>
    /// Whether the user has indexing enabled
    /// </summary>
    [JsonPropertyName("noindex")]
    public bool NoIndex { get; init; }
    
    /// <summary>
    /// Whether the user is a bot
    /// </summary>
    [JsonPropertyName("isBot")]
    public bool IsBot { get; init; }

    /// <summary>
    /// Whether the user is a cat
    /// </summary>
    [JsonPropertyName("isCat")]
    public bool IsCat { get; init; }

    /// <summary>
    /// Whether the user speaks like a cat
    /// </summary>
    [JsonPropertyName("speakAsCat")]
    public bool IsCatSpeak { get; init; }

    /// <summary>
    /// The amount of users this user follows, 0 if private
    /// </summary>
    [JsonPropertyName("followingCount")]
    public int FollowingCount { get; init; }

    /// <summary>
    /// The amount of users following this user
    /// </summary>
    [JsonPropertyName("followersCount")]
    public int FollowerCount { get; init; }
    
    /// <summary>
    /// The visibility setting for following
    /// </summary>
    [JsonPropertyName("followingVisibility")]
    public FollowVisibilityType FollowingVisibility { get; init; }

    /// <summary>
    /// The visibility setting for followers
    /// </summary>
    [JsonPropertyName("followerVisibility")]
    public FollowVisibilityType FollowerVisibility { get; init; }

    /// <summary>
    /// Sends a follow request to the user stored
    /// </summary>
    /// <param name="withReplies">Whether to display replies on timeline</param>
    public async Task SendFollowRequestAsync(bool withReplies = false)
        => await this.Misskey.ApiClient.SendRequestAsync(Endpoints.FOLLOW_CREATE, 
            JsonSerializer.Serialize(new { userId = this.Id, withReplies = withReplies }));
}