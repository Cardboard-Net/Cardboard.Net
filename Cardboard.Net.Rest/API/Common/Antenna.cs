using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class Antenna
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("keywords")]
    public string[] Keywords { get; set; }
    
    [JsonProperty("excludeKeywords")]
    public string[] ExcludeKeywords { get; set; }
    
    [JsonProperty("source")]
    public string Source { get; set; }
    
    // no idea what this is
    [JsonProperty("userListId")]
    public string? UserListId { get; set; }
    
    // says "array of strings" wonder if it's an array of user ids? 
    [JsonProperty("users")]
    public string[] Users { get; set; }
    
    [JsonProperty("caseSensitive")]
    public bool CaseSensitive { get; set; }
    
    [JsonProperty("localOnly")]
    public bool LocalOnly { get; set; }
    
    [JsonProperty("excludeBots")]
    public bool ExcludeBots { get; set; }
    
    [JsonProperty("withReplies")]
    public bool WithReplies { get; set; }
    
    [JsonProperty("withFile")]
    public bool WithFile { get; set; }
    
    [JsonProperty("isActive")]
    public bool IsActive { get; set; }
    
    [JsonProperty("hasUnreadNote")]
    public bool HasUnreadNote { get; set; }
    
    [JsonProperty("notify")]
    public bool Notify { get; set; }
}