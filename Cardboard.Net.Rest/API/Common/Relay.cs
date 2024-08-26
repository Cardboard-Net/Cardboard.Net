using Cardboard.Relays;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class Relay
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("inbox")]
    public Uri? Inbox { get; set; }
    
    [JsonProperty("status")]
    public RelayStatusType Status { get; set; }
}