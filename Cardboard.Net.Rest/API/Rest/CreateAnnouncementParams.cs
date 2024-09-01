using Cardboard.Announcements;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class CreateAnnouncementParams
{
    [JsonProperty("title")]
    public required string Title { get; set; }
    
    [JsonProperty("text")]
    public required string Text { get; set; }
    
    /*
     * for some reason, this is a required property. overriding the null value
     * handling here
     */
    [JsonProperty("imageUrl", NullValueHandling = NullValueHandling.Include)]
    public Uri? ImageUrl { get; set; }
    
    [JsonProperty("icon")]
    public IconType? Icon { get; set; }
    
    [JsonProperty("display")]
    public DisplayType? Display { get; set; }
    
    [JsonProperty("forExistingUsers")]
    public bool? ForExistingUsers { get; set; }
    
    [JsonProperty("silence")]
    public bool? Silence { get; set; }
    
    [JsonProperty("needConfirmationToRead")]
    public bool? ReadConfirmation { get; set; }
    
    [JsonProperty("userId")]
    public string? UserId { get; set; }
}