namespace Cardboard.Announcements;

/// <summary>
///     Base for all announcements
/// </summary>
public interface IAnnouncement : IMisskeyEntity
{
    /// <summary>
    ///     When this announcement was created
    /// </summary>
    DateTime CreatedAt { get; }
    
    /// <summary>
    ///     When this announcement was last updated
    /// </summary>
    DateTime? UpdatedAt { get; }
    
    /// <summary>
    ///     The title of this announcement
    /// </summary>
    string Title { get; }
    
    /// <summary>
    ///     The text/description of this announcement
    /// </summary>
    string Text { get; }
    
    /// <summary>
    ///     The optional image url of this announcement
    /// </summary>
    Uri? ImageUrl { get; }
}