using Newtonsoft.Json;

namespace Cardboard.Net.Websocket.API.Streaming;

internal class SocketFrame
{
    [JsonProperty("type")]
    public required string Type { get; set; }
    
    [JsonProperty("body")]
    public FrameBody Body { get; set; }
}

internal class FrameBody
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("type")]
    public string Type { get; set; }
    
    [JsonProperty("body")]
    public object Payload { get; set; }
}