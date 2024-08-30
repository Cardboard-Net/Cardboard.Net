using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class GetRepliesParam
{
    [JsonProperty("noteId")]
    public required string Id { get; set; }
    
    [JsonProperty("sinceId")]
    public string? SinceId { get; set; }
    
    [JsonProperty("untilId")]
    public string? UntilId { get; set; }
    
    [JsonProperty("limit")]
    public int? Limit { get; set; }
}