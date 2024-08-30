namespace Cardboard.Drives;

public class DriveFolderProperties
{
    /// <summary>
    ///     Gets or sets the name of the folder
    /// </summary>
    public string? Name { get; set; }
    
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
    ///     Gets or sets the parent folder of the folder
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
}