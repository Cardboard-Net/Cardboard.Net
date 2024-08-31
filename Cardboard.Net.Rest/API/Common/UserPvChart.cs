using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class UserPvChart
{
    [JsonProperty("upv")]
    public required UserPv UniquePv { get; set; }
    
    [JsonProperty("pv")]
    public required UserPv Pv { get; set; }
}

internal class UserPv
{
    [JsonProperty("user")]
    public required int[] User { get; set; } = [];
    
    [JsonProperty("visitor")]
    public required int[] Visitor { get; set; } = [];
}