namespace Cardboard.Drives;

public class DriveFolderProperties
{
    /// <summary>
    ///     Gets or sets the name of the folder
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    ///     Gets or sets the parent id of the folder
    /// </summary>
    /// <remarks>
    ///     If the parent object is set, this cannot be set.
    /// </remarks>
    public string? ParentId { get; set; }
    
    /// <summary>
    ///     Gets or sets the parent object of the folder
    /// </summary>
    /// <remarks>
    ///     If the parent id is set, this cannot be set.
    /// </remarks>
    public IDriveFolder? Parent { get; set; }
}