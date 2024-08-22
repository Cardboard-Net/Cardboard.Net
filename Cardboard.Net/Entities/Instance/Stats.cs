using System.Text.Json.Serialization;

namespace Cardboard.Net.Entities;

/// <summary>
/// Instance stats returned by /api/stats
/// </summary>
public class Stats
{
    /// <summary>
    /// 
    /// Number of notes
    /// </summary>
    [JsonPropertyName("notesCount")]
    public int NotesCount { get; init; }

    /// <summary>
    /// Number of notes (no idea why it's called original)
    /// </summary>
    [JsonPropertyName("originalNotesCount")]
    public int OriginalNotesCount {get; init; }

    /// <summary>
    /// Number of users
    /// </summary>
    [JsonPropertyName("usersCount")]
    public int UsersCount { get; init; }

    /// <summary>
    /// Number of users (no idea why it's called original)
    /// </summary>
    [JsonPropertyName("originalUsersCount")]
    public int OriginalUsersCount {get; init; }

    /// <summary>
    /// Number of instances
    /// </summary>
    [JsonPropertyName("instances")]
    public int InstancesCount {get; init; }
    
    /// <summary>
    /// Drive usage local
    /// </summary>
    [JsonPropertyName("driveUsageLocal")]
    public int DriveUsageLocal {get; init; }

    /// <summary>
    /// Drive usage remote
    /// </summary>
    [JsonPropertyName("driveUsageRemote")]
    public int DriveUsageRemote {get; init; }
}
