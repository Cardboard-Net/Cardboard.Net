using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class Emoji
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("aliases")]
    public string[] Aliases { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("category")]
    public string? Category { get; set; }
    
    [JsonProperty("host")]
    public string? Host { get; set; }
    
    [JsonProperty("url")]
    public Uri Url { get; set; }
    
    [JsonProperty("license")]
    public string? License { get; set; }
    
    [JsonProperty("isSensitive")]
    public bool IsSensitive { get; set; }
    
    [JsonProperty("localOnly")]
    public bool LocalOnly { get; set; }
    
    [JsonProperty("roleIdsThatcanBeUsedThisEmojiAsReaction")]
    public string[] AllowedRoleIds { get; set; }  
}