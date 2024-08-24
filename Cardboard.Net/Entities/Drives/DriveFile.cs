using Newtonsoft.Json;

namespace Cardboard.Net.Entities.Drives;

/// <summary>
/// Class representing a drive file
/// </summary>
public class DriveFile : MisskeyObject
{
    /// <summary>
    /// DateTime representing when the file was uploaded
    /// </summary>
    [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime CreatedAt { get; internal set; }
    
    /// <summary>
    /// Name of the file
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; internal set; }
    
    /// <summary>
    /// Type of file
    /// </summary>
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public string Type { get; internal set; }
    
    /// <summary>
    /// Md5 hash of the file
    /// </summary>
    [JsonProperty("md5", NullValueHandling = NullValueHandling.Ignore)]
    public string Md5Hash { get; internal set; }
    
    /// <summary>
    /// Size of file in bytes
    /// </summary>
    [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
    public ulong Size { get; internal set; }
    
    /// <summary>
    /// Whether the file is sensitive
    /// </summary>
    [JsonProperty("isSensitive", NullValueHandling = NullValueHandling.Ignore)]
    public bool IsSensitive { get; internal set; }
    
    /// <summary>
    /// optional blurhash
    /// </summary>
    [JsonProperty("blurhash", NullValueHandling = NullValueHandling.Ignore)]
    public string? Blurhash { get; internal set; }
    
    /// <summary>
    /// Corresponding url of the file
    /// </summary>
    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
    public Uri Url { get; internal set; }
    
    /// <summary>
    /// Corresponding thumbnail url of the file
    /// </summary>
    [JsonProperty("thumbnailUrl", NullValueHandling = NullValueHandling.Ignore)]
    public Uri? ThumbnailUrl { get; internal set; }
    
    /// <summary>
    /// Alt text of the file if there is any
    /// </summary>
    [JsonProperty("comment", NullValueHandling = NullValueHandling.Ignore)]
    public string? AltText { get; internal set; }
    
    /// <summary>
    /// Optional id of the folder the file resides within
    /// </summary>
    [JsonProperty("folderId", NullValueHandling = NullValueHandling.Ignore)]
    public string? FolderId { get; internal set; }
    
    /// <summary>
    /// The id of the user who uploaded the file
    /// </summary>
    [JsonProperty("userId", NullValueHandling = NullValueHandling.Ignore)]
    public string UploaderId { get; internal set; }
    
    internal DriveFile() {}
}