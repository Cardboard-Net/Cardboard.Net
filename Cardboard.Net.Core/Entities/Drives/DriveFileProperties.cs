namespace Cardboard.Drives;

/// <summary>
/// Properties that are used to modify an IDriveFile with the specified changes
/// </summary>
public class DriveFileProperties
{
    /// <summary>
    /// Gets or sets the name of the file
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Gets or sets the parent folder
    /// </summary>
    /// <remarks>
    ///     If the parent object is set, this cannot be set.
    /// </remarks>
    public string? ParentId { get; set; }
    
    /// <summary>
    ///     Gets or sets the parent object of the file
    /// </summary>
    /// <remarks>
    ///     If the parent id is set, this cannot be set.
    /// </remarks>
    public IDriveFolder? Parent{ get; set; }
    
    /// <summary>
    /// Gets or sets whether the file is sensitive
    /// </summary>
    public bool IsSensitive { get; set; }
    
    /// <summary>
    /// Gets or sets the alt text for the file
    /// </summary>
    public string? Comment { get; set; }
}