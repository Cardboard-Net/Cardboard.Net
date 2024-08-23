using System.Text.Json.Serialization;

namespace Cardboard.Net.Entities.Drives;

/// <summary>
/// Class representing a drive file
/// </summary>
public class DriveFile : MisskeyObject
{
    /// <summary>
    /// DateTime representing when the file was uploaded
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; init; }
    
    /// <summary>
    /// Name of the file
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    
    /// <summary>
    /// Type of file
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }
    
    /// <summary>
    /// Md5 hash of the file
    /// </summary>
    [JsonPropertyName("md5")]
    public required string Md5Hash { get; init; }
    
    /// <summary>
    /// Size of file in bytes
    /// </summary>
    [JsonPropertyName("size")]
    public ulong Size { get; init; }
    
    /// <summary>
    /// Whether the file is sensitive
    /// </summary>
    [JsonPropertyName("isSensitive")]
    public bool IsSensitive { get; init; }
    
    /// <summary>
    /// optional blurhash
    /// </summary>
    [JsonPropertyName("blurhash")]
    public string? Blurhash { get; init; }
    
    /// <summary>
    /// Corresponding url of the file
    /// </summary>
    [JsonPropertyName("url")]
    public required Uri Url { get; init; }
    
    /// <summary>
    /// Corresponding thumbnail url of the file
    /// </summary>
    [JsonPropertyName("thumbnailUrl")]
    public Uri? ThumbnailUrl { get; init; }
    
    /// <summary>
    /// Alt text of the file if there is any
    /// </summary>
    [JsonPropertyName("comment")]
    public string? AltText { get; init; }
    
    /// <summary>
    /// Optional id of the folder the file resides within
    /// </summary>
    [JsonPropertyName("folderId")]
    public string? FolderId { get; init; }
    
    /// <summary>
    /// The id of the user who uploaded the file
    /// </summary>
    [JsonPropertyName("userId")]
    public required string UploaderId { get; init; }
}