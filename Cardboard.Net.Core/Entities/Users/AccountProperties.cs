namespace Cardboard.Users;

/*
 * TODO: avatarId
 * TODO: bannerId
 * TODO: backgroundId
 * TODO: notificationReceiveConfig (it's typoed to recieve in api)
 * TODO: mutedWords
 * TODO: fields
 * TODO: AvatarDecorations
 */
public class AccountProperties
{
    public string? Name
    {
        get => name;
        set
        {
            if (value is { Length: > 50 })
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Name cannot exceed 50 characters");
            }

            name = value;
        }
    }
    private string? name;

    public string? Description
    {
        get => description;
        set
        {
            if (value is { Length: > 1500 })
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Description cannot exceed 1500 characters");
            }

            description = value;
        }
    }
    private string? description;
    
    public string? Location
    {
        get => location;
        set
        {
            if (value is { Length: > 50 })
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Location cannot exceed 50 characters");
            }

            location = value;
        }
    }
    private string? location;
    
    /// <summary>
    ///     Whether your account is locked
    /// </summary>
    /// <remarks>
    ///     I have no idea what the fuck this does, so I suggest you do not use it.
    /// </remarks>
    public bool? IsLocked { get; set; }
    
    /// <summary>
    ///     Whether your account is explorable
    /// </summary>
    public bool? IsExplorable { get; set; }
    
    /// <summary>
    ///     Whether to hide your online status
    /// </summary>
    public bool? HideOnlineStatus { get; set; }
    
    /// <summary>
    ///     Whether your reactions are public
    /// </summary>
    public bool? PublicReactions { get; set; }
    
    /// <summary>
    ///     No idea what the fuck this is.
    /// </summary>
    public bool? CarefulBot { get; set; }
    
    /// <summary>
    ///     Whether your account automatically accepts follow requests or if it's
    /// put in a queue
    /// </summary>
    public bool? AutoAcceptFollow { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public bool? NoCrawle { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public bool? PreventAiLearning { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public bool? NoIndex { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public bool? IsBot { get; set; }
    
    public bool? IsCat { get; set; }
    
    public bool? SpeakAsCat { get; set; }
    
    public bool? InjectFeaturedNote { get; set; }
    
    public bool? ReceiveAnnouncementEmail { get; set; }
    
    public bool? AlwaysMarkNSFW { get; set; }
    
    public bool? AutoSensitive { get; set; }
    
    public FollowVisibilityType FollowingVisibility { get; set; }
    
    public FollowVisibilityType FollowersVisibility { get; set; }
}