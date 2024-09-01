namespace Cardboard.Announcements;

public class AnnouncementProperties
{
    /// <summary>
    ///     Gets or sets the title of the announcement
    /// </summary>
    public string? Title { get; set; }
    
    /// <summary>
    ///     Gets or sets the text of the announcement
    /// </summary>
    public string? Text { get; set; }
    
    /// <summary>
    ///     Gets or sets the image url of the announcement
    /// </summary>
    public Uri? ImageUrl { get; set; }
    
    /// <summary>
    ///     Gets or sets the icon of the announcement
    /// </summary>
    public IconType Icon { get; set; }
    
    /// <summary>
    ///     Gets or sets the display type of the announcement
    /// </summary>
    public DisplayType Display { get; set; }
    
    /// <summary>
    ///     Gets or sets whether the announcement is for existing users
    /// </summary>
    public bool ForExistingUsers { get; set; }
    
    /// <summary>
    ///     Gets or sets whether the announcement is silenced
    /// </summary>
    public bool Silence { get; set; }
    
    /// <summary>
    ///     Gets or sets whether the announcement requires a read confirmation
    /// </summary>
    public bool ReadConfirmation { get; set; }
    
    /// <summary>
    ///     Gets or sets whether the announcement is active or archived
    /// </summary>
    public bool IsActive { get; set; }
}