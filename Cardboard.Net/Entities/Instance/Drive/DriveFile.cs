using Newtonsoft.Json;

namespace Cardboard.Net.Entities;

/// <summary>
/// Class representing a drive file
/// </summary>
public class DriveFile
{
    /// <summary>
    /// misskey:id of the file
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; protected set; }

    /// <summary>
    /// DateTime representing when the file was created
    /// </summary>
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; protected set; }

    /// <summary>
    /// Name of the file
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; protected set; }

    /// <summary>
    /// The mime-type of the file
    /// </summary>
    [JsonProperty("type")]
    public string MimeType { get; protected set; }

    /// <summary>
    /// Md5 hash of the file
    /// </summary>
    [JsonProperty("md5")]
    public string Md5 { get; protected set; }

    /// <summary>
    /// Size of file (presumably in bytes)
    /// </summary>
    [JsonProperty("size")]
    public int Size { get; protected set; }

    /// <summary>
    /// Whether the file is marked as sensitive
    /// </summary>
    [JsonProperty("isSensitive")]
    public bool IsSensitive { get; protected set; }

    /// <summary>
    /// Blurhash of the file
    /// </summary>
    [JsonProperty("blurhash")]
    public string? Blurhash { get; protected set; }
    
    /// <summary>
    /// Properties of the file if it's a media type
    /// </summary>
    [JsonProperty("properties")]
    public DriveFileProperties Properties { get; protected set; }

    /// <summary>
    /// Uri corresponding to the file
    /// </summary>
    [JsonProperty("url")]
    public Uri Url { get; protected set; }

    /// <summary>
    /// Optional thumbnail url
    /// </summary>
    [JsonProperty("thumbnailUrl")]
    public Uri? ThumbnailUrl { get; protected set; }

    /// <summary>
    /// Alt text for the file
    /// </summary>
    [JsonProperty("comment")]
    public string AltText { get; protected set; }

    /*
     * Considering kio showed me that user.instance isn't even present in the 
     * return for a user, despite the api docs saying it was present...
     * I am suspicious of "folder" object and "user" object returned by misskey
     * It may make sense to do GetFolderAsync() & GetUploaderAsync() fetching
     * from the corresponding id.
     */

    /// <summary>
    /// FolderId if the file is in a folder
    /// </summary>
    [JsonProperty("folderId")]
    public string FolderId { get; protected set; }

    /// <summary>
    /// UserId of the user who uploaded it
    /// </summary>
    [JsonProperty("userId")]
    public string UserId { get; protected set; }
}