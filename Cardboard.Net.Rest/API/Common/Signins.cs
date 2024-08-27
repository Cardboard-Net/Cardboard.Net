using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class Signins
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
    
    [JsonProperty("ip")]
    public string Ip { get; set; }
    
    // TODO: Headers
    
    [JsonProperty("success")]
    public bool Success { get; set; }
}