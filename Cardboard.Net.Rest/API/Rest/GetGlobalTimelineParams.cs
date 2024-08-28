using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class GetGlobalTimelineParams
{
    [JsonProperty("withFiles")]
    public bool? WithFiles { get; set; }

    [JsonProperty("withBots")]
    public bool? WithBots { get; set; }
    
    [JsonProperty("withRenotes")]
    public bool? WithRenotes { get; set; }
    
    [JsonProperty("limit")]
    public int? Limit { get; set; }
    
    [JsonProperty("sinceId")]
    public string? SinceId { get; set; }
    
    [JsonProperty("untilId")]
    public string? UntilId { get; set; }
    
    [JsonProperty("sinceDate")]
    public ulong? SinceDate { get; set; }
    
    [JsonProperty("untilDate")]
    public ulong? UntilDate { get; set; }
}