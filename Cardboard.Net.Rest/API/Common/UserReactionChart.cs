using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class UserReactionChart
{
    [JsonProperty("local")]
    public required UserReactionCount Local { get; set; }
    
    [JsonProperty("remote")]
    public required UserReactionCount Remote { get; set; }
}

internal class UserReactionCount
{
    [JsonProperty("count")]
    public required int[] Count { get; set; }
}