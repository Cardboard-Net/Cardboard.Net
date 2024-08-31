using Cardboard.Users;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

// TODO: finish later
internal class SelfUser : User
{
    [JsonProperty("hasUnreadNotifications")]
    public bool HasUnreadNotifications { get; set; }
    
    [JsonProperty("hasPendingReceivedFollowRequest")]
    public bool HasPendingFollowRequests { get; set; }
    
    [JsonProperty("unreadNotificationsCount")]
    public int UnreadNotificationsCount { get; set; }
    
    [JsonProperty("achievements")]
    public Achievement[] Achievements { get; set; }
    
    [JsonProperty("loggedInDays")]
    public int LoggedInDays { get; set; }
    
    [JsonProperty("policies")]
    public RolePolicy Policies { get; set; }
    
    [JsonProperty("email")]
    public string? Email { get; set; }
    
    [JsonProperty("emailVerified")]
    public bool? EmailVerified { get; set; }
    
    [JsonProperty("securityKeysList")]
    public SecurityKey[] SecurityKeys { get; set; }
}

internal class SecurityKey
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("lastUsed")]
    public DateTime LastUsed { get; set; }
}

internal class Achievement
{
    [JsonProperty("name")]
    public AchievementType AchievementType { get; set; }
    
    [JsonProperty("unlockedAt")]
    public ulong UnlockedAt { get; set; }
}