using System.Text.Json;
using System.Text.Json.Serialization;
using Cardboard.Net.Rest;

namespace Cardboard.Net.Entities;

/// <summary>
/// Class representing a misskey note
/// </summary>
public class Note : MisskeyObject
{
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

    /// <summary>
    /// Creates a reaction on this note.
    /// </summary>
    /// <param name="reaction">Name of the emoji (or the unicode character?)</param>
    public async Task CreateReactAsync(string reaction)
        => await this.Misskey.ApiClient.SendRequestAsync(Endpoints.NOTE_REACTS_CREATE,
            JsonSerializer.Serialize(new { noteId = this.Id, reaction = reaction }));

    /// <summary>
    /// Creates a reaction on this note.
    /// </summary>
    /// <param name="reaction">An emoji object to react with</param>
    public async Task CreateReactAsync(Emoji reaction)
        => await CreateReactAsync(reaction.Name);
    
    /// <summary>
    /// Deletes the reaction from the currently logged in user
    /// </summary>
    public async Task DeleteReactAsync()
        => await this.Misskey.ApiClient.SendRequestAsync(Endpoints.NOTE_REACTS_DELETE,
            JsonSerializer.Serialize(new { noteId = this.Id }));
    
    /// <summary>
    /// Deletes the current note
    /// </summary>
    public async Task DeleteAsync()
        => await this.Misskey.ApiClient.SendRequestAsync(Endpoints.NOTE_DELETE,
            JsonSerializer.Serialize(new { noteId = this.Id }));
}
