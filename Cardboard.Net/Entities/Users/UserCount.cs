using Newtonsoft.Json;

namespace Cardboard.Net.Entities.Users;

/// <summary>
/// This encapsulates usercount
/// </summary>
internal record UserCount
{
    /// <summary>
    /// The number of users online
    /// </summary>
    [JsonProperty("count")]
    public required int Count { get; init; }
}