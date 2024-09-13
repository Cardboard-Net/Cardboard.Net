using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

/*
 * This is a class encompassing several notification types, I will go over them
 *      Follow
 *      ReceiveFollowRequest
 *      FollowRequestAccepted
 */
internal class FollowNotification : Notification
{
    [JsonProperty("user")]
    public required UserLite User { get; set; }
    
    [JsonProperty("userId")]
    public required string UserId { get; set; }
}