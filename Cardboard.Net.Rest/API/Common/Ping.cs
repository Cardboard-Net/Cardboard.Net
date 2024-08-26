using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class Ping
{
    [JsonProperty("pong")]
    public int Pong { get; set; }
}