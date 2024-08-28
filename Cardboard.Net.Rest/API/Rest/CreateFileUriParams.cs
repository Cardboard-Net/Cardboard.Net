using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class CreateFileUriParams
{
    [JsonProperty("url")]
    public Uri Url { get; set; }
    
    [JsonProperty("folderId")]
    public string? FolderId { get; set; }
    
    [JsonProperty("comment")]
    public string? Comment { get; set; }
    
    [JsonProperty("marker")]
    public string? Marker { get; set; }
    
    [JsonProperty("isSensitive")]
    public bool? IsSensitive { get; set; }
    
    [JsonProperty("force")]
    public bool? Force { get; set; }
}