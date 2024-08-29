using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class GetUserNotesParams
{
    [JsonProperty("userId")]
    public required string Id { get; set; }
    
    [JsonProperty("withReplies")]
    public bool? WithReplies { get; set; }
    
    [JsonProperty("withRenotes")]
    public bool? WithRenotes { get; set; }
    
    [JsonProperty("withChannelNotes")]
    public bool? WithChannelNotes { get; set; }
    
    [JsonProperty("withFiles")]
    public bool? WithFiles { get; set; }
    
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
    
    [JsonProperty("allowPartial")]
    public bool? AllowPartial { get; set; }
}