using System.Collections.Immutable;
using Cardboard.Net.Rest.API;
using Cardboard.Notes;
using Cardboard.Rest;
using Cardboard.Rest.Notes;
using Cardboard.Roles;
using Cardboard.Users;
using BadgeRole = Cardboard.Net.Core.Entities.Roles.BadgeRole;
using Model = Cardboard.Net.Rest.API.User;
using Poll = Cardboard.Notes.Poll;

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
    None            = 0,
    Admin           = 1 << 0,
    Moderator       = 1 << 1,
    Silenced        = 1 << 2,
    NoIndex         = 1 << 3,
    Bot             = 1 << 4,
    Cat             = 1 << 5,
    SpeakAsCat      = 1 << 6,
    Locked          = 1 << 7,
    Suspended       = 1 << 8,
    PublicReactions = 1 << 9,
}

public class RestUser : RestEntity<string>, IUser, IUpdateable
{
    private UserFlags _userFlags = UserFlags.None;
    private ImmutableArray<UserField> _fields;
    private ImmutableArray<BadgeRole> _badgeRoles;
    
    public bool IsAdmin
    {
        get => _userFlags.HasFlag(UserFlags.Admin);
        internal set => _userFlags = value ? _userFlags | UserFlags.Admin : _userFlags & ~UserFlags.Admin;
    }

    public bool IsModerator
    {
        get => _userFlags.HasFlag(UserFlags.Moderator);
        internal set => _userFlags = value ? _userFlags | UserFlags.Moderator : _userFlags & ~UserFlags.Moderator;
    }

    public bool IsSilenced
        => _userFlags.HasFlag(UserFlags.Silenced);

    public bool NoIndex
        => _userFlags.HasFlag(UserFlags.NoIndex);

    public bool IsBot
        => _userFlags.HasFlag(UserFlags.Bot);

    public bool IsCat
        => _userFlags.HasFlag(UserFlags.Cat);

    public bool SpeakAsCat
        => _userFlags.HasFlag(UserFlags.SpeakAsCat);
    
    public bool IsLocked
        => _userFlags.HasFlag(UserFlags.Locked);

    public bool IsSuspended 
        => _userFlags.HasFlag(UserFlags.Suspended);

    public IReadOnlyCollection<INote> PinnedNotes { get; }

    public bool PublicReactions 
        => _userFlags.HasFlag(UserFlags.PublicReactions);
    
    public string? Name { get; internal set; }
    public string Username { get; internal set; }
    public string? Host { get; internal set; }
    public Uri? AvatarUrl { get; internal set; }
    public string? AvatarBlurhash { get; private set; }
    public IReadOnlyList<IUserDecoration> AvatarDecorations { get; private set; }
    
    public IUserInstance Instance { get; private set; }
    public StatusType OnlineStatus { get; private set; }

    public IReadOnlyCollection<BadgeRole> BadgeRoles => _badgeRoles;
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
    public IReadOnlyCollection<UserField> Fields => _fields;
    public int FollowersCount { get; private set; }
    public int FollowingCount { get; private set; }
    public int NotesCount { get; private set; }
    public FollowVisibilityType FollowingVisibility { get; private set; }
    public FollowVisibilityType FollowersVisibility { get; private set; }
    public bool TwoFactorEnabled { get; private set; }
    public bool UsePasswordlessLogin { get; private set; }
    public bool SecurityKeys { get; private set; }
    public string? Memo { get; private set; }
    public string ModerationNote { get; private set; }
    public RestUserRelation? Relation { get; private set; }
    public NotifyType Notify { get; private set; }
    public bool WithReplies { get; private set; }

    public RestUser(BaseMisskeyClient misskey, string id) : base(misskey, id) { }
    
    internal static RestUser Create(BaseMisskeyClient misskey, Model model)
    {
        RestUser entity = new RestUser(misskey, model.Id);
        entity.Update(model);
        return entity;
    }
    
    internal void Update(Model model)
    {
        IsAdmin = model.IsAdmin;
        if (model.IsModerator) _userFlags |= UserFlags.Moderator;
        if (model.IsSilenced) _userFlags |= UserFlags.Silenced;
        if (model.NoIndex) _userFlags |= UserFlags.NoIndex;
        if (model.IsBot) _userFlags |= UserFlags.Bot;
        if (model.IsCat) _userFlags |= UserFlags.Cat;
        if (model.SpeakAsCat) _userFlags |= UserFlags.SpeakAsCat;
        if (model.IsLocked) _userFlags |= UserFlags.Locked;
        if (model.IsSuspended) _userFlags |= UserFlags.Suspended;
        if (model.PublicReactions) _userFlags |= UserFlags.PublicReactions;
        
        this.Name = model.Name; 
        this.Username = model.Username;
        this.Host = model.Host;
        this.AvatarUrl = model.AvatarUrl;
        this.AvatarBlurhash = model.AvatarBlurhash;
        // TODO: Populate
        this.AvatarDecorations = [];
        this.OnlineStatus = model.OnlineStatus;

        if (model.BadgeRoles != null)
        {
            var roles = ImmutableArray.CreateBuilder<BadgeRole>(model.BadgeRoles.Length);
            
            foreach (var b in model.BadgeRoles)
                roles.Add(new BadgeRole(){DisplayOrder = b.DisplayOrder, Name = b.Name, IconUrl = b.IconUrl});

            _badgeRoles = roles.ToImmutable();
        }
        else
        {
            this._badgeRoles = ImmutableArray<BadgeRole>.Empty;
        }
        
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
        
        if (model.Fields != null)
        {
            var fields = ImmutableArray.CreateBuilder<UserField>(model.Fields.Length);
            
            foreach (var f in model.Fields)
                fields.Add(new UserField(f.Name, f.Description));

            _fields = fields.ToImmutable();
        }
        else
        {
            this._fields = ImmutableArray<UserField>.Empty;
        }
        
        this.FollowersCount = model.FollowersCount;
        this.FollowingCount = model.FollowingCount;
        this.NotesCount = model.NotesCount;
        this.FollowingVisibility = model.FollowingVisibility;
        this.FollowersVisibility = model.FollowersVisibility;
        this.TwoFactorEnabled = model.TwoFactorEnabled;
        this.UsePasswordlessLogin = model.UsePasswordlessLogin;
        this.SecurityKeys = model.SecurityKeys;
        this.Memo = model.Memo;
        this.ModerationNote = model.ModerationNote;
        
        RelationFlags relationFlags = RelationFlags.None;

        /*
         * So, let me explain this. We might not have the user relation given
         * in the model. The thing is, I can be reasonably sure that if I have
         * one part of the user relation fields then I have the others. I am
         * not going to make a monolith of an if statement to ensure all values
         * are not null. Another thing is that I originally had these separated
         * out, I was going to have a separate RestUserRelation for grabbing the
         * relation. The thing is, the only difference is user relation in the
         * model does not have an id associated with it. My suspicion is that
         * the user relation model id is the user id. This is why we go ahead and
         * hack together a new user relation model as if it was returned by the
         * api and shove it into this class.
         */
        if (model.HasOutgoingFollowRequest.HasValue)
        {
            UserRelation relation = new UserRelation()
            {
                Id = this.Id,
                HasOutgoingFollowRequest = model.HasOutgoingFollowRequest.Value,
                HasIncomingFollowRequest = model.HasIncomingFollowRequest!.Value,
                IsFollowed = model.IsFollowed!.Value,
                IsFollowing = model.IsFollowing!.Value,
                IsBlocked = model.IsBlocked!.Value,
                IsBlocking = model.IsBlocking!.Value,
                IsMuted = model.IsMuted!.Value,
                IsRenoteMuted = model.IsRenoteMuted!.Value
            };

            Relation = RestUserRelation.Create(Misskey, relation);
        }
        
        this.Notify = model.Notify;
        this.WithReplies = model.WithReplies;
    }
    
    public virtual async Task UpdateAsync()
    {
        var model = await Misskey.ApiClient.GetUserAsync(Id);

        if (model == null)
            return;
        
        Update(model);
    }

    public virtual async Task<RestUserRelation?> GetRelationAsync()
    {
        if (Relation != null)
            await Relation.UpdateAsync();
        
        Relation ??= await UserHelper.GetRelationAsync(Misskey, Id);
        return Relation;
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
     * TODO: admin/operation/admin___get-user-ips
     * Task<IReadOnlyList<UserIp>> GetIpsAsync();
     * TODO: admin/operation/admin___show-user
     *
     * TODO:
     */
    
    public async Task<RestNote> CreateDmNoteAsync
    (
        string text,
        string? contentWarning = null,
        bool? localOnly = null,
        AcceptanceType? acceptanceType = null,
        bool? noExtractMentions = null,
        bool? noExtractHashtags = null,
        bool? noExtractEmojis = null,
        Poll? poll = null
    )
    {
        RestNote? note = await NoteHelper.CreateDmNoteAsync
        (
            Misskey,
            text: text,
            dmRecipients: new string[]{ Id },
            contentWarning: contentWarning, 
            localOnly: localOnly,
            acceptanceType: acceptanceType,
            noExtractMentions: noExtractMentions,
            noExtractHashtags: noExtractHashtags,
            noExtractEmojis: noExtractEmojis,
            poll: poll
        );

        if (note == null)
            throw new InvalidOperationException("unable to create note");

        return note;
    }
    
    /// <summary>
    /// Accept the follow request from the user, allowing them to follow you.
    /// </summary>
    /// <returns></returns>
    public virtual async Task AcceptFollowRequestAsync()
        => await Misskey.ApiClient.AcceptFollowRequestFromUserAsync(this.Id);

    /// <summary>
    /// Reject a follow request, preventing the user from following you.
    /// </summary>
    /// <returns></returns>
    public virtual async Task RejectFollowRequestAsync()
        => await Misskey.ApiClient.RejectFollowRequestFromUserAsync(this.Id);

    /// <summary>
    /// Cancel a follow request. (What does this do??)
    /// </summary>
    /// <returns></returns>
    public virtual async Task CancelFollowRequestAsync()
        => await Misskey.ApiClient.CancelFollowRequestFromUserAsync(this.Id);
    
    /// <summary>
    /// Silence the user - preventing them from showing up normally on feeds.
    /// </summary>
    /// <returns></returns>
    public virtual async Task SilenceAsync()
        => await Misskey.ApiClient.SilenceUserAsync(this.Id);

    /// <summary>
    /// Delete all drive files. Highly invasive. Tread with Caution.
    /// </summary>
    /// <returns></returns>
    public async Task DeleteAllFilesAsync()
        => await Misskey.ApiClient.DeleteAllFilesOfUserAsync(this.Id);

    /// <summary>
    /// Unset the avatar on the user profile.
    /// </summary>
    /// <returns></returns>
    public async Task UnsetAvatarAsync()
        => await Misskey.ApiClient.UnsetUserAvatarAsync(this.Id);

    /// <summary>
    /// Unset the banner from the user profile.
    /// </summary>
    /// <returns>void</returns>
    public async Task UnsetBannerAsync()
        => await Misskey.ApiClient.UnsetUserBannerAsync(this.Id);

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

    public Task DeleteAsync()
    {
        throw new NotImplementedException();
    }

    IUserRelation IUser.Relation => Relation;
}