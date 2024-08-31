using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class ModifyClipParams
{
    [JsonProperty("clipId")]
    public required string Id { get; set; }
    
    [JsonProperty("name")]
    public required string Name { get; set; }
    
    [JsonProperty("isPublic")]
    public required bool? IsPublic { get; set; }
    
    [JsonProperty("description")]
    public required string? Description { get; set; }
}