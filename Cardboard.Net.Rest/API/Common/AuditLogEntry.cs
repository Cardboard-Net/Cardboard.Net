using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API.AuditLog;

internal class AuditLogEntry
{
    [JsonProperty("id")]
    public required string Id { get; set; }
    
    [JsonProperty("createdAt")]
    public required DateTime CreatedAt { get; set; }
    
    // I have a logtype somewhere, I think it's on my other pc using string for now
    [JsonProperty("type")]
    public required string Type { get; set; } 
    
    // TODO: fix this.
    //[JsonProperty("info")]
    //public required JObject Info { get; set; }
    
    [JsonProperty("userId")]
    public required string UserId { get; set; }
    
    [JsonProperty("user")]
    public required User User { get; set; }
}