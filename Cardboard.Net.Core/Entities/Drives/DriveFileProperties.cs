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
    public string? ParentId 
    { 
        get => this.parentId;
        set
        {
            if (value != null && this.parent != null)
            {
                throw new ArgumentException("Cannot set parentId and parent");
            }

            this.parentId = value;
        } 
    }
    private string? parentId;

    /// <summary>
    ///     Gets or sets the parent folder of the file
    /// </summary>
    /// <remarks>
    ///     If the parent id is set, this cannot be set.
    /// </remarks>
    public IDriveFolder? Parent
    {
        get => this.parent;
        set
        {
            if (value != null && this.parentId != null)
            {
                throw new ArgumentException("Cannot set parentId and parent");
            }

            this.parent = value;
        }
    }
    private IDriveFolder? parent;
    
    /// <summary>
    /// Gets or sets whether the file is sensitive
    /// </summary>
    public bool IsSensitive { get; set; }
    
    /// <summary>
    /// Gets or sets the alt text for the file
    /// </summary>
    public string? Comment { get; set; }
}