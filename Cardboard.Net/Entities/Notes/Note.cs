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
    /// DateTime representing when the note was created
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; init; }

    /// <summary>
    /// The author of the note
    /// </summary>
    [JsonPropertyName("userId")]
    public required string AuthorId { get; init; }

    /// <summary>
    /// The id of the channel the note was created in, if there is one.
    /// </summary>
    [JsonPropertyName("channelId")]
    public string? ChannelId { get; init; }

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

    /// <summary>
    /// Amount of times this note has been clipped
    /// </summary>
    [JsonPropertyName("clippedCount")]
    public int ClippedCount { get; init; }
}
