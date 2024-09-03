using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class List
{
    [JsonProperty("id")] 
    public string Id { get; set; }
    
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("userIds")]
    public string[]? UserIds { get; set; }
    
    [JsonProperty("isPublic")]
    public bool IsPublic { get; set; }
}