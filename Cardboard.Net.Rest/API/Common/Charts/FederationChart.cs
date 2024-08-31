using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class FederationChart
{
    [JsonProperty("deliveredInstances")]
    public required int[] DeliveredInstances { get; set; } = [];

    [JsonProperty("inboxInstances")] 
    public required int[] InboxInstances { get; set; } = [];

    [JsonProperty("sub")] 
    public required int[] Sub { get; set; } = [];

    [JsonProperty("pub")]
    public required int[] Pub { get; set; } = [];

    [JsonProperty("pubsub")] 
    public required int[] PubSub { get; set; } = [];

    [JsonProperty("subActive")] 
    public required int[] SubActive { get; set; } = [];

    [JsonProperty("pubActive")] 
    public required int[] PubActive { get; set; } = [];
}