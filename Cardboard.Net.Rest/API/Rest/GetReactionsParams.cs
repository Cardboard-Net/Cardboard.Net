using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class GetReactionsParams
{
    [JsonProperty("userId")]
    public required string UserId { get; set; }
    
    [JsonProperty("limit")]
    public int? Limit { get; set; }
    
    [JsonProperty("sinceId")]
    public string? SinceId { get; set; }
    
    [JsonProperty("untilId")]
    public string? UntilId { get; set; }
    
    [JsonProperty("sinceDate")]
    public long? SinceDate { get; set; }
    
    [JsonProperty("untilDate")]
    public long? UntilDate { get; set; }
}