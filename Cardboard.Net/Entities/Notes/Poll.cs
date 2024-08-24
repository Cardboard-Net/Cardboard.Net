using Newtonsoft.Json;

namespace Cardboard.Net.Entities.Notes;

/// <summary>
/// Poll
/// </summary>
public class Poll
{
    /// <summary>
    /// An IReadOnlyList containing the poll options
    /// </summary>
    [JsonProperty("choices")]
    public IReadOnlyList<string> Choices = [];
    
    /// <summary>
    /// DateTime containing the expiration date (if there is one)
    /// </summary>
    [JsonProperty("expiresAt")]
    // TODO: https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/converters-how-to?pivots=dotnet-8-0
    public DateTime? ExpiresAt { get; init; }
    
    /// <summary>
    /// DateTime containing when the poll expired
    /// </summary>
    [JsonProperty("expiredAfter")]
    // TODO: https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/converters-how-to?pivots=dotnet-8-0
    public TimeSpan? ExpiredAfter { get; init; }
    
    /// <summary>
    /// Whether the poll allows multiple votes
    /// </summary>
    [JsonProperty("multiple")]
    public bool MultipleChoice { get; init; }
    
    /// <summary>
    /// Internal constructor for PollBuilder
    /// </summary>
    internal Poll() {}
}