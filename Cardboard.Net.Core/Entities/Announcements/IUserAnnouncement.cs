namespace Cardboard.Announcements;

/// <summary>
///     Instance (or user specific announcements) from the user's perspective (via announcement/show etc)
/// </summary>
/// <remarks>
///     I had to make this a different class/interface all together due to the
///     fact instance admins see announcements differently via admin/announcements
/// </remarks>
public interface IUserAnnouncement : IAnnouncement
{
    /// <summary>
    ///     The icon of the announcement
    /// </summary>
    IconType Icon { get; }
    
    /// <summary>
    ///     The display type of the announcement
    /// </summary>
    DisplayType Display { get; }
    
    /// <summary>
    ///     Whether the announcement needs a read confirmation
    /// </summary>
    bool ReadConfirmation { get; }
    
    /// <summary>
    ///     Whether the announcement is silenced
    /// </summary>
    bool Silence { get; }
    
    /// <summary>
    ///     Whether the announcement is only for you, or is instance wide
    /// </summary>
    bool ForYou { get; }
    
    /// <summary>
    ///     Whether you have marked the announcement as read
    /// </summary>
    bool IsRead { get; }

    /// <summary>
    ///     Marks the announcement as read
    /// </summary>
    Task ReadAsync();
}