using Cardboard.Antennas;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class ModifyAntennaParams
{
    [JsonProperty("antennaId")]
    public required string Id { get; set; }
    
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("src")]
    public AntennaSourceType? Source { get; set; }
    
    [JsonProperty("userListId")]
    public string? UserListId { get; set; }
    
    [JsonProperty("keywords")]
    public string[]? Keywords { get; set; }
    
    [JsonProperty("excludeKeywords")]
    public string[]? ExcludeKeywords { get; set; }
    
    [JsonProperty("users")]
    public string[]? UserIds { get; set; }
    
    [JsonProperty("caseSensitive")]
    public bool? CaseSensitive { get; set; }
    
    [JsonProperty("localOnly")]
    public bool? LocalOnly { get; set; }
    
    [JsonProperty("excludeBots")]
    public bool? ExcludeBots { get; set; }
    
    [JsonProperty("withReplies")]
    public bool? WithReplies { get; set; }
    
    [JsonProperty("withFile")]
    public bool? WithFile { get; set; }
}