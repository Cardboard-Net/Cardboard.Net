using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class GetAnnouncementsParam
{
    [JsonProperty("limit")]
    public int? Limit { get; set; }
    
    [JsonProperty("sinceId")]
    public string? SinceId { get; set; }
    
    [JsonProperty("untilId")]
    public string? UntilId { get; set; }
    
    [JsonProperty("isActive")]
    public bool? IsActive { get; set; }
}