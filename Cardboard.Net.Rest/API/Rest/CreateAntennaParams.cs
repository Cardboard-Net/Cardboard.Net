using Cardboard.Antennas;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class CreateAntennaParams
{
    [JsonProperty("name")]
    public required string Name { get; set; }
    
    [JsonProperty("src")]
    public required AntennaSourceType Source { get; set; }
    
    [JsonProperty("userListId")]
    public string? UserListId { get; set; }
    
    [JsonProperty("keywords")]
    public required string[] Keywords { get; set; }

    [JsonProperty("excludeKeywords")] 
    public string[] ExcludeKeywords { get; set; } = [""];

    [JsonProperty("users")] 
    public string[] UserIds { get; set; } = [""];

    [JsonProperty("caseSensitive")] 
    public bool CaseSensitive { get; set; } = false;
    
    [JsonProperty("localOnly")]
    public bool? LocalOnly { get; set; }
    
    [JsonProperty("excludeBots")]
    public bool? ExcludeBots { get; set; }

    [JsonProperty("withReplies")] 
    public required bool WithReplies { get; set; } = false;

    [JsonProperty("withFile")] 
    public required bool WithFiles { get; set; } = false;
}