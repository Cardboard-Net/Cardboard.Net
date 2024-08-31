using Cardboard.Clips;
using Cardboard.Users;

using Model = Cardboard.Net.Rest.API.Clip;

namespace Cardboard.Rest.Clips;

public class RestClip : RestEntity<string>, IClip, IUpdateable
{
    /// <inheritdoc/>
    public DateTime CreatedAt { get; private set; }
    
    /// <inheritdoc/>
    public DateTime? LastClipped { get; private set; }
    
    public IUserLite Owner { get; private set; }
    
    /// <inheritdoc/>
    public string Name { get; private set; }
    
    /// <inheritdoc/>
    public string? Description { get; private set; }
    
    /// <inheritdoc/>
    public bool IsPublic { get; private set; }
    
    /// <inheritdoc/>
    public int FavoritedCount { get; private set; }
    
    /// <inheritdoc/>
    public bool IsFavorited { get; private set; }
    
    /// <inheritdoc/>
    public int NotesCount { get; private set; }
    
    public RestClip(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    internal static RestClip Create(BaseMisskeyClient misskey, Model model)
    {
        RestClip entity = new(misskey, model.Id);
        entity.Update(model);
        return entity;
    }
    
    public async Task UpdateAsync()
    {
        var model = await Misskey.ApiClient.GetClipAsync(Id);

        if (model == null)
            return;
        
        Update(model);
    }

    internal void Update(Model model)
    {
        this.CreatedAt = model.CreatedAt;
        this.LastClipped = model.LastClippedAt;
        // TODO: owner
        this.Name = model.Name;
        this.Description = model.Description;
        this.IsPublic = model.IsPublic;
        this.FavoritedCount = model.FavoritedCount;
        this.IsFavorited = model.IsFavorited;
        this.NotesCount = model.NotesCount;
    }

    public async Task DeleteAsync()
        => await Misskey.ApiClient.DeleteClipAsync(Id);

    public async Task FavoriteAsync()
        => await Misskey.ApiClient.FavoriteClipAsync(Id);

    public async Task UnfavoriteAsync()
        => await Misskey.ApiClient.UnfavoriteClipAsync(Id);
}