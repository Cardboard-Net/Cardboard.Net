using Cardboard.Announcements;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class ModifyAnnouncementParams
{
    [JsonProperty("id")]
    public required string Id { get; set; }
    
    [JsonProperty("title")]
    public string? Title { get; set; }
    
    [JsonProperty("text")]
    public string? Text { get; set; }
    
    [JsonProperty("imageUrl")]
    public Uri? ImageUrl { get; set; }
    
    [JsonProperty("icon")]
    public IconType? Icon { get; set; }
    
    [JsonProperty("display")]
    public DisplayType Display { get; set; }
    
    [JsonProperty("forExistingUsers")]
    public bool? ForExistingUsers { get; set; }
    
    [JsonProperty("needConfirmationToRead")]
    public bool? ReadConfirmation { get; set; }
    
    [JsonProperty("isActive")]
    public bool? IsActive { get; set; }
}