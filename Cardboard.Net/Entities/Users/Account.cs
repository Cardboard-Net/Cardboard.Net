using Cardboard.Net.Rest;
using Newtonsoft.Json;

namespace Cardboard.Net.Entities.Users;

/// <summary>
/// Represents the account information 
/// </summary>
public class Account : User
{
    /// <summary>
    /// The muted words of this account
    /// </summary>
    [JsonIgnore]
    public IReadOnlyList<string> MutedWords
        => this.mutedWords;

    [JsonProperty("mutedWords")] 
    internal List<string> mutedWords = [];

    /// <summary>
    /// The hard muted words of this account
    /// </summary>
    [JsonIgnore]
    public IReadOnlyList<string> HardMutedWords
        => this.hardMutedWords;
    
    [JsonProperty("hardMutedWords")]
    internal List<string> hardMutedWords = [];

    /// <summary>
    /// The email of this account
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; internal set; }
    
    /// <summary>
    /// Whether the email has been verified
    /// </summary>
    [JsonProperty("emailVerified")]
    public bool EmailVerified { get; internal set; }
    
    /// <summary>
    /// Whether the account has unread mentions
    /// </summary>
    [JsonProperty("hasUnreadMentions")]
    public bool HasUnreadMentions { get; internal set; }
    
    /// <summary>
    /// Whether the account has unread announcements
    /// </summary>
    [JsonProperty("hasUnreadAnnouncement")]
    public bool HasUnreadAnnouncement { get; internal set; }
    
    /// <summary>
    /// Whether the account has unread notifications
    /// </summary>
    [JsonProperty("hasUnreadNotification")]
    public bool HasUnreadNotification { get; internal set; }
    
    /// <summary>
    /// Whether the account has an unread antenna
    /// </summary>
    [JsonProperty("hasUnreadAntenna")]
    public bool HasUnreadAntenna { get; internal set; }
    
    /// <summary>
    /// Whether the account has an unread channel
    /// </summary>
    [JsonProperty("hasUnreadChannel")]
    public bool HasUnreadChannel { get; internal set; }
    
    /// <summary>
    /// Whether the account has pending incoming follow requests 
    /// </summary>
    [JsonProperty("hasPendingReceivedFollowRequests")]
    public bool HasIncomingFollowRequests { get; internal set; }
    
    /// <summary>
    /// Claims an achievement
    /// </summary>
    /// <param name="achievement">AchievementType of the achievement to redeem</param>
    /// <returns></returns>
    public Task ClaimAchievementAsync(AchievementType achievement)
        => this.Misskey.ApiClient.SendRequestAsync(Endpoints.SELF_ACHIEVEMENT_CLAIM,
            JsonConvert.SerializeObject(new Achievement { AchievementType = achievement }));
}