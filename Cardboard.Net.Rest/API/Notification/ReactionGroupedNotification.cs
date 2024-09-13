using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class ReactionGroupedNotification : Notification
{
    [JsonProperty("note")]
    public required Note Note { get; set; }
    
    [JsonProperty("reactions")]
    public required ReactionGrouping[] Reactions { get; set; }
}

internal class ReactionGrouping
{
    [JsonProperty("user")]
    public required UserLite User { get; set; }
    
    [JsonProperty("reaction")]
    public required string Reaction { get; set; }
}