using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class Ping
{
    [JsonProperty("pong")]
    public ulong Pong { get; set; }
}