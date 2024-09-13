using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class RenoteGroupedNotification : Notification
{
    [JsonProperty("note")]
    public required Note Note { get; set; }
    
    [JsonProperty("users")]
    public required UserLite[] Users { get; set; }
}