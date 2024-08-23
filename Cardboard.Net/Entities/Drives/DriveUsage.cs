using System.Text.Json.Serialization;

namespace Cardboard.Net.Entities.Drives;

/// <summary>
/// Class representing drive usage
/// </summary>
public class DriveUsage
{
    /// <summary>
    /// Capacity of drive (probably in bytes, i need to check)
    /// </summary>
    [JsonPropertyName("capacity")]
    public int Capacity { get; init; }
    
    /// <summary>
    /// Amount of drive space used
    /// </summary>
    [JsonPropertyName("usage")]
    public int Usage { get; init; }
}