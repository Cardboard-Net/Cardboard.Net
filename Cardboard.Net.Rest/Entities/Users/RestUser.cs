using Cardboard.Rest;
using Cardboard.Roles;
using Cardboard.Users;

using Model = Cardboard.Net.Rest.API.User;

namespace Cardboard.Rest;

/*
 * I fucking HATE this right now, I want to make some of this stuff subclasses
 * I am thinking, we replace the user relation stuff from DTO with a new
 * instance of IUserRelation. This allows people to get the user relation
 * by doing User.Relation.HasOutgoingFollowRequest and so forth. It makes
 * things so much nicer than this monstrosity, I am just rushing my
 * transformations so I have a "working" library again. We will clean up this
 * later.
 */

[Flags]
internal enum UserFlags : int
{
    None       = 0,
    Admin      = 1 << 0,
    Moderator  = 1 << 1,
    Silenced   = 1 << 2,
    NoIndex    = 1 << 3,
    Bot        = 1 << 4,
    Cat        = 1 << 5,
    SpeakAsCat = 1 << 6,
    Locked     = 1 << 7,
    Suspended  = 1 << 8
}

public class RestUser : RestEntity<string>, IUser, IUpdateable
{
    private UserFlags _flags = UserFlags.None;
    
    public bool IsAdmin 
        => _flags.HasFlag(UserFlags.Admin);
    
    public bool IsModerator 
        => _flags.HasFlag(UserFlags.Moderator);
    
    public bool IsSilenced
        => _flags.HasFlag(UserFlags.Silenced);

    public bool NoIndex
        => _flags.HasFlag(UserFlags.NoIndex);

    public bool IsBot
        => _flags.HasFlag(UserFlags.Bot);

    public bool IsCat
        => _flags.HasFlag(UserFlags.Cat);

    public bool SpeakAsCat
        => _flags.HasFlag(UserFlags.SpeakAsCat);
    
    public bool IsLocked
        => _flags.HasFlag(UserFlags.Locked);

    public bool IsSuspended 
        => _flags.HasFlag(UserFlags.Suspended);
    
    public string? Name { get; private set; }
    public string Username { get; private set; }
    public string? Host { get; private set; }
    public Uri? AvatarUrl { get; private set; }
    public string? AvatarBlurhash { get; private set; }
    public IReadOnlyList<IUserDecoration> AvatarDecorations { get; private set; }
    
    public IUserInstance Instance { get; private set; }
    public StatusType OnlineStatus { get; private set; }
    
    public IReadOnlyList<IBadgeRole> BadgeRoles { get; private set; }
    public Uri? Url { get; private set; }
    public Uri? Uri { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? LastFetchedAt { get; private set; }
    public Uri? BannerUrl { get; private set; }
    public string? BannerBlurhash { get; private set; }
    public Uri? BackgroundUrl { get; private set; }
    public string? BackgroundBlurhash { get; private set; }
    public string? Description { get; private set; }
    public string? Location { get; private set; }
    public string? Birthday { get; private set; }
    public string? ListenBrainz { get; private set; }
    public string? Lang { get; private set; }
    public IReadOnlyList<IUserField> Fields { get; private set; }
    public int FollowersCount { get; private set; }
    public int FollowingCount { get; private set; }
    public int NotesCount { get; private set; }
    public bool PublicReactions { get; private set; }
    public FollowVisibilityType FollowingVisibility { get; private set; }
    public FollowVisibilityType FollowersVisibility { get; private set; }
    public bool TwoFactorEnabled { get; private set; }
    public bool UsePasswordlessLogin { get; private set; }
    public bool SecurityKeys { get; private set; }
    public string? Memo { get; private set; }
    public string ModerationNote { get; private set; }
    public bool HasOutgoingFollowRequest { get; private set; }
    public bool HasIncomingFollowRequest { get; private set; }
    public bool IsFollowed { get; private set; }
    public bool IsFollowing { get; private set; }
    public bool IsBlocked { get; private set; }
    public bool IsBlocking { get; private set; }
    public bool IsMuted { get; private set; }
    public bool IsRenoteMuted { get; private set; }
    
    public NotifyType Notify { get; private set; }
    public bool WithReplies { get; private set; }

    public RestUser(BaseMisskeyClient misskey, string id) : base(misskey, id) { }
    
    internal static RestUser Create(BaseMisskeyClient misskey, Model model)
    {
        RestUser entity = new RestUser(misskey, model.Id);
        entity.Update(model);
        return entity;
    }
    
    internal virtual void Update(Model model)
    {
        // Set appropriate flags
        if (model.IsAdmin) _flags |= UserFlags.Admin;
        if (model.IsModerator) _flags |= UserFlags.Moderator;
        if (model.IsSilenced) _flags |= UserFlags.Silenced;
        if (model.NoIndex) _flags |= UserFlags.NoIndex;
        if (model.IsBot) _flags |= UserFlags.Bot;
        if (model.IsCat) _flags |= UserFlags.Cat;
        if (model.SpeakAsCat) _flags |= UserFlags.SpeakAsCat;
        if (model.IsLocked) _flags |= UserFlags.Locked;
        if (model.IsSuspended) _flags |= UserFlags.Suspended;
        
        this.Name = model.Name; 
        this.Username = model.Username;
        this.Host = model.Host;
        this.AvatarUrl = model.AvatarUrl;
        this.AvatarBlurhash = model.AvatarBlurhash;
        // TODO: Populate
        this.AvatarDecorations = [];
        this.OnlineStatus = model.OnlineStatus;
        this.Url = model.Url;
        this.Uri = model.Uri;
        this.CreatedAt = model.CreatedAt;
        this.LastFetchedAt = model.LastFetchedAt;
        this.BannerUrl = model.BannerUrl;
        this.BannerBlurhash = model.BannerBlurhash;
        this.BackgroundUrl = model.BackgroundUrl;
        this.BackgroundBlurhash = model.BackgroundBlurhash;
        this.Description = model.Description;
        this.Location = model.Location;
        this.Birthday = model.Birthday;
        this.ListenBrainz = model.ListenBrainz;
        this.Lang = model.Lang;
        // TODO: Populate
        this.Fields = [];
        this.FollowersCount = model.FollowersCount;
        this.FollowingCount = model.FollowingCount;
        this.NotesCount = model.NotesCount;
        this.PublicReactions = model.PublicReactions;
        this.FollowingVisibility = model.FollowingVisibility;
        this.FollowersVisibility = model.FollowersVisibility;
        this.TwoFactorEnabled = model.TwoFactorEnabled;
        this.UsePasswordlessLogin = model.UsePasswordlessLogin;
        this.SecurityKeys = model.SecurityKeys;
        this.Memo = model.Memo;
        this.ModerationNote = model.ModerationNote;
        this.HasOutgoingFollowRequest = model.HasOutgoingFollowRequest;
        this.HasIncomingFollowRequest = model.HasIncomingFollowRequest;
        this.IsFollowed = model.IsFollowed;
        this.IsFollowing = model.IsFollowing;
        this.IsBlocked = model.IsBlocked;
        this.IsBlocking = model.IsBlocking;
        this.IsMuted = model.IsMuted;
        this.IsRenoteMuted = model.IsRenoteMuted;
        this.Notify = model.Notify;
        this.WithReplies = model.WithReplies;
    }
    
    public virtual async Task UpdateAsync()
    {
        var model = await Misskey.ApiClient.GetUserAsync(Id);
        Update(model);
    }
    
    /*
     * We have a lot to do, I will list them out here...
     *
     * User relation:
     * TODO: following/operation/following___update
     * TODO: following/operation/following___invalidate
     * TODO: following/operation/following___requests___accept
     * TODO: following/operation/following___requests___cancel
     * TODO: following/operation/following___requests___reject
     *
     * User administration:
     *
     * TODO: admin/operation/admin___announcements___create (I want to populate userId with this.Id)
     * Task<Announcement> CreateAnnouncementAsync()
     * TODO: admin/operation/admin___delete-all-files-of-a-user
     * Task DeleteAllFilesAsync();
     * TODO: admin/operation/admin___unset-user-avatar
     * Task UnsetAvatarAsync();
     * TODO: admin/operation/admin___unset-user-banner
     * Task UnsetBannerAsync();
     * TODO: admin/operation/admin___get-user-ips
     * Task<IReadOnlyList<UserIp>> GetIpsAsync();
     * TODO: admin/operation/admin___show-user
     * TODO: admin/operation/admin___silence-user
     * Task SilenceAsync();
     *
     * TODO:
     */

    /// <summary>
    /// Reports the user to your home instance
    /// </summary>
    public async Task ReportAsync(string message)
        => await Misskey.ApiClient.ReportUserAsync(this.Id, message);

    /// <summary>
    /// Follows the user (or sends a follow request)
    /// </summary>
    /// <param name="withReplies">Whether you'd like to see their replies in timeline</param>
    Task FollowAsync(bool withReplies = false)
        => throw new NotImplementedException();

    /// <summary>
    /// Unfollows the user
    /// </summary>
    Task UnfollowAsync()
        => throw new NotImplementedException();
}