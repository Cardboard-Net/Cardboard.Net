using System.Collections.Immutable;
using Cardboard.Drives;
using Cardboard.Extensions;
using Cardboard.Notes;
using Cardboard.Rest.Clips;
using Cardboard.Rest.Drives;
using Cardboard.Users;
using Model = Cardboard.Net.Rest.API.Note;

namespace Cardboard.Rest.Notes;

public class RestNote : RestEntity<string>, INote, IUpdateable
{
    private ImmutableDictionary<string, RestDriveFile> _files;
    private ImmutableArray<string> _mentions;
    private ImmutableArray<string> _visibleUserIds;
    private ImmutableArray<string> _tags;
    
    ///<inheritdoc/>
    public DateTime CreatedAt { get; private set; }
    ///<inheritdoc/>
    public DateTime? DeletedAt { get; private set; }
    ///<inheritdoc/>
    public string? Text { get; private set; }
    ///<inheritdoc/>
    public string? ContentWarning { get; private set; }
    public RestUserLite? Author { get; private set; }
    public RestNote? Reply { get; private set; }
    public RestNote? Renote { get; private set; }
    ///<inheritdoc/>
    public bool IsHidden { get; private set; }
    ///<inheritdoc/>
    public VisibilityType Visibility { get; private set; }
    ///<inheritdoc/>
    public IReadOnlyCollection<string> Mentions => _mentions;
    ///<inheritdoc/>
    public IReadOnlyCollection<string> VisibleUserIds => _visibleUserIds;
    ///<inheritdoc/>
    public IReadOnlyCollection<string> Tags => _tags;
    ///<inheritdoc/>
    public Poll? Poll { get; private set; }
    public IReadOnlyCollection<RestDriveFile> Files => _files.ToReadOnlyCollection();
    public bool LocalOnly { get; private set; }
    public AcceptanceType? ReactionAcceptance { get; set; }
    public int ReactionCount { get; set; }
    public int RenoteCount { get; set; }
    public int RepliesCount { get; set; }
    public Uri Url { get; set; }
    public Uri Uri { get; set; }
    public int ClippedCount { get; set; }
    public string? MyReaction { get; set; }
    
    public RestNote(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    internal static RestNote Create(BaseMisskeyClient misskey, Model model)
    {
        RestNote entity = new RestNote(misskey, model.Id);
        entity.Update(model);
        return entity;
    }

    internal void Update(Model model)
    {
        CreatedAt = model.CreatedAt;
        DeletedAt = model.DeletedAt;
        Text = model.Text;
        ContentWarning = model.ContentWarning;

        if (model.User is not null)
        {
            Author = RestUserLite.Create(Misskey, model.User!);
        }
        
        if (model.Reply is not null)
        {
            Reply = RestNote.Create(Misskey, model.Reply!);
        }

        if (model.Renote is not null)
        {
            Renote = RestNote.Create(Misskey, model.Renote!);
        }
        
        var files = ImmutableDictionary.CreateBuilder<string, RestDriveFile>();
        if (model.Files != null)
        {
            foreach (var t in model.Files)
                files[t.Id] = RestDriveFile.Create(Misskey, t);
        }

        if (model.Poll is not null)
        {
            TimeSpan? expiresAfter = null;
            
            if (model.Poll.ExpiresAfter.HasValue)
            {
                expiresAfter = TimeSpan.FromMilliseconds(model.Poll.ExpiresAfter.Value);
            }

            var choices = ImmutableArray.CreateBuilder<PollChoice>(model.Poll.Choices.Length);
            
            foreach (var t in model.Poll.Choices)
                choices.Add(new PollChoice(t.Text, t.Votes, t.IsVoted));

            Poll = new Poll(model.Poll.MultipleChoice, choices.ToImmutable(), model.Poll.ExpiresAt, expiresAfter);
        }
        
        _files = files.ToImmutable();
        IsHidden = model.IsHidden;
        Visibility = model.Visibility;
        LocalOnly = model.LocalOnly;
        ReactionAcceptance = model.ReactionAcceptance;
        ReactionCount = model.ReactionCount;
        RenoteCount = model.RenoteCount;
        RepliesCount = model.RepliesCount;
        Url = model.Url;
        Uri = model.Uri;
        ClippedCount = model.ClippedCount;
        MyReaction = model.MyReaction;
    }

    public async Task UpdateAsync()
    {
        var model = await Misskey.ApiClient.GetNoteAsync(Id);

        if (model == null)
            return;
        
        Update(model);
    }

    public async Task ModifyAsync(Action<NoteProperties> args)
    {
        var model = await NoteHelper.ModifyNoteAsync(this, Misskey, args);

        if (model == null)
            return;
        
        Update(model);
    }
    
    public async Task DeleteAsync()
        => await Misskey.ApiClient.DeleteNoteAsync(Id);

    public async Task MuteThreadAsync()
        => await Misskey.ApiClient.MuteNoteAsync(Id);

    public async Task UnmuteThreadAsync()
        => await Misskey.ApiClient.UnmuteNoteAsync(Id);

    public async Task FavoriteAsync()
        => await Misskey.ApiClient.FavoriteNoteAsync(Id);

    public async Task UnfavoriteAsync()
        => await Misskey.ApiClient.UnfavoriteNoteAsync(Id);

    public async Task<IReadOnlyCollection<RestClip>> GetClipsAsync()
        => await NoteHelper.GetClipsAsync(Misskey, Id);
    
    public async Task<IReadOnlyCollection<RestNote>> GetRenotesAsync
    (
        string? userId = null,
        int? limit = null,
        string? sinceId = null,
        string? untilId = null,
        bool? withQuotes = null
    )
        => await NoteHelper.GetRenotesAsync(Misskey, Id, userId, limit, sinceId, untilId, withQuotes);

    public async Task<IReadOnlyCollection<RestNote>> GetRepliesAsync(int? limit = null, string? sinceId = null,
        string? untilId = null)
        => await NoteHelper.GetRepliesAsync(Misskey, Id, limit, sinceId, untilId);

    public async Task<RestNote?> BoostAsync()
        => await RenoteAsync();

    public async Task<RestNote?> RenoteAsync()
        => await NoteHelper.CreateNoteAsync(Misskey, renoteId:Id);

    public async Task<RestNote?> ReplyAsync
    (
        string text,
        string? contentWarning = null,
        bool? localOnly = null,
        AcceptanceType? acceptanceType = null,
        bool? noExtractMentions = null,
        bool? noExtractHashtags = null,
        bool? noExtractEmojis = null,
        string? replyId = null,
        VisibilityType? visibilityType = null,
        Poll? poll = null
    )
        => await NoteHelper.CreateNoteAsync
        (
            Misskey, 
            text: text, 
            contentWarning: 
            contentWarning, 
            localOnly: localOnly,
            acceptanceType: acceptanceType,
            noExtractMentions: noExtractMentions, 
            noExtractHashtags: noExtractHashtags, 
            noExtractEmojis: noExtractEmojis, 
            replyId: Id,
            visibilityType: visibilityType,
            poll: poll
        );
    
    public async Task UnrenoteAsync()
        => throw new NotImplementedException();
    
    INote INote.Reply => Reply;
    INote INote.Renote => Renote;
    IUserLite INote.Author => Author;
    IReadOnlyCollection<IDriveFile> INote.Files => Files;
}