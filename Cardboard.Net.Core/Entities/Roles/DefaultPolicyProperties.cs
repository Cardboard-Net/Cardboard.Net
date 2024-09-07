namespace Cardboard.Net.Core.Entities.Roles;

public class DefaultPolicyProperties
{
    /// <summary>
    ///     Whether global timeline is available
    /// </summary>
    public bool GlobalTimelineAvailable { get; set; }
    
    /// <summary>
    ///     Whether local timeline is available
    /// </summary>
    public bool LocalTimelineAvailable { get; set; }
    
    /// <summary>
    ///     Whether bubble timeline is available
    /// </summary>
    public bool BubbleTimelineAvailable { get; set; }
    
    /// <summary>
    ///     Whether users can post public notes
    /// </summary>
    public bool CanPublicNote { get; set; }
    
    /// <summary>
    ///     The maximum amount of mentioned users in a note
    /// </summary>
    public int MentionLimit { get; set; }
    
    /// <summary>
    ///     Whether users can create invites
    /// </summary>
    public bool CanInvite { get; set; }
    
    /// <summary>
    ///     The invite limit for the instance
    /// </summary>
    public int InviteLimit { get; set; }
    
    /// <summary>
    ///     The invite limit cycle
    /// </summary>
    public int InviteLimitCycle { get; set; }
    
    /// <summary>
    ///     The expiration time for invites
    /// </summary>
    public int InviteExpirationTime { get; set; }
    
    /// <summary>
    ///     Whether users can manage custom emojis
    /// </summary>
    public bool ManageCustomEmojis { get; set; }
    
    /// <summary>
    ///     Whether users can manage avatar decorations
    /// </summary>
    public bool ManageAvatarDecorations { get; set; }

    /// <summary>
    ///     Whether users can use note search
    /// </summary>
    public bool SearchNotes { get; set; }
    
    /// <summary>
    ///     Whether users can use the translator service (Deepl is the only
    /// supported provider, it costs money per translation)
    /// </summary>
    public bool UseTranslator { get; set; }
    
    /// <summary>
    ///     Whether users can hide ads
    /// </summary>
    public bool HideAds { get; set; }
    
    /// <summary>
    ///     The maximum drive capacity in megabytes
    /// </summary>
    public ulong DriveCapacityMb { get; set; }
    
    /// <summary>
    ///     Whether everything's always marked nsfw
    /// </summary>
    public bool AlwaysMarkNsfw { get; set; }
    
    /// <summary>
    ///     The maximum amount of notes a user can pin to their profile
    /// </summary>
    public int PinLimit { get; set; }
    
    /// <summary>
    ///     The maximum amount of antennas a user can create
    /// </summary>
    public int AntennaLimit { get; set; }
    
    /// <summary>
    ///     The maximum amount of word mutes a user can create
    /// </summary>
    public int WordMuteLimit { get; set; }
    
    /// <summary>
    ///     The maximum amount of webhooks a user can create
    /// </summary>
    public int WebhookLimit { get; set; }
    
    /// <summary>
    ///     The maximum amount of clips a user can create
    /// </summary>
    public int ClipLimit { get; set; }
    
    /// <summary>
    ///     The maximum amount of notes each clip can contain
    /// </summary>
    public int ClipNoteLimit { get; set; }
    
    /// <summary>
    ///     The maximum amount of user lists a user can create
    /// </summary>
    public int UserListLimit { get; set; }
    
    /// <summary>
    ///     The maximum amount of users each user list can contain
    /// </summary>
    public int UserListUserLimit { get; set; }
    
    /// <summary>
    ///     The rate limit factor
    /// </summary>
    public int RateLimitFactor { get; set; }
    
    /// <summary>
    ///     The maximum amount of avatar decorations a user can display
    /// </summary>
    public int AvatarDecorationLimit { get; set; }
}