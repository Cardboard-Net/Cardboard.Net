using Cardboard.Net.Entities.Instance.Announcements;
using Cardboard.Net.Rest;
using Newtonsoft.Json;
using RestSharp;

namespace Cardboard.Net.Entities.Instance;

/// <summary>
/// The full announcement
/// </summary>
public class Announcement : AnnouncementLite
{
    /// <summary>
    /// The icon type of the announcement
    /// </summary>
    [JsonProperty("icon")]
    public IconType IconType { get; internal set; }

    /// <summary>
    /// modifies the icon type
    /// </summary>
    /// <param name="iconType">The icon type to change it to</param>
    public async Task ModifyIconTypeAsync(IconType iconType)
    {
        if (this.IconType == iconType) return;

        await ModifyAsync(iconType: iconType);
    }
    
    /// <summary>
    /// The displaytype of the announcement
    /// </summary>
    [JsonProperty("displayType")]
    public DisplayType DisplayType { get; internal set; }

    /// <summary>
    /// modifies the display type
    /// </summary>
    /// <param name="displayType">The display type to change it to</param>
    public async Task ModifyDisplayTypeAsync(DisplayType displayType)
    {
        if (this.DisplayType == displayType) return;
        
        await ModifyAsync(displayType: displayType);
    }
    
    /// <summary>
    /// Whether the announcement needs a confirmation to read
    /// </summary>
    [JsonProperty("needConfirmationToRead")]
    public bool HasReadConfirmation { get; internal set; }
    
    /// <summary>
    /// Enable confirmation to read
    /// </summary>
    /// <exception cref="InvalidOperationException">Throws an exception if it has been enabled already</exception>
    public async Task EnableReadConfirmationAsync()
    {
        if (this.HasReadConfirmation)
        {
            throw new InvalidOperationException("This announcement has read confirmation enabled already!");
        }
        
        await ModifyAsync(readConfirmation: true);
    }

    /// <summary>
    /// Disable confirmation to read
    /// </summary>
    /// <exception cref="InvalidOperationException">Throws an exception if it has been disabled already</exception>
    public async Task DisableReadConfirmationAsync()
    {
        if (!this.HasReadConfirmation)
        {
            throw new InvalidOperationException("This announcement has read confirmation disabled already!");
        }
        
        await ModifyAsync(readConfirmation: false);
    }
    
    /// <summary>
    /// Whether the announcement is silenced
    /// </summary>
    [JsonProperty("silence")]
    public bool IsSilenced { get; internal set; }

    /// <summary>
    /// Silences the announcement
    /// </summary>
    /// <exception cref="InvalidOperationException">Throws an exception if it has been silenced already</exception>
    public async Task SilenceAsync()
    {
        if (this.IsSilenced)
        {
            throw new InvalidOperationException("This announcement has silence enabled already!");
        }

        await ModifyAsync(silence: true);
    }
    
    /// <summary>
    /// Unsilences the announcement
    /// </summary>
    /// <exception cref="InvalidOperationException">Throws an exception if it has been unsilenced already</exception>
    public async Task UnsilenceAsync()
    {
        if (!this.IsSilenced)
        {
            throw new InvalidOperationException("This announcement has silence disabled already!");
        }

        await ModifyAsync(silence: false);
    }
    
    /// <summary>
    /// Modifies the announcement
    /// </summary>
    /// <param name="title">The title of the announcement</param>
    /// <param name="text">The description of the announcement</param>
    /// <param name="imageUrl">The image url of the announcement</param>
    /// <param name="iconType">The icon type of the announcement</param>
    /// <param name="displayType">The display type of the announcement</param>
    /// <param name="existingUsers">Whether the announcement is for existing users</param>
    /// <param name="silence">Whether the announcement is silenced</param>
    /// <param name="readConfirmation">Whether the announcement has a read confirmation</param>
    /// <param name="isActive">Whether the announcement is active</param>
    public async Task ModifyAsync
    (
        string? title = null, 
        string? text = null,
        Uri? imageUrl = null, 
        IconType? iconType = null,
        DisplayType? displayType = null,
        bool? existingUsers = null,
        bool? silence = null,
        bool? readConfirmation = null,
        bool? isActive = null
    )
    {
        bool updated = await this.Misskey.ApiClient.ModifyAnnouncementAsync
        (
            this.Id, 
            title, 
            text, 
            imageUrl, 
            iconType, 
            displayType, 
            existingUsers, 
            silence, 
            readConfirmation, 
            isActive
        );

        if (!updated) return;
        
        RestResponse response = await this.Misskey.ApiClient.SendRequestAsync(Endpoints.INSTANCE_ANNOUNCEMENTS_SHOW, 
            JsonConvert.SerializeObject(new { announcementId = this.Id }));
        if (null == response.Content) return;
        
        Announcement? announcement = JsonConvert.DeserializeObject<Announcement>(response.Content); 
        if (null == announcement) return;
        
        this.Title = announcement.Title;
        this.Text = announcement.Text;
        this.ImageUrl = announcement.ImageUrl;
        this.IconType = announcement.IconType;
        this.DisplayType = announcement.DisplayType;
        this.IsSilenced = announcement.IsSilenced;
        this.HasReadConfirmation = announcement.HasReadConfirmation;
        if (isActive.HasValue) this.IsActive = isActive.Value;
    }
    
    /// <summary>
    /// Whether the announcement is for you
    /// </summary>
    [JsonProperty("forYou")]
    public bool IsForYou { get; internal set; }
    
    /// <summary>
    /// Whether the announcement has been read
    /// </summary>
    [JsonProperty("isRead")]
    public bool IsRead { get; internal set; }
    
    public async Task ReadAnnouncementAsync()
        => throw new NotImplementedException();
}