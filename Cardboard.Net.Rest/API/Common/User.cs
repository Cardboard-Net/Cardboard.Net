using Cardboard.Net.Entities.Users;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class UserLite
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("username")]
    public string Username { get; set; }
    
    [JsonProperty("host")]
    public string? Host { get; set; }
    
    [JsonProperty("avatarUrl")]
    public Uri? AvatarUrl { get; set; }
    
    [JsonProperty("avatarBlurhash")]
    public string? AvatarBlurhash { get; set; }
    
    [JsonProperty("avatarDecorations")]
    public UserDecorations[] AvatarDecorations { get; set; }
    
    [JsonProperty("isAdmin")]
    public bool IsAdmin { get; set; }
    
    [JsonProperty("isModerator")]
    public bool IsModerator { get; set; }
    
    [JsonProperty("isSilenced")]
    public bool IsSilenced { get; set; }
    
    [JsonProperty("noIndex")]
    public bool NoIndex { get; set; }
    
    [JsonProperty("isBot")]
    public bool IsBot { get; set; }
    
    [JsonProperty("isCat")]
    public bool IsCat { get; set; }
    
    [JsonProperty("speakAsCat")]
    public bool SpeakAsCat { get; set; }
    
    [JsonProperty("instance")]
    public UserInstance Instance { get; set; }
    
    //TODO: Add emojis
    
    [JsonProperty("onlineStatus")]
    public StatusType OnlineStatus { get; set; }
    
    [JsonProperty("badgeRoles")]
    public BadgeRole[] BadgeRoles { get; set; }
}

// TODO: Implement
internal class User : UserLite, IUserRelation
{
    [JsonProperty("url")]
    public Uri? Url { get; set; }
    
    [JsonProperty("uri")]
    public Uri? Uri { get; set; }
    
    // TODO: movedTo
    // TODO: alsoKnownAs
    
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
    
    [JsonProperty("updatedAt")]
    public DateTime? UpdatedAt { get; set; }
    
    [JsonProperty("lastFetchedAt")]
    public DateTime? LastFetchedAt { get; set; }
    
    [JsonProperty("bannerUrl")]
    public Uri? BannerUrl { get; set; }
    
    [JsonProperty("bannerBlurhash")]
    public string? BannerBlurhash { get; set; }
    
    [JsonProperty("backgroundUrl")]
    public Uri? BackgroundUrl { get; set; }
    
    [JsonProperty("backgroundBlurhash")]
    public string? BackgroundBlurhash { get; set; }
    
    [JsonProperty("isLocked")]
    public bool IsLocked { get; set; }
    
    [JsonProperty("isSuspended")]
    public bool IsSuspended { get; set; }
    
    [JsonProperty("description")]
    public string? Description { get; set; }
    
    [JsonProperty("location")]
    public string? Location { get; set; }
    
    [JsonProperty("birthday")]
    public string? Birthday { get; set; }
    
    [JsonProperty("listenBrainz")]
    public string? ListenBrainz { get; set; }
    
    [JsonProperty("lang")]
    public string? Lang { get; set; }
    
    [JsonProperty("fields")]
    public UserFields[] Fields { get; set; }
    
    // TODO: verified links
    
    [JsonProperty("followersCount")]
    public int FollowersCount { get; set; }
    
    [JsonProperty("followingCount")]
    public int FollowingCount { get; set; }
    
    [JsonProperty("notesCount")]
    public int NotesCount { get; set; }
    
    [JsonProperty("pinnedNoteIds")]
    public string[] PinnedNoteIds { get; set; }
    
    // TODO: Notes
    [JsonProperty("pinnedPageId")]
    public string? PinnedPageId { get; set; }
    // TODO: Page
    
    [JsonProperty("publicReactions")]
    public bool PublicReactions { get; set; }
    
    [JsonProperty("followingVisibility")]
    public FollowVisibilityType FollowingVisibility { get; set; }
    
    [JsonProperty("followersVisibility")]
    public FollowVisibilityType FollowersVisibility { get; set; }
    
    [JsonProperty("twoFactorEnabled")]
    public bool TwoFactorEnabled { get; set; }
    
    [JsonProperty("usePasswordLessLogin")]
    public bool UsePasswordlessLogin { get; set; }
    
    [JsonProperty("securityKeys")]
    public bool SecurityKeys { get; set; }
    
    [JsonProperty("roles")]
    public RoleLite[] Roles { get; set; }
    
    [JsonProperty("memo")]
    public string? Memo { get; set; }
    
    [JsonProperty("moderationNote")]
    public string ModerationNote { get; set; }
    
    [JsonProperty("hasPendingFollowRequestFromYou")]
    public bool HasOutgoingFollowRequest { get; set; }
    
    [JsonProperty("hasPendingFollowRequestToYou")]
    public bool HasIncomingFollowRequest { get; set; }
    
    [JsonProperty("isFollowed")]
    public bool IsFollowed { get; set; }
    
    [JsonProperty("isFollowing")]
    public bool IsFollowing { get; set; }
    
    [JsonProperty("isBlocked")]
    public bool IsBlocked { get; set; }
    
    [JsonProperty("isBlocking")]
    public bool IsBlocking { get; set; }
    
    [JsonProperty("isMuted")]
    public bool IsMuted { get; set; }
    
    [JsonProperty("isRenoteMuted")]
    public bool IsRenoteMuted { get; set; }
    
    //TODO: Change to enum
    [JsonProperty("notify")]
    public string Notify { get; set; }
    
    [JsonProperty("withReplies")]
    public bool WithReplies { get; set; }
}

internal class UserDecorations
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("angle")]
    public int Angle { get; set; }
    
    [JsonProperty("flipH")]
    public bool FlipH { get; set; }
    
    [JsonProperty("url")]
    public Uri Url { get; set; }
    
    [JsonProperty("offsetX")]
    public int XOffset { get; set; }
    
    [JsonProperty("offsetY")]
    public int YOffset { get; set; }
}

internal class UserInstance
{
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("softwareName")]
    public string? SoftwareName { get; set; }
    
    [JsonProperty("softwareVersion")]
    public string? SoftwareVersion { get; set; }
    
    [JsonProperty("iconUrl")]
    public Uri? IconUrl { get; set; }
    
    [JsonProperty("faviconUrl")]
    public Uri? FaviconUrl { get; set; }
    
    [JsonProperty("themeColor")]
    public string? ThemeColor { get; set; }
}

internal class UserFields
{
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("value")]
    public string Description { get; set; }
}

internal class UserRelation : IUserRelation
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("hasPendingFollowRequestFromYou")]
    public bool HasOutgoingFollowRequest { get; set; }
    
    [JsonProperty("hasPendingFollowRequestToYou")]
    public bool HasIncomingFollowRequest { get; set; }
    
    [JsonProperty("isFollowed")]
    public bool IsFollowed { get; set; }
    
    [JsonProperty("isFollowing")]
    public bool IsFollowing { get; set; }
    
    [JsonProperty("isBlocked")]
    public bool IsBlocked { get; set; }
    
    [JsonProperty("isBlocking")]
    public bool IsBlocking { get; set; }
    
    [JsonProperty("isMuted")]
    public bool IsMuted { get; set; }
    
    [JsonProperty("isRenoteMuted")]
    public bool IsRenoteMuted { get; set; }
}

internal interface IUserRelation
{
    public bool HasOutgoingFollowRequest { get; }
    public bool HasIncomingFollowRequest { get; }
    public bool IsFollowed { get; }
    public bool IsFollowing { get; }
    public bool IsBlocked { get; }
    public bool IsBlocking { get; }
    public bool IsMuted { get; }
    public bool IsRenoteMuted { get; }
}