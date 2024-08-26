using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class Clip
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
    
    [JsonProperty("lastClippedAt")]
    public DateTime? LastClippedAt { get; set; }
    
    [JsonProperty("userId")]
    public string UserId { get; set; }
    
    [JsonProperty("user")]
    public UserLite User { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("description")]
    public string Description { get; set; }
    
    [JsonProperty("favoritedCount")]
    public int FavoritedCount { get; set; }
    
    [JsonProperty("isFavorited")]
    public bool IsFavorited { get; set; }
    
    [JsonProperty("notesCount")]
    public int NotesCount { get; set; }
}