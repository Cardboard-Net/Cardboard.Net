using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class ModifyFederatedInstanceParams
{
    [JsonProperty("host")]
    public string Host { get; set; }
    
    [JsonProperty("isSuspended")]
    public bool? IsSuspended { get; set; }
    
    [JsonProperty("isNSFW")]
    public bool? IsNSFW { get; set; }
    
    [JsonProperty("moderationNote")]
    public string? ModerationNote { get; set; }
}