using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class FederationStats
{
    [JsonProperty("topSubInstances")]
    public FederationInstance[] TopSubInstances { get; set; }
    
    [JsonProperty("topPubInstances")]
    public FederationInstance[] TopPubInstances { get; set; }
    
    [JsonProperty("otherFollowersCount")]
    public int OtherFollowersCount { get; set; }
    
    [JsonProperty("otherFollowingCount")]
    public int OtherFollowingCount { get; set; }
}