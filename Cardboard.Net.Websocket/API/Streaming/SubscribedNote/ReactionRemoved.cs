using Newtonsoft.Json;

namespace Cardboard.Net.Websocket.API.Streaming.SubscribedNote;

internal class ReactionRemoved
{
    [JsonProperty("reaction")]
    public string Reaction { get; set; }
    
    [JsonProperty("userId")]
    public string UserId { get; set; }
}