using Newtonsoft.Json;

namespace Cardboard.Rest.Notes;

internal static class NoteHelper
{
    public static async Task<RestNote> GetNoteAsync(BaseMisskeyClient client, string id)
    {
        var model = await client.ApiClient.GetNoteAsync(id).ConfigureAwait(false);
        
        if (model != null)
            return RestNote.Create(client, model);
        return null;
    }
}