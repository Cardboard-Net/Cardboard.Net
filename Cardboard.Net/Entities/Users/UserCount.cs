using System.Text.Json.Serialization;

namespace Cardboard.Net.Entities.Users;

/// <summary>
/// This encapsulates usercount
/// </summary>
internal record class UserCount
{
    /// <summary>
    /// The number of users online
    /// </summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }
}