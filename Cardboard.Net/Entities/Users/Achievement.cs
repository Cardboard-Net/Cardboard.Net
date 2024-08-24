using Newtonsoft.Json;

namespace Cardboard.Net.Entities.Users;

/// <summary>
/// Encapsulates a misskey achievement for serialization
/// </summary>
internal record Achievement
{
    /// <summary>
    /// The achievement
    /// </summary>
    [JsonProperty("name")]
    internal required AchievementType AchievementType { get; init; }
    
    internal Achievement() { }
}