using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class RoleAssignedNotification : Notification
{
    [JsonProperty("role")]
    public required Role Role { get; set; }
}