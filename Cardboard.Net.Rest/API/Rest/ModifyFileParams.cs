using Cardboard.Drives;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class ModifyFileParams
{
    [JsonProperty("fileId")]
    public required string Id { get; set; }
    
    [JsonProperty("folderId")]
    public string? FolderId { get; set; }
    
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("isSensitive")]
    public bool? IsSensitive { get; set; }
    
    [JsonProperty("comment")]
    public string? Comment { get; set; }
}