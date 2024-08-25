using Cardboard.Net.Entities.Instance.Announcements;
using Cardboard.Net.Rest;
using Newtonsoft.Json;
using RestSharp;

namespace Cardboard.Net.Entities.Instance;

/// <summary>
/// A lite version of the announcement object, returned during create
/// </summary>
public class AnnouncementLite : MisskeyObject
{
    /// <summary>
    /// When the announcement was created
    /// </summary>
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; internal set; }

    /// <summary>
    /// WWhen the announcement was last updated (if ever)
    /// </summary>
    [JsonProperty("updatedAt")]
    public DateTime? UpdatedAt { get; internal set; }
    
    /// <summary>
    /// The title of the announcement
    /// </summary>
    [JsonProperty("title")]
    public string Title { get; internal set; }

    /// <summary>
    /// The text of the announcement
    /// </summary>
    [JsonProperty("text")]
    public string Text { get; internal set; }
    
    /// <summary>
    /// Url to the image if there is one
    /// </summary>
    [JsonProperty("imageUrl")]
    public Uri? ImageUrl { get; internal set; }

    /// <summary>
    /// Whether the announcement is active
    /// </summary>
    [JsonProperty("isActive")]
    public bool? IsActive { get; internal set; }

    /// <summary>
    /// Gets the full announcement type from this announcementlite
    /// </summary>
    /// <returns>Announcement, null if it fails</returns>
    public async Task<Announcement?> GetAnnouncementAsync()
    {
        Announcement? ret = await this.Misskey.ApiClient.GetAnnouncementAsync(this.Id);
        if (null == ret) return null;
        ret.IsActive = this.IsActive;
        return ret;
    }

    /// <summary>
    /// Activates this announcement
    /// </summary>
    /// <exception cref="InvalidOperationException">Throws an exception if it's already activated.</exception>
    public async Task ActivateAsync()
    {
        if (this.IsActive.HasValue && this.IsActive.Value)
        {
            throw new InvalidOperationException("The announcement is already activated!");
        }

        await ModifyAsync(isActive: true);
    }

    /// <summary>
    /// Deactivates this announcement
    /// </summary>
    /// <exception cref="InvalidOperationException">Throws an exception if it's already deactivated.</exception>
    public async Task DeactivateAsync()
    {
        if (this.IsActive.HasValue && !this.IsActive.Value)
        {
            throw new InvalidOperationException("The announcement is already deactivated!");
        }

        await ModifyAsync(isActive: false);
    }

    /// <summary>
    /// Modifies the title
    /// </summary>
    /// <param name="title">New title</param>
    public async Task ModifyTitleAsync(string title)
    {
        // not wasting an http call, not throwing an error to be a pain
        if (this.Title == title) return;
        
        await ModifyAsync(title: title);
    }

    /// <summary>
    /// Modifies the image url
    /// </summary>
    /// <param name="imageUrl">New image url</param>
    public async Task ModifyImageUrlAsync(Uri imageUrl)
    {
        if (this.ImageUrl == imageUrl) return;
        
        await ModifyAsync(imageUrl: imageUrl);
    }
    
    /// <summary>
    /// Modifies the announcement
    /// </summary>
    /// <param name="title">The title of the announcement</param>
    /// <param name="text">The description of the announcement</param>
    /// <param name="imageUrl">The image url</param>
    /// <param name="existingUsers">Whether this announcement is for existing users</param>
    /// <param name="readConfirmation">Whether this announcement requires a read confirmation</param>
    /// <param name="isActive">Whether this announcement is active</param>
    public async Task ModifyAsync
    (
        string? title = null, 
        string? text = null,
        Uri? imageUrl = null, 
        bool? existingUsers = null,
        bool? isActive = null
    )
    {
        bool updated = await this.Misskey.ApiClient.ModifyAnnouncementAsync
        (
            this.Id, 
            title, 
            text, 
            imageUrl, 
            existingUsers,
            isActive
        );

        if (!updated) return;
        
        RestResponse response = await this.Misskey.ApiClient.SendRequestAsync(Endpoints.INSTANCE_ANNOUNCEMENTS_SHOW, 
            JsonConvert.SerializeObject(new { announcementId = this.Id }));
        if (null == response.Content) return;
        
        AnnouncementLite? announcement = JsonConvert.DeserializeObject<AnnouncementLite>(response.Content); 
        if (null == announcement) return;
        
        this.Title = announcement.Title;
        this.Text = announcement.Text;
        this.ImageUrl = announcement.ImageUrl;
        this.IsActive = announcement.IsActive;
        if (isActive.HasValue) this.IsActive = isActive.Value;
    }
    
    public async Task DeleteAsync()
        => await this.Misskey.ApiClient.DeleteAnnouncementAsync(this.Id);
}

/// <summary>
/// An admin announcement lite, encapsulating the reads property
/// </summary>
public class AdminAnnouncementLite : AnnouncementLite
{
    /// <summary>
    /// The number of reads for this announcement
    /// </summary>
    [JsonProperty("reads")]
    public ulong Reads { get; init; }
}