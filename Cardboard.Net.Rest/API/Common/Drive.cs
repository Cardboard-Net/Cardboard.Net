using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class DriveFile
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("type")]
    public string Type { get; set; }
    
    [JsonProperty("md5")]
    public string Md5 { get; set; }
    
    [JsonProperty("size")]
    public ulong Size { get; set; }
    
    [JsonProperty("isSensitive")]
    public bool IsSensitive { get; set; }
    
    [JsonProperty("blurhash")]
    public string? Blurhash { get; set; }
    
    [JsonProperty("properties")]
    public DriveFileProperties Properties { get; set; }
    
    [JsonProperty("url")]
    public Uri? Url { get; set; }
    
    [JsonProperty("thumbnailUrl")]
    public Uri? ThumbnailUrl { get; set; }
    
    [JsonProperty("comment")]
    public string? Comment { get; set; }

    [JsonProperty("folderId")]
    public string? FolderId { get; set; }
    
    [JsonProperty("folder")]
    public DriveFolder? Folder { get; set; }
    
    [JsonProperty("userId")]
    public string? UserId { get; set; }
    
    [JsonProperty("user")]
    public UserLite? User { get; set; }
}

internal class DriveFileProperties
{
    [JsonProperty("width")]
    public int Width { get; set; }
    
    [JsonProperty("height")]
    public int Height { get; set; }
    
    [JsonProperty("orientation")]
    public int Orientation { get; set; }
    
    [JsonProperty("avgColor")]
    public string AvgColor { get; set; }
}

internal class DriveFolder
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
    
    [JsonProperty("parentId")]
    public string? ParentId { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("foldersCount")]
    public int FoldersCount { get; set; }
    
    [JsonProperty("filesCount")]
    public int FilesCount { get; set; }
    
    [JsonProperty("parent")]
    public DriveFolder? Parent { get; set; }
}