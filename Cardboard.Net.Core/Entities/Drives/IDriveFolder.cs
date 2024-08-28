namespace Cardboard.Drives;

public interface IDriveFolder : IMisskeyEntity, IDeletable
{
    /// <summary>
    /// When the folder was created
    /// </summary>
    DateTime CreatedAt { get; }
    
    /// <summary>
    /// The parent of the folder (if there is one)
    /// </summary>
    IDriveFolder? Parent { get; }
    
    /// <summary>
    /// The name of the folder
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// The amount of subfolders
    /// </summary>
    int FoldersCount { get; }
    
    /// <summary>
    /// The amount of subfiles
    /// </summary>
    int FilesCount { get; }
}