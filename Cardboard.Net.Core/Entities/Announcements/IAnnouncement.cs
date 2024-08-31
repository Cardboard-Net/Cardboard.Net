namespace Cardboard.Announcements;

public interface IAnnouncement : IMisskeyEntity
{
    /// <summary>
    ///     When the announcement was created
    /// </summary>
    DateTime CreatedAt { get; }
    
    /// <summary>
    ///     When the announcement was last updated (if ever)
    /// </summary>
    DateTime? UpdatedAt { get; }
    
    /// <summary>
    ///     The text of the announcement
    /// </summary>
    string Text { get; }
    
    /// <summary>
    ///     The announcement title
    /// </summary>
    string Title { get; }
    
    /// <summary>
    ///     The image url
    /// </summary>
    Uri? ImageUrl { get; }
    
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