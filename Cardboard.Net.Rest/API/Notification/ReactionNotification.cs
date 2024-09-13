using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class ReactionNotification : NoteNotification
{
    [JsonProperty("reaction")]
    public required string Reaction { get; set; }
}