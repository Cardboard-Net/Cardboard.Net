using Cardboard.Notes;
using Cardboard.Roles;

namespace Cardboard.Users;

public interface IUser : IUserLite
{
    /// <summary>
    ///     Url of the user
    /// </summary>
    public Uri? Url { get; }

    /// <summary>
    ///     Uri of the user
    /// </summary>
    public Uri? Uri { get; }

    // TODO: movedTo

    // TODO: alsoKnownAs

    /// <summary>
    ///     When the user was created
    /// </summary>
    public DateTime CreatedAt { get; }

    /// <summary>
    ///     When the user was last updated
    /// </summary>
    public DateTime? UpdatedAt { get; }

    /// <summary>
    ///     When the user was last fetched (if remote)
    /// </summary>
    public DateTime? LastFetchedAt { get; }

    /// <summary>
    ///     The url to the user's banner
    /// </summary>
    public Uri? BannerUrl { get; }

    /// <summary>
    ///     The blurhash of the user's banner
    /// </summary>
    public string? BannerBlurhash { get; }

    /// <summary>
    ///     The background url of the user's banner
    /// </summary>
    public Uri? BackgroundUrl { get; }

    /// <summary>
    ///     The blurhash of the user's background
    /// </summary>
    public string? BackgroundBlurhash { get; }

    /// <summary>
    ///     Whether the user is locked
    /// </summary>
    public bool IsLocked { get; }

    /// <summary>
    ///     Whether the user is suspended
    /// </summary>
    public bool IsSuspended { get; }

    /// <summary>
    ///     The user's description (if specified)
    /// </summary>
    public string? Description { get; }

    /// <summary>
    ///     The user's location (if specified)
    /// </summary>
    public string? Location { get; }

    /// <summary>
    ///     The user's birthday (if specified)
    /// </summary>
    /// <remarks>
    ///     TODO: Figure out if I can convert this to DateTime
    /// </remarks>
    public string? Birthday { get; }

    /// <summary>
    ///     The user's listenbrainz (if specified)
    /// </summary>
    public string? ListenBrainz { get; }

    /// <summary>
    ///     The user's language (if specified)
    /// </summary>
    public string? Lang { get; }

    /// <summary>
    ///     A collection of user fields
    /// </summary>
    public IReadOnlyCollection<UserField> Fields { get; }

    // TODO: verified links

    /// <summary>
    ///     The user's followers count
    /// </summary>
    public int FollowersCount { get; }

    /// <summary>
    ///     The user's following count
    /// </summary>
    public int FollowingCount { get; }

    /// <summary>
    ///     The user's note count
    /// </summary>
    public int NotesCount { get; }

    /// <summary>
    ///     A collection of the user's pinned notes
    /// </summary>
    public IReadOnlyCollection<INote> PinnedNotes { get; }

    // TODO: Page

    /// <summary>
    ///     Whether the user has public reactions
    /// </summary>
    public bool PublicReactions { get; }

    /// <summary>
    ///     The following visibility type (whether it's set to public, follower only, or private)
    /// </summary>
    public FollowVisibilityType FollowingVisibility { get; }

    /// <summary>
    ///     The followers visibility type (whether it's set to public, follower only, or private)
    /// </summary>
    public FollowVisibilityType FollowersVisibility { get; }

    public bool TwoFactorEnabled { get; }

    public bool UsePasswordlessLogin { get; }

    public bool SecurityKeys { get; }
    //public RoleLite[] Roles { get; set; }
    
    public string? Memo { get; }

    public string ModerationNote { get; }

    public NotifyType Notify { get; }

    public bool WithReplies { get; }
}