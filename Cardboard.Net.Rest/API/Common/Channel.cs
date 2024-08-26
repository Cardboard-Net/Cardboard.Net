using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class Channel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
    
    [JsonProperty("lastNoteAt")]
    public DateTime? LastNoteAt { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("description")]
    public string? Description { get; set; }
    
    [JsonProperty("userId")]
    public string UserId { get; set; }
    
    [JsonProperty("bannerUrl")]
    public Uri? BannerUrl { get; set; }
    
    [JsonProperty("pinnedNoteIds")]
    public string[] PinnedNoteIds { get; set; }
    
    [JsonProperty("pinnedNotes")]
    public Note[] PinnedNotes { get; set; }
    
    [JsonProperty("color")]
    public string Color { get; set; }
    
    [JsonProperty("isArchived")]
    public bool IsArchived { get; set; }
    
    [JsonProperty("usersCount")]
    public int UsersCount { get; set; }
    
    [JsonProperty("notesCount")]
    public int NotesCount { get; set; }
    
    [JsonProperty("isSensitive")]
    public bool IsSensitive { get; set; }
    
    [JsonProperty("allowRenoteToExternal")]
    public bool AllowExternalRenote { get; set; }
    
    [JsonProperty("isFollowing")]
    public bool IsFollowing { get; set; }
    
    [JsonProperty("isFavorited")]
    public bool IsFavorited { get; set; }
}