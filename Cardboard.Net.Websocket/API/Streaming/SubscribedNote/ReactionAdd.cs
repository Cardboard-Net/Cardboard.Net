using Newtonsoft.Json;

namespace Cardboard.Net.Websocket.API.Streaming.SubscribedNote;

internal class ReactionAdd
{
    /*
     * TODO: Figure out if reaction is nullable
     *
     * The reason I don't know is because mastodon interacts with misskey
     * differently. Mastodon does not support reactions, only favorites which
     * is their version of "like". Does it send as a reaction in that case? Or
     * is there another event that I receive. I'm unsure, but that will need to
     * wait until I have a working websocket to gather more payloads... These
     * are all undocumented.
     */
    [JsonProperty("reaction")]
    public string? Reaction { get; set; }
    
    [JsonProperty("emoji")]
    public string? Emoji { get; set; }
    
    [JsonProperty("userId")]
    public string UserId { get; set; }
}