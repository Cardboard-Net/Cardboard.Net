using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class UserAdminInfo
{
    [JsonProperty("email")]
    public string? Email { get; set; }
    
    [JsonProperty("emailVerified")]
    public bool EmailVerified { get; set; }
    
    [JsonProperty("autoAcceptFollowed")]
    public bool AutoAcceptFollow { get; set; }
    
    [JsonProperty("noCrawle")]
    public bool NoCrawle { get; set; }
    
    [JsonProperty("preventAiLearning")]
    public bool PreventAiLearning { get; set; }
    
    [JsonProperty("alwaysMarkNsfw")]
    public bool AlwaysMarkNsfw { get; set; }
    
    [JsonProperty("autoSensitive")]
    public bool AutoSensitive { get; set; }
    
    [JsonProperty("carefulBot")]
    public bool CarefulBot { get; set; }
    
    [JsonProperty("injectFeaturedNote")]
    public bool InjectFeaturedNote { get; set; }
    
    [JsonProperty("receiveAnnouncementEmail")]
    public bool ReceiveAnnouncementEmail { get; set; }
    
    // TODO: Muted words
    
    // TODO: figure out if this is a list of ids
    [JsonProperty("mutedInstances")]
    public string[] MutedInstances { get; set; }
    
    // TODO: notificationReceiveConfig
    
    [JsonProperty("isModerator")]
    public bool IsModerator { get; set; }
    
    [JsonProperty("isSilenced")]
    public bool IsSilenced { get; set; }
    
    [JsonProperty("isSuspended")]
    public bool IsSuspended { get; set; }
    
    [JsonProperty("isHibernated")]
    public bool IsHibernated { get; set; }
    
    // TODO: Figure out if we can DateTime this
    [JsonProperty("lastActiveDate")]
    public string? LastActiveDate { get; set; }
    
    [JsonProperty("moderationNote")]
    public string ModerationNote { get; set; }
    
    [JsonProperty("signins")]
    public Signins[] Signins { get; set; }
    
    [JsonProperty("policies")]
    public RolePolicy Policy { get; set; }
    
    [JsonProperty("roles")]
    public Role[] Roles { get; set; }
    
    [JsonProperty("roleAssigns")]
    public RoleAssigns[] RoleAssigns { get; set; }
}