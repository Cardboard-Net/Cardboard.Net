using Cardboard.Roles;

namespace Cardboard.Users;

public interface IUser : IUserLite
{
    public Uri? Url { get; }

    public Uri? Uri { get; }

    // TODO: movedTo

    // TODO: alsoKnownAs

    /// <summary>
    /// When the user was created
    /// </summary>
    public DateTime CreatedAt { get; }

    /// <summary>
    /// When the user was last updated
    /// </summary>
    public DateTime? UpdatedAt { get; }

    /// <summary>
    /// When the user was last fetched (if remote)
    /// </summary>
    public DateTime? LastFetchedAt { get; }

    /// <summary>
    /// The url to the user's banner
    /// </summary>
    public Uri? BannerUrl { get; }

    /// <summary>
    /// The blurhash of the user's banner
    /// </summary>
    public string? BannerBlurhash { get; }

    /// <summary>
    /// The background url of the user's banner
    /// </summary>
    public Uri? BackgroundUrl { get; }

    /// <summary>
    /// The blurhash of the user's background
    /// </summary>
    public string? BackgroundBlurhash { get; }

    /// <summary>
    /// Whether the user is locked
    /// </summary>
    public bool IsLocked { get; }

    /// <summary>
    /// Whether the user is suspended
    /// </summary>
    public bool IsSuspended { get; }

    /// <summary>
    /// The user's description
    /// </summary>
    public string? Description { get; }

    public string? Location { get; }

    public string? Birthday { get; }

    public string? ListenBrainz { get; }

    public string? Lang { get; }

    public IReadOnlyCollection<UserField> Fields { get; }

    // TODO: verified links

    public int FollowersCount { get; }

    public int FollowingCount { get; }

    public int NotesCount { get; }

    //public Note[] PinnedNotes { get; set; }

    // TODO: Page

    public bool PublicReactions { get; }

    public FollowVisibilityType FollowingVisibility { get; }

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