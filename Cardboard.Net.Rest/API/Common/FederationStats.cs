using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class FederationStats
{
    [JsonProperty("topSubInstances")]
    public FederatedInstance[] TopSubInstances { get; set; }
    
    [JsonProperty("topPubInstances")]
    public FederatedInstance[] TopPubInstances { get; set; }
    
    [JsonProperty("otherFollowersCount")]
    public int OtherFollowersCount { get; set; }
    
    [JsonProperty("otherFollowingCount")]
    public int OtherFollowingCount { get; set; }
}