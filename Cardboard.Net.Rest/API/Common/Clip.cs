using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class Clip
{
    [JsonProperty("id")]
    public required string Id { get; set; }
    
    [JsonProperty("createdAt")]
    public required DateTime CreatedAt { get; set; }
    
    [JsonProperty("lastClippedAt")]
    public required DateTime? LastClippedAt { get; set; }
    
    [JsonProperty("userId")]
    public required string UserId { get; set; }
    
    [JsonProperty("user")]
    public required UserLite User { get; set; }
    
    [JsonProperty("name")]
    public required string Name { get; set; }
    
    [JsonProperty("description")]
    public required string? Description { get; set; }
    
    [JsonProperty("isPublic")]
    public required bool IsPublic { get; set; }
    
    [JsonProperty("favoritedCount")]
    public required int FavoritedCount { get; set; }
    
    [JsonProperty("isFavorited")]
    public required bool IsFavorited { get; set; }
    
    [JsonProperty("notesCount")]
    public required int NotesCount { get; set; }
}