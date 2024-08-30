using Cardboard.Net.Rest.API;
using Cardboard.Notes;
using Newtonsoft.Json;
using Poll = Cardboard.Notes.Poll;

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

    public static async Task<Note?> ModifyNoteAsync(INote note, BaseMisskeyClient client, Action<NoteProperties> func)
        => await ModifyNoteAsync(note.Id, client, func);
    
    public static async Task<Note?> ModifyNoteAsync(string noteId, BaseMisskeyClient client, Action<NoteProperties> func)
    {
        NoteProperties args = new NoteProperties();
        func(args);

        ModifyNoteParams modifyNoteParams = new ModifyNoteParams()
        {
            Id = noteId,
            ChannelId = args.ChannelId,
            ContentWarning = args.ContentWarning,
            Visibility = args.Visibility,
            LocalOnly = args.LocalOnly,
            NoExtractHashtags = args.NoExtractHashtags,
            NoExtractEmojis = args.NoExtractEmojis,
            NoExtractMentions = args.NoExtractMentions,
            Text = args.Text,
            Poll = args.Poll is null
                ? null
                : new PollParams()
                {
                    Choices = args.Poll.Choices.Select(x => x.Text).ToArray(),
                    MultipleChoice = args.Poll.MultipleChoice,
                    ExpiresAfter = (long?)args.Poll.ExpiresAfter?.TotalMilliseconds,
                    ExpiresAt = args.Poll.ExpiresAt.HasValue
                        ? ((DateTimeOffset)args.Poll.ExpiresAt.Value.ToUniversalTime()).ToUnixTimeMilliseconds()
                        : null
                },
            RenoteId = args.RenoteId ?? args.Renote?.Id,
            ReplyId = args.ReplyId ?? args.Reply?.Id
        };

        return await client.ApiClient.ModifyNoteAsync(noteId, modifyNoteParams);
    }
}