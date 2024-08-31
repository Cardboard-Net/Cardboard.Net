using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class CreateClipParams
{
    [JsonProperty("name")]
    public required string Name { get; set; }
    
    [JsonProperty("isPublic")]
    public required bool? IsPublic { get; set; }
    
    [JsonProperty("description")]
    public required string? Description { get; set; }
}