using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class RolePolicy
{
    [JsonProperty("gtlAvailable")]
    public bool GtlAvailable { get; set; }
    
    [JsonProperty("ltlAvailable")]
    public bool LtlAvailable { get; set; }
    
    [JsonProperty("btlAvailable")]
    public bool BtlAvailable { get; set; }
    
    [JsonProperty("canPublicNote")]
    public bool CanPublicNote { get; set; }
    
    [JsonProperty("mentionLimit")]
    public int MentionLimit { get; set; }
    
    [JsonProperty("canInvite")]
    public bool CanInvite { get; set; }
    
    [JsonProperty("inviteLimit")]
    public int InviteLimit { get; set; }
    
    [JsonProperty("inviteLimitCycle")]
    public int InviteLimitCycle { get; set; }
    
    [JsonProperty("inviteExpirationTime")]
    public int InviteExpirationTime { get; set; }
    
    [JsonProperty("canManageCustomEmojis")]
    public bool ManageCustomEmojis { get; set; }
    
    [JsonProperty("canManageAvatarDecorations")]
    public bool ManageAvatarDecorations { get; set; }
    
    [JsonProperty("canSearchNotes")]
    public bool SearchNotes { get; set; }
    
    [JsonProperty("canUseTranslator")]
    public bool UseTranslator { get; set; }
    
    [JsonProperty("canHideAds")]
    public bool HideAds { get; set; }
    
    [JsonProperty("driveCapacityMb")]
    public ulong DriveCapacityMb { get; set; }
    
    [JsonProperty("alwaysMarkNsfw")]
    public bool AlwaysMarkNsfw { get; set; }
    
    [JsonProperty("pinLimit")]
    public int PinLimit { get; set; }
    
    [JsonProperty("antennaLimit")]
    public int AntennaLimit { get; set; }
    
    [JsonProperty("wordMuteLimit")]
    public int WordMuteLimit { get; set; }
    
    [JsonProperty("webhookLimit")]
    public int WebhookLimit { get; set; }
    
    [JsonProperty("clipLimit")]
    public int ClipLimit { get; set; }

    [JsonProperty("noteEachClipsLimit")]
    public int ClipNoteLimit { get; set; }
    
    [JsonProperty("userListLimit")]
    public int UserListLimit { get; set; }
    
    [JsonProperty("userEachUserListsLimit")]
    public int UserListUserLimit { get; set; }
    
    [JsonProperty("rateLimitFactor")]
    public int RateLimitFactor { get; set; }
    
    [JsonProperty("avatarDecorationLimit")]
    public int AvatarDecorationLimit { get; set; }
}