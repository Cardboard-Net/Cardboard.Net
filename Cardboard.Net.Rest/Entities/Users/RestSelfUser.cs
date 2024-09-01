using Cardboard.Announcements;
using Cardboard.Net.Core.Entities.Roles;
using Cardboard.Notes;
using Cardboard.Users;

using Model = Cardboard.Net.Rest.API.SelfUser;

namespace Cardboard.Rest;

public class RestSelfUser : RestEntity<string>, ISelfUser
{
    public string? Name { get; }
    public string Username { get; }
    public string? Host { get; }
    public Uri? AvatarUrl { get; }
    public string? AvatarBlurhash { get; }
    public IReadOnlyCollection<BadgeRole> BadgeRoles { get; }
    public bool IsAdmin { get; }
    public bool IsModerator { get; }
    public bool IsSilenced { get; }
    public bool NoIndex { get; }
    public bool IsBot { get; }
    public bool IsCat { get; }
    public bool SpeakAsCat { get; }
    public IUserInstance Instance { get; }
    public StatusType OnlineStatus { get; }
    public Uri? Url { get; }
    public Uri? Uri { get; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; }
    public DateTime? LastFetchedAt { get; }
    public Uri? BannerUrl { get; }
    public string? BannerBlurhash { get; }
    public Uri? BackgroundUrl { get; }
    public string? BackgroundBlurhash { get; }
    public bool IsLocked { get; }
    public bool IsSuspended { get; }
    public string? Description { get; }
    public string? Location { get; }
    public string? Birthday { get; }
    public string? ListenBrainz { get; }
    public string? Lang { get; }
    public IReadOnlyCollection<UserField> Fields { get; }
    public int FollowersCount { get; }
    public int FollowingCount { get; }
    public int NotesCount { get; }
    public IReadOnlyCollection<INote> PinnedNotes { get; }
    public bool PublicReactions { get; }
    public FollowVisibilityType FollowingVisibility { get; }
    public FollowVisibilityType FollowersVisibility { get; }
    public bool TwoFactorEnabled { get; }
    public bool UsePasswordlessLogin { get; }
    public bool SecurityKeys { get; }
    public string? Memo { get; }
    public string ModerationNote { get; }
    public NotifyType Notify { get; }
    public bool WithReplies { get; }
    
    /// <inheritdoc/>
    public bool HasUnreadDms { get; private set; }
    
    /// <inheritdoc/>
    public bool HasUnreadMentions { get; private set; }
    
    /// <inheritdoc/>
    public bool HasUnreadAnnouncement { get; private set; }
    
    /// <inheritdoc/>
    public IReadOnlyCollection<IUserAnnouncement> UnreadAnnouncements { get; }
    
    /// <inheritdoc/>
    public int UnreadNotificationsCount { get; private set; }
    
    /// <inheritdoc/>
    public int LoggedInDays { get; private set; }

    public RestSelfUser(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    internal void Update(Model model)
    {
        
    }

    public Task DeleteAsync()
    {
        throw new NotImplementedException();
    }
}