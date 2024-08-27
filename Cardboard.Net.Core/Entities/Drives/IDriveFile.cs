using Cardboard.Users;

namespace Cardboard.Drives;

public interface IDriveFile : IMisskeyEntity
{
    /// <summary>
    /// When the file was created
    /// </summary>
    DateTime CreatedAt { get; }
    
    /// <summary>
    /// The name of the drive file
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// The type of file
    /// </summary>
    string Type { get; }
    
    /// <summary>
    /// The Md5 hash of the file
    /// </summary>
    string Md5 { get; }
    
    /// <summary>
    /// The size of the file in bytes
    /// </summary>
    ulong Size { get; }
    
    /// <summary>
    /// The url corresponding to the file
    /// </summary>
    Uri? Url { get; }
    
    /// <summary>
    /// The alt text for the file
    /// </summary>
    string? Comment { get; }
    
    /// <summary>
    /// The parent folder of the file (if there is one)
    /// </summary>
    IDriveFolder? ParentFolder { get; }
    
    /// <summary>
    /// The uploader of the file (if there is any)
    /// </summary>
    IUser? Uploader { get; } 
}