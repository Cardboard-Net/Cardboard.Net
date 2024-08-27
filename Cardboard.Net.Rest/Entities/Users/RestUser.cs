using Cardboard.Net.Entities.Users;
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
public class RestUser : RestEntity, IUser, IUpdateable
{
    public string? Name { get; private set; }
    public string Username { get; private set; }
    public string? Host { get; private set; }
    public Uri? AvatarUrl { get; private set; }
    public string? AvatarBlurhash { get; private set; }
    public IReadOnlyList<IUserDecoration> AvatarDecorations { get; private set; }
    public bool IsAdmin { get; private set; }
    public bool IsModerator { get; private set; }
    public bool IsSilenced { get; private set; }
    public bool NoIndex { get; private set; }
    public bool IsBot { get; private set; }
    public bool IsCat { get; private set; }
    public bool SpeakAsCat { get; private set; }
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
    public bool IsLocked { get; private set; }
    public bool IsSuspended { get; private set; }
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
        this.Name = model.Name; 
        this.Username = model.Username;
        this.Host = model.Host;
        this.AvatarUrl = model.AvatarUrl;
        this.AvatarBlurhash = model.AvatarBlurhash;
        // TODO: Populate
        this.AvatarDecorations = [];
        this.IsAdmin = model.IsAdmin;
        this.IsModerator = model.IsModerator;
        this.IsSilenced = model.IsSilenced;
        this.NoIndex = model.NoIndex;
        this.IsBot = model.IsBot;
        this.IsCat = model.IsCat;
        this.SpeakAsCat = model.SpeakAsCat;
        this.OnlineStatus = model.OnlineStatus;
        this.Url = model.Url;
        this.Uri = model.Uri;
        this.CreatedAt = model.CreatedAt;
        this.LastFetchedAt = model.LastFetchedAt;
        this.BannerUrl = model.BannerUrl;
        this.BannerBlurhash = model.BannerBlurhash;
        this.BackgroundUrl = model.BackgroundUrl;
        this.BackgroundBlurhash = model.BackgroundBlurhash;
        this.IsLocked = model.IsLocked;
        this.IsSuspended = model.IsSuspended;
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
        //var model = await Misskey.ApiClient.GetUserAsync()
        throw new NotImplementedException();
    }
}