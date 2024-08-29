using Newtonsoft.Json;

namespace Cardboard.Net.Websocket.API.Streaming.SubscribedNote;

internal class ReplyAdded
{
    [JsonProperty("id")]
    public string ReplyId { get; set; }
    
    [JsonProperty("userId")]
    public string UserId { get; set; }
}