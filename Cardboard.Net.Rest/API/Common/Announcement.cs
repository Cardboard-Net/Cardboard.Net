using Cardboard.Announcements;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class Announcement
{
    [JsonProperty("id")]
    public required string Id { get; init; }
    
    [JsonProperty("createdAt")]
    public required DateTime CreatedAt { get; init; }
    
    [JsonProperty("updatedAt")]
    public required DateTime? UpdatedAt { get; init; }
    
    [JsonProperty("text")]
    public required string Text { get; init; }
    
    [JsonProperty("title")]
    public required string Title { get; init; }
    
    [JsonProperty("imageUrl")]
    public required Uri? ImageUrl { get; init; }
}

internal class UserAnnouncement : Announcement
{
    [JsonProperty("icon")]
    public required IconType Icon { get; init; }
    
    [JsonProperty("display")]
    public required DisplayType Display { get; init; }
    
    [JsonProperty("needConfirmationToRead")]
    public required bool ReadConfirmation { get; init; }
    
    [JsonProperty("silence")]
    public required bool Silence { get; init; }
    
    [JsonProperty("forYou")]
    public required bool ForYou { get; init; }
    
    [JsonProperty("isRead")] 
    public required bool IsRead { get; init; }
}

internal class AdminAnnouncement : Announcement
{
    [JsonProperty("reads")] 
    public required int Reads { get; set; } = 0;
}