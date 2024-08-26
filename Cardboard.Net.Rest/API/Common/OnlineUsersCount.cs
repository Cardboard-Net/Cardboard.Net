using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class OnlineUsersCount
{
    [JsonProperty("count")]
    public int Count { get; set; }
}