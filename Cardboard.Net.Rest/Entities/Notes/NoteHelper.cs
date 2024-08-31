using System.Collections.Immutable;
using Cardboard.Net.Rest.API;
using Cardboard.Notes;
using Cardboard.Rest.Clips;
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
        CreateNoteParams note = new CreateNoteParams()
        {
            Text = text,
            ContentWarning = contentWarning,
            LocalOnly = localOnly,
            ReactionAcceptance = acceptanceType,
            NoExtractMentions = noExtractMentions,
            NoExtractHashtags = noExtractHashtags,
            NoExtractEmojis = noExtractEmojis,
            ReplyId = replyId,
            RenoteId = renoteId,
            Visibility = visibilityType,
            Poll = poll is null ? null : new PollParams()
            {
                Choices = poll.Choices.Select(x => x.Text).ToArray(),
                MultipleChoice = poll.MultipleChoice,
                ExpiresAfter = (long?)poll.ExpiresAfter?.TotalMilliseconds,
                ExpiresAt = poll.ExpiresAt.HasValue ? ((DateTimeOffset)poll.ExpiresAt.Value.ToUniversalTime()).ToUnixTimeMilliseconds() : null
            }
        };
        
        var model = await client.ApiClient.CreateNoteAsync(note).ConfigureAwait(false);
        
        return model != null ? RestNote.Create(client, model) : null;
    }
    
    public static async Task<RestNote?> CreateDmNoteAsync
    (
        BaseMisskeyClient client,
        string[] dmRecipients,
        string? text = null,
        string? contentWarning = null,
        bool? localOnly = null,
        AcceptanceType? acceptanceType = null,
        bool? noExtractMentions = null,
        bool? noExtractHashtags = null,
        bool? noExtractEmojis = null,
        string? replyId = null,
        string? renoteId = null,
        Poll? poll = null
    )
    {
        CreateNoteParams note = new CreateNoteParams()
        {
            Text = text,
            VisibleUserIds = dmRecipients,
            ContentWarning = contentWarning,
            LocalOnly = localOnly,
            ReactionAcceptance = acceptanceType,
            NoExtractMentions = noExtractMentions,
            NoExtractHashtags = noExtractHashtags,
            NoExtractEmojis = noExtractEmojis,
            ReplyId = replyId,
            RenoteId = renoteId,
            Visibility = VisibilityType.Specified,
            Poll = poll is null ? null : new PollParams()
            {
                Choices = poll.Choices.Select(x => x.Text).ToArray(),
                MultipleChoice = poll.MultipleChoice,
                ExpiresAfter = (long?)poll.ExpiresAfter?.TotalMilliseconds,
                ExpiresAt = poll.ExpiresAt.HasValue ? ((DateTimeOffset)poll.ExpiresAt.Value.ToUniversalTime()).ToUnixTimeMilliseconds() : null
            }
        };
        
        var model = await client.ApiClient.CreateNoteAsync(note).ConfigureAwait(false);
        
        return model != null ? RestNote.Create(client, model) : null;
    }

    public static async Task<ImmutableArray<RestNote>> GetRenotesAsync
    (
        BaseMisskeyClient client,
        string noteId,
        string? userId = null,
        int? limit = null,
        string? sinceId = null,
        string? untilId = null,
        bool? withQuotes = null
    )
    {
        GetRenotesParam arg = new GetRenotesParam()
        {
            Id = noteId,
            UserId = userId,
            Limit = limit,
            SinceId = sinceId,
            UntilId = untilId,
            WithQuotes = withQuotes
        };

        Note[]? models = await client.ApiClient.GetRenotesAsync(arg).ConfigureAwait(false);

        if (models == null || models.Length == 0)
            return ImmutableArray<RestNote>.Empty;

        var _models = ImmutableArray.CreateBuilder<RestNote>(models.Length);

        foreach (var m in models)
            _models.Add(RestNote.Create(client, m));

        return _models.ToImmutable();
    }

    public static async Task<ImmutableArray<RestNote>> GetRepliesAsync
    (
        BaseMisskeyClient client,
        string noteId,
        int? limit = null,
        string? sinceId = null,
        string? untilId = null
    )
    {
        GetRepliesParam arg = new GetRepliesParam()
        {
            Id = noteId,
            Limit = limit,
            SinceId = sinceId,
            UntilId = untilId
        };
        
        Note[]? models = await client.ApiClient.GetRepliesAsync(arg).ConfigureAwait(false);
        
        if (models == null || models.Length == 0)
            return ImmutableArray<RestNote>.Empty;

        var _models = ImmutableArray.CreateBuilder<RestNote>(models.Length);

        foreach (var m in models)
            _models.Add(RestNote.Create(client, m));

        return _models.ToImmutable();
    }

    public static async Task<ImmutableArray<RestClip>> GetClipsAsync(BaseMisskeyClient client, string noteId)
    {
        Clip[]? models = await client.ApiClient.GetClipsAsync(noteId).ConfigureAwait(false);
        
        if (models == null || models.Length == 0)
            return ImmutableArray<RestClip>.Empty;

        var _models = ImmutableArray.CreateBuilder<RestClip>(models.Length);

        foreach (var m in models)
            _models.Add(RestClip.Create(client, m));

        return _models.ToImmutable();
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

        return await client.ApiClient.ModifyNoteAsync(modifyNoteParams);
    }
}