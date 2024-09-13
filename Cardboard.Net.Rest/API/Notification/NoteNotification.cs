using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

/*
 * This is a class encompassing several notification types, I will go over them
 *      Note
 *      Mention
 *      Reply
 *      Renote
 *      Quote
 *      PollEnded
 *      Edited
 */
internal class NoteNotification : Notification
{
    [JsonProperty("user")]
    public required UserLite User { get; set; }
    
    [JsonProperty("userId")]
    public required string UserId { get; set; }
    
    [JsonProperty("note")]
    public required Note Note { get; set; }
}