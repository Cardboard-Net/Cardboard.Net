using System.Text.Json.Serialization;

namespace Cardboard.Net.Entities.Drives;

/// <summary>
/// Class representing drive usage
/// </summary>
public class DriveUsage
{
    /// <summary>
    /// Capacity of drive in bytes
    /// </summary>
    [JsonPropertyName("capacity")]
    public ulong Capacity { get; init; }
    
    /// <summary>
    /// Amount of drive space used in bytes
    /// </summary>
    [JsonPropertyName("usage")]
    public ulong Usage { get; init; }
}