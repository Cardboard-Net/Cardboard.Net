using System.Collections.Immutable;
using Cardboard.Drives;
using Cardboard.Extensions;
using Cardboard.Notes;
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
    
    public DateTime CreatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public string? Text { get; private set; }
    public string? ContentWarning { get; private set; }
    public RestUserLite? Author { get; private set; }
    public RestNote? Reply { get; private set; }
    public RestNote? Renote { get; private set; }
    public bool IsHidden { get; private set; }
    public VisibilityType Visibility { get; private set; }
    public IReadOnlyCollection<string> Mentions => _mentions;
    public IReadOnlyCollection<string> VisibleUserIds => _visibleUserIds;
    public IReadOnlyCollection<string> Tags => _tags;
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
        Update(model);
    }

    public async Task DeleteAsync()
        => await Misskey.ApiClient.DeleteNoteAsync(Id);
    
    public async Task MuteThreadAsync() 
        => throw new NotImplementedException();
    
    public async Task UnmuteThreadAsync()
        => throw new NotImplementedException();
    
    public async Task<IReadOnlyCollection<RestNote>> GetRenotesAsync()
        => throw new NotImplementedException();
    
    public async Task<IReadOnlyCollection<RestNote>> GetRepliesAsync() 
        => throw new NotImplementedException();
    
    public async Task RenoteAsync()
        => throw new NotImplementedException();
    
    public async Task UnRenoteAsync()
        => throw new NotImplementedException();
    
    public async Task ModifyAsync()
        => throw new NotImplementedException();
    
    INote INote.Reply => Reply;
    INote INote.Renote => Renote;
    IUserLite INote.Author => Author;
    IReadOnlyCollection<IDriveFile> INote.Files => Files;
}