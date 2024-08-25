using Newtonsoft.Json;

namespace Cardboard.Net.Entities;

/// <summary>
/// Class representing a misskey role policy
/// </summary>
// TODO: Replace these bools with a bitflag *allowing for serialization & deserialization*...
public class RolePolicy
{
    /// <summary>
    /// Whether the role can see global timeline
    /// </summary>
    [JsonProperty("gtlAvailable")]
    public bool HasGlobalTimeline { get; internal set; }
    
    /// <summary>
    /// Whether the role can see local timeline
    /// </summary>
    [JsonProperty("ltlAvailable")]
    public bool HasLocalTimeline { get; internal set; }
    
    /// <summary>
    /// Whether the role can see bubble timeline
    /// </summary>
    [JsonProperty("btlAvailable")]
    public bool HasBubbleTimeline { get; internal set; }
    
    /// <summary>
    /// Whether the user can post public instead of unlisted
    /// </summary>
    [JsonProperty("canPublicNote")]
    public bool CanPublicNote { get; internal set; }
    
    /// <summary>
    /// The limit of mentions per note
    /// </summary>
    [JsonProperty("mentionLimit")]
    public int MentionLimit { get; internal set; }
    
    /// <summary>
    /// Whether the role can make invites
    /// </summary>
    [JsonProperty("")]
    public bool CanInvite { get; internal set; }
    
    /// <summary>
    /// The amount of invites the role can generate
    /// </summary>
    [JsonProperty("inviteLimit")]
    public int InviteLimit { get; internal set; }
    
    /// <summary>
    /// The invite limit cycle
    /// </summary>
    [JsonProperty("inviteLimitCycle")]
    public int InviteLimitCycle { get; internal set; }
    
    /// <summary>
    /// The expiration time of the invite
    /// </summary>
    /* TODO: Figure out if int is big enough for this, we could probably switch
     * over to a timespan. Just need to figure out how to serialize and
     * deserialize timespans first.
     */
    [JsonProperty("inviteExpirationTime")]
    public int InviteExpirationTime { get; internal set; }
    
    /// <summary>
    /// Whether the role can manage custom emojis
    /// </summary>
    [JsonProperty("canManageCustomEmojis")]
    public bool CanManageCustomEmojis { get; internal set; }
    
    /// <summary>
    /// Whether the role can manage avatar decorations
    /// </summary>
    [JsonProperty("canManageAvatarDecorations")]
    public bool CanManageAvatarDecorations { get; internal set; }
    
    /// <summary>
    /// Whether the role can use note search
    /// </summary>
    [JsonProperty("canSearchNotes")]
    public bool CanSearchNotes { get; internal set; }
    
    /// <summary>
    /// Whether the role can use translator (via deepl)
    /// </summary>
    [JsonProperty("canUseTranslator")]
    public bool CanUseTranslator { get; internal set; }
    
    /// <summary>
    /// Whether the user can hide advertisements.
    /// </summary>
    /*
     * As client developers, it is your responsibility to handle ads. See the
     * comment in Cardboard.Net/Entities/Instance/Ad.cs for more information.
     */
    [JsonProperty("canHideAds")]
    public bool CanHideAds { get; internal set; }
    
    /// <summary>
    /// The capacity of the drive, expressed in mb.
    /// </summary>
    [JsonProperty("driveCapacity")]
    public ulong DriveCapacity { get; internal set; }
    
    /// <summary>
    /// Whether the role is always marked as nsfw
    /// </summary>
    [JsonProperty("alwaysMarkNsfw")]
    public bool AlwaysMarkNsfw { get; internal set; }
    
    /// <summary>
    /// The pinned note limit for the role
    /// </summary>
    [JsonProperty("pinLimit")]
    public int PinLimit { get; internal set; }
    
    /// <summary>
    /// The Antenna limit for the role
    /// </summary>
    [JsonProperty("antennaLimit")]
    public int AntennaLimit { get; internal set; }
    
    /// <summary>
    /// The limit on word mutes
    /// </summary>
    [JsonProperty("wordMuteLimit")]
    public int WordMuteLimit { get; internal set; }
    
    /// <summary>
    /// The limit on webhooks
    /// </summary>
    [JsonProperty("webhookLimit")]
    public int WebhookLimit { get; internal set; }
    
    /// <summary>
    /// The limit on clips
    /// </summary>
    [JsonProperty("clipLimit")]
    public int ClipLimit { get; internal set; }
    
    /// <summary>
    /// The limit on how many notes each clip can contain
    /// </summary>
    [JsonProperty("noteEachClipsLimit")]
    public int ClipNoteLimit { get; internal set; }
    
    /// <summary>
    /// The limit on user lists
    /// </summary>
    [JsonProperty("userListLimit")]
    public int UserListLimit { get; internal set; }
    
    /// <summary>
    /// The limit on how many users can be in a list
    /// </summary>
    [JsonProperty("usersEachUserListsLimit")]
    public int UsersPerListsLimit { get; internal set; }
    
    /// <summary>
    /// The rate limit factor (do not get me started)
    /// </summary>
    [JsonProperty("rateLimitFactor")]
    public int RateLimitFactor { get; internal set; }
 
    /// <summary>
    /// The limit on avatar decorations
    /// </summary>
    [JsonProperty("avatarDecorationLimit")]
    public int AvatarDecorationLimit { get; internal set; }
}