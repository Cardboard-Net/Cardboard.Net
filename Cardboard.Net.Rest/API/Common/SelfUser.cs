using Cardboard.Users;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

// TODO: finish later
internal class SelfUser : User
{
    [JsonProperty("unreadNotificationsCount")]
    public int UnreadNotificationsCount { get; set; }
    
    [JsonProperty("loggedInDays")]
    public int LoggedInDays { get; set; }
}

internal class Achievement
{
    [JsonProperty("name")]
    public AchievementType AchievementType { get; set; }
}