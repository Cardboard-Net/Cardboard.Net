using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class Invite
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("code")]
    public string Code { get; set; }
    
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("createdBy")]
    public UserLite CreatedBy { get; set; }
    
    [JsonProperty("expiresAt")]
    public DateTime? ExpiresAt { get; set; }
    
    [JsonProperty("usedAt")]
    public DateTime? UsedAt { get; set; }
    
    [JsonProperty("usedBy")]
    public UserLite UsedBy { get; set; }
    
    [JsonProperty("used")]
    public bool Used { get; set; }
}