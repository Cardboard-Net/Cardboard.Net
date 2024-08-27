using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class RoleAssigns
{
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
    
    [JsonProperty("expiresAt")]
    public DateTime? ExpiresAt { get; set; }
    
    [JsonProperty("roleId")]
    public string RoleId { get; set; }
}