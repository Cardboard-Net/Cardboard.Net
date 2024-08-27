using Cardboard.Announcements;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class Announcement
{
    [JsonProperty("id")]
    public required string Id { get; init; }
    
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; init; }
    
    [JsonProperty("updatedAt")]
    public DateTime? UpdatedAt { get; init; }
    
    [JsonProperty("text")]
    public required string Text { get; init; }
    
    [JsonProperty("title")]
    public required string Title { get; init; }
    
    [JsonProperty("imageUrl")]
    public Uri? ImageUrl { get; init; }
    
    [JsonProperty("icon")]
    public IconType Icon { get; init; }
    
    [JsonProperty("display")]
    public DisplayType Display { get; init; }
    
    [JsonProperty("needConfirmationToRead")]
    public bool ReadConfirmation { get; init; }
    
    [JsonProperty("silence")]
    public bool Silence { get; init; }
    
    [JsonProperty("forYou")]
    public bool ForYou { get; init; }
    
    [JsonProperty("isRead")] 
    public bool IsRead { get; init; }
}