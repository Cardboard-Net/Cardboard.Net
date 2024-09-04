using System.Collections.Immutable;
using Cardboard.Channels;
using Cardboard.Notes;
using Cardboard.Rest.Notes;

using Model = Cardboard.Net.Rest.API.Channel;

namespace Cardboard.Rest.Channels;

public class RestChannel : RestEntity<string>, IChannel, IUpdateable
{
    private ImmutableArray<RestNote> pinnedNotes;
    
    /// <inheritdoc/>
    public DateTime CreatedAt { get; private set; }
    
    /// <inheritdoc/>
    public DateTime? LastNoteAt { get; private set; }
    
    /// <inheritdoc/>
    public string Name { get; private set; }
    
    /// <inheritdoc/>
    public string? Description { get; private set; }
    
    /// <inheritdoc/>
    public string? UserId { get; private set; }
    
    /// <inheritdoc/>
    public Uri? BannerUrl { get; private set; }
    
    /// <summary>
    ///     List of pinned notes as rest notes
    /// </summary>
    public IReadOnlyCollection<RestNote> PinnedNotes => pinnedNotes;
    
    /// <inheritdoc/>
    public string Color { get; private set; }
    
    /// <inheritdoc/>
    public int NotesCount { get; private set; }
    
    /// <inheritdoc/>
    public int UsersCount { get; private set; }
    
    /// <inheritdoc/>
    public bool IsArchived { get; private set; }
    
    /// <inheritdoc/>
    public bool IsSensitive { get; private set; }
    
    /// <inheritdoc/>
    public bool AllowExternalRenotes { get; private set; }
    
    /// <inheritdoc/>
    public bool IsFollowing { get; private set; }
    
    /// <inheritdoc/>
    public bool IsFavorited { get; private set; }
    
    public RestChannel(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    internal static RestChannel Create(BaseMisskeyClient misskey, Model model)
    {
        RestChannel entity = new(misskey, model.Id);
        entity.Update(model);
        return entity;
    }
    
    internal void Update(Model model)
    {
        this.CreatedAt = model.CreatedAt;
        this.LastNoteAt = model.LastNoteAt;
        this.Name = model.Name;
        this.Description = model.Description;
        this.UserId = model.UserId;
        this.BannerUrl = model.BannerUrl;
        
        if (model.PinnedNotes != null && model.PinnedNotes.Length != 0)
        {
            var notes = ImmutableArray.CreateBuilder<RestNote>(model.PinnedNotes.Length);
            
            foreach (var n in model.PinnedNotes)
                notes.Add(RestNote.Create(Misskey, n));

            this.pinnedNotes = notes.ToImmutable();
        }
        else
        {
            this.pinnedNotes = new ImmutableArray<RestNote>();
        }

        this.Color = model.Color;
        this.NotesCount = model.NotesCount;
        this.UsersCount = model.UsersCount;
        this.IsArchived = model.IsArchived;
        this.IsSensitive = model.IsArchived;
        this.AllowExternalRenotes = model.AllowExternalRenotes;
        this.IsFollowing = model.IsFollowing;
        this.IsFavorited = model.IsFavorited;
    }
    
    public Task UpdateAsync()
    {
        throw new NotImplementedException();
    }
    
    public async Task ArchiveAsync()
        => await this.Misskey.ApiClient.ArchiveChannelAsync(this.Id);

    IReadOnlyCollection<INote> IChannel.PinnedNotes => PinnedNotes;
}