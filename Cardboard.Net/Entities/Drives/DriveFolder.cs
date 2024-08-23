using System.Text.Json.Serialization;

namespace Cardboard.Net.Entities.Drives;

/// <summary>
/// Class representing a drive folder
/// </summary>
public class DriveFolder : MisskeyObject
{
    /// <summary>
    /// DateTime representing when the folder was created
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; init; }
    
    /// <summary>
    /// Name of the folder
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    
    /// <summary>
    /// Id of this folder's parent if there is any
    /// </summary>
    [JsonPropertyName("parentId")]
    public string? ParentId { get; init; }
    
    /// <summary>
    /// Parent folder
    /// </summary>
    [JsonPropertyName("parent")]
    public DriveFolder? ParentFolder { get; init; }
    
    /// <summary>
    /// Amount of sub folders
    /// </summary>
    [JsonPropertyName("foldersCount")]
    public int FoldersCount { get; init; }
    
    /// <summary>
    /// Amount of files contained within
    /// </summary>
    [JsonPropertyName("filesCount")]
    public int FilesCount { get; init; }
}