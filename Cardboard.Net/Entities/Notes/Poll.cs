using System.Text.Json.Serialization;

namespace Cardboard.Net.Entities.Notes;

/// <summary>
/// Poll
/// </summary>
public class Poll
{
    /// <summary>
    /// An IReadOnlyList containing the poll options
    /// </summary>
    [JsonPropertyName("choices")]
    public required IReadOnlyList<string> Choices { get; init; }
    
    /// <summary>
    /// DateTime containing the expiration date (if there is one)
    /// </summary>
    [JsonPropertyName("expiresAt")]
    // TODO: https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/converters-how-to?pivots=dotnet-8-0
    public DateTime? ExpiresAt { get; init; }
    
    /// <summary>
    /// DateTime containing when the poll expired
    /// </summary>
    [JsonPropertyName("expiredAfter")]
    // TODO: https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/converters-how-to?pivots=dotnet-8-0
    public TimeSpan? ExpiredAfter { get; init; }
    
    /// <summary>
    /// Whether the poll allows multiple votes
    /// </summary>
    [JsonPropertyName("multiple")]
    public bool MultipleChoice { get; init; }
    
    /// <summary>
    /// Internal constructor for PollBuilder
    /// </summary>
    internal Poll() {}
}