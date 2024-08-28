using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class GetHybridTimelineParams
{
    [JsonProperty("limit")]
    public int? Limit { get; set; }
    
    [JsonProperty("sinceId")]
    public string? SinceId { get; set; }
    
    [JsonProperty("untilId")]
    public string? UntilId { get; set; }
    
    [JsonProperty("sinceDate")]
    public int? SinceDate { get; set; }
    
    [JsonProperty("untilDate")]
    public int? UntilDate { get; set; }
    
    [JsonProperty("allowPartial")]
    public bool? AllowPartial { get; set; }
    
    [JsonProperty("includeMyRenotes")]
    public bool? IncludeSelfRenotes { get; set; }
    
    [JsonProperty("includeRenotedMyNotes")]
    public bool? IncludeRenoteSelfNote { get; set; }
    
    [JsonProperty("includeLocalRenotes")]
    public bool? IncludeLocalRenotes { get; set; }
    
    [JsonProperty("withFiles")]
    public bool? WithFiles { get; set; }

    [JsonProperty("withRenotes")]
    public bool? WithRenotes { get; set; }
    
    [JsonProperty("withReplies")]
    public bool? WithReplies { get; set; }
    
    [JsonProperty("withBots")]
    public bool? WithBots { get; set; }
}