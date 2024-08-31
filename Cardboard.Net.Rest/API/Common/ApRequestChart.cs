using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class ApRequestChart
{
    [JsonProperty("deliverFailed")]
    public required int[] DeliverFailed { get; set; }
    
    [JsonProperty("deliverSucceeded")]
    public required int[] DeliverSucceeded { get; set; }
    
    [JsonProperty("inboxReceived")]
    public required int[] InboxReceived { get; set; }
}