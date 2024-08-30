using Cardboard.Notes;
using Newtonsoft.Json;

namespace Cardboard.Rest.Notes;

internal static class NoteHelper
{
    public static async Task<RestNote?> GetNoteAsync(BaseMisskeyClient client, string id)
    {
        var model = await client.ApiClient.GetNoteAsync(id).ConfigureAwait(false);
        
        return model != null ? RestNote.Create(client, model) : null;
    }

    public static async Task<RestNote?> CreateNoteAsync
    (
        BaseMisskeyClient client,
        string? text = null,
        string? contentWarning = null,
        bool? localOnly = null,
        AcceptanceType? acceptanceType = null,
        bool? noExtractMentions = null,
        bool? noExtractHashtags = null,
        bool? noExtractEmojis = null,
        string? replyId = null,
        string? renoteId = null,
        VisibilityType? visibilityType = null,
        Poll? poll = null
    )
    {
        var model = await client.ApiClient.CreateNoteAsync(text, contentWarning, localOnly, acceptanceType, noExtractMentions, noExtractHashtags, noExtractEmojis, replyId, renoteId, visibilityType, poll).ConfigureAwait(false);
        
        return model != null ? RestNote.Create(client, model) : null;
    }
}