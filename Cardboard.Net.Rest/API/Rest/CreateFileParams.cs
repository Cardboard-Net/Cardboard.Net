using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class CreateFileParams
{
    [JsonProperty("folderId")]
    public string? FolderId { get; set; }
    
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("comment")]
    public string? Comment { get; set; }
    
    [JsonProperty("isSensitive")]
    public bool? IsSensitive { get; set; }
    
    [JsonProperty("force")]
    public bool? Force { get; set; }
}