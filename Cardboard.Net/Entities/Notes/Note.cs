using System.Dynamic;
using System.Text.Json.Serialization;

namespace Cardboard.Net.Entities;

/// <summary>
/// Class representing a misskey note
/// </summary>
public class Note : IMkObject
{
    /// <summary>
    /// The misskey:id of the current note
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id {get; init;}

    /// <summary>
    /// The contents of the current note
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text {get; init;}

    /// <summary>
    /// The visibility setting of the current note
    /// </summary>
    [JsonPropertyName("visibility")]
    public Notes.VisibilityType Visibility {get; init;}
    
    /// <summary>
    /// The reaction acceptance level of the current note
    /// </summary>
    [JsonPropertyName("reactionAcceptance")]
    public Notes.AcceptanceType Acceptance { get; init; }
}
