using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class AppNotification : Notification
{
    [JsonProperty("body")]
    public required string Body { get; set; }
    
    [JsonProperty("header")]
    public required string Header { get; set; }
    
    [JsonProperty("icon")]
    public required string Icon { get; set; }
}