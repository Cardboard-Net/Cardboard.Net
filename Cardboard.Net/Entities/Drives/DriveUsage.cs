using Newtonsoft.Json;

namespace Cardboard.Net.Entities.Drives;

/// <summary>
/// Class representing drive usage
/// </summary>
public class DriveUsage
{
    /// <summary>
    /// Capacity of drive in bytes
    /// </summary>
    [JsonProperty("capacity")]
    public ulong Capacity { get; init; }
    
    /// <summary>
    /// Amount of drive space used in bytes
    /// </summary>
    [JsonProperty("usage")]
    public ulong Usage { get; init; }
}