using Cardboard.Net.Entities.Users;
using Cardboard.Net.Rest;
using Newtonsoft.Json;
using RestSharp;

namespace Cardboard.Net.Entities;

/// <summary>
/// Class representing a misskey note
/// </summary>
public class Note : MisskeyObject
{
    /// <summary>
    /// DateTime representing when the note was created
    /// </summary>
    [JsonProperty("createdAt")]
    public required DateTime CreatedAt { get; init; }

    /// <summary>
    /// The author of the note
    /// </summary>
    [JsonProperty("userId")]
    public required string AuthorId { get; init; }

    /// <summary>
    /// The id of the channel the note was created in, if there is one.
    /// </summary>
    [JsonProperty("channelId")]
    public string? ChannelId { get; init; }

    /// <summary>
    /// The contents of the current note
    /// </summary>
    [JsonProperty("text")]
    public string? Text {get; init;}

    /// <summary>
    /// The visibility setting of the current note
    /// </summary>
    [JsonProperty("visibility")]
    public Notes.VisibilityType Visibility {get; init;}
    
    /// <summary>
    /// The reaction acceptance level of the current note
    /// </summary>
    [JsonProperty("reactionAcceptance")]
    public Notes.AcceptanceType Acceptance { get; init; }

    /// <summary>
    /// Amount of times this note has been clipped
    /// </summary>
    [JsonProperty("clippedCount")]
    public int ClippedCount { get; init; }

    /// <summary>
    /// Creates a reaction on this note.
    /// </summary>
    /// <param name="reaction">Name of the emoji (or the unicode character?)</param>
    public async Task CreateReactAsync(string reaction)
        => await this.Misskey.ApiClient.SendRequestAsync(Endpoints.NOTE_REACTS_CREATE,
            JsonConvert.SerializeObject(new { noteId = this.Id, reaction = reaction }));

    /// <summary>
    /// Pin a note to your profile.
    /// </summary>
    /// <returns>void</returns>
    /// <exception cref="InvalidOperationException">Will fail if you are not the owner of the note.</exception>
    public async Task PinAsync() {
        if (this.Misskey.CurrentUser.Id != this.AuthorId) throw new InvalidOperationException("Cannot pin a note that does not belong to you!");
        RestResponse<Account> response = await this.Misskey.ApiClient.SendRequestAsync<Account>(Endpoints.PIN_NOTE, JsonConvert.SerializeObject(new {noteId = this.Id}));
        this.Misskey.CurrentUser = response.Data!;
    }

    /// <summary>
    /// Unpin a note from your profile.
    /// </summary>
    /// <returns>void</returns>
    /// <exception cref="InvalidOperationException">Will fail if note is not already pinned.</exception>
    public async Task UnpinAsync() {
        if (this.Misskey.CurrentUser.PinnedNotes.FirstOrDefault(Note => Note.Id  == this.Id) == null) {
            throw new InvalidOperationException("Cannot unpin a non-pinned note!");
        }
        await this.Misskey.ApiClient.SendRequestAsync(Endpoints.UNPIN_NOTE, JsonConvert.SerializeObject(new {noteId = this.Id}));
        RestResponse<Account> response = await this.Misskey.ApiClient.SendRequestAsync<Account>(Endpoints.PIN_NOTE, JsonConvert.SerializeObject(new {noteId = this.Id}));
        this.Misskey.CurrentUser = response.Data!;
    }

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
            JsonConvert.SerializeObject(new { noteId = this.Id }));
    
    /// <summary>
    /// Deletes the current note
    /// </summary>
    public async Task DeleteAsync()
        => await this.Misskey.ApiClient.SendRequestAsync(Endpoints.NOTE_DELETE,
            JsonConvert.SerializeObject(new { noteId = this.Id }));
    
    internal Note() {}
}
