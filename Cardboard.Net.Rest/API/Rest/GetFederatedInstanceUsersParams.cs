using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class GetFederatedInstanceUsersParams
{
    [JsonProperty("host")]
    public required string Host { get; set; }
    
    [JsonProperty("sinceId")]
    public string? SinceId { get; set; }
    
    [JsonProperty("untilId")]
    public string? UntilId { get; set; }
    
    [JsonProperty("limit")]
    public int? Limit { get; set; }
}