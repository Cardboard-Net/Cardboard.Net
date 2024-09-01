using Cardboard.Announcements;
using Cardboard.Net.Rest.API;

namespace Cardboard.Rest.Announcements;

public class RestAdminAnnouncement : RestEntity<string>, IAdminAnnouncement
{
    /// <inheritdoc/>
    public DateTime CreatedAt { get; private set; }
    
    /// <inheritdoc/>
    public DateTime? UpdatedAt { get; private set; }
    
    /// <inheritdoc/>
    public string Title { get; private set; }
    
    /// <inheritdoc/>
    public string Text { get; private set; }
    
    /// <inheritdoc/>
    public Uri? ImageUrl { get; private set; }
    
    /// <inheritdoc/>
    public int Reads { get; private set; }
    
    public RestAdminAnnouncement(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    internal static RestAdminAnnouncement Create(BaseMisskeyClient misskey, AdminAnnouncement model)
    {
        RestAdminAnnouncement entity = new RestAdminAnnouncement(misskey, model.Id);
        entity.Update(model);
        return entity;
    }

    internal void Update(AdminAnnouncement model)
    {
        this.CreatedAt = model.CreatedAt;
        this.UpdatedAt = model.UpdatedAt;
        this.Title = model.Title;
        this.Text = model.Text;
        this.ImageUrl = model.ImageUrl;
        this.Reads = model.Reads;
    }

    public async Task ModifyAsync(Action<AnnouncementProperties> args)
    {
        AnnouncementProperties props = new AnnouncementProperties();
        args(props);

        bool success = await AnnouncementHelper.ModifyAdminAnnouncementAsync(this, Misskey, props);

        if (!success)
            return;
        
        UpdatedAt = DateTime.Now; // Hacky, might be slightly inaccurate
        Title = props.Title ?? Title;
        Text = props.Text ?? Text;
        ImageUrl = props.ImageUrl ?? ImageUrl;
    }

    public async Task ActivateAsync()
        => await AnnouncementHelper.ModifyAdminAnnouncementAsync(this, Misskey, new AnnouncementProperties() { IsActive = true });

    public async Task DeactivateAsync()
        => await AnnouncementHelper.ModifyAdminAnnouncementAsync(this, Misskey, new AnnouncementProperties() { IsActive = false });

    public async Task DeleteAsync()
        => await Misskey.ApiClient.DeleteAnnouncementAsync(Id);
}