using Cardboard.Users;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class AchievementNotification : Notification
{
    [JsonProperty("achievement")]
    public required AchievementType Achievement { get; set; }
}