using Cardboard.Users;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class Notification
{
    [JsonProperty("id")]
    public required string Id { get; set; }
    
    [JsonProperty("createdAt")]
    public required DateTime CreatedAt { get; set; }
    
    [JsonProperty("type")]
    public required NotificationType Type { get; set; }
}