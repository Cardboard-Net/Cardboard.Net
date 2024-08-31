using Cardboard.Announcements;

using Model = Cardboard.Net.Rest.API.Announcement;

namespace Cardboard.Rest.Announcements;

public class RestUserAnnouncement : RestEntity<string>, IAnnouncement, IUpdateable
{
    /// <inheritdoc/>
    public DateTime CreatedAt { get; private set; }
    
    /// <inheritdoc/>
    public DateTime? UpdatedAt { get; private set; }
    
    /// <inheritdoc/>
    public string Text { get; private set; }
    
    /// <inheritdoc/>
    public string Title { get; private set; }
    
    /// <inheritdoc/>
    public Uri? ImageUrl { get; private set; }
    
    /// <inheritdoc/>
    public IconType Icon { get; private set; }
    
    /// <inheritdoc/>
    public DisplayType Display { get; private set; }
    
    /// <inheritdoc/>
    public bool ReadConfirmation { get; private set; }
    
    /// <inheritdoc/>
    public bool Silence { get; private set; }
    
    /// <inheritdoc/>
    public bool ForYou { get; private set; }
    
    /// <inheritdoc/>
    public bool IsRead { get; private set; }
    
    public RestUserAnnouncement(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    internal static RestUserAnnouncement Create(BaseMisskeyClient misskey, Model model)
    {
        RestUserAnnouncement entity = new RestUserAnnouncement(misskey, model.Id);
        entity.Update(model);
        return entity;
    }

    internal void Update(Model model)
    {
        this.CreatedAt = model.CreatedAt;
        this.UpdatedAt = model.UpdatedAt;
        this.Text = model.Text;
        this.Title = model.Title;
        this.ImageUrl = model.ImageUrl;
        this.Icon = model.Icon;
        this.Display = model.Display;
        this.ReadConfirmation = model.ReadConfirmation;
        this.Silence = model.Silence;
        this.ForYou = model.ForYou;
        this.IsRead = model.IsRead;
    }
    
    public async Task UpdateAsync()
    {
        var model = await Misskey.ApiClient.GetAnnouncementAsync(Id);

        if (model == null)
            return;
        
        Update(model);
    }
    
    public async Task ReadAsync()
    {
        if (this.IsRead)
            throw new InvalidOperationException("This announcement is already read");

        await Misskey.ApiClient.ReadAnnouncementAsync(Id);
        await UpdateAsync();
    }
}