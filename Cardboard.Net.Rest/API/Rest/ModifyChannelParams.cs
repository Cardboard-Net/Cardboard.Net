

using Newtonsoft.Json;

internal class ModifyChannelParams {

    [JsonProperty("channelId")]
    public required string ChannelId {get; set;} 

    [JsonProperty("name")]
    public string? Name {get; set;}    

    [JsonProperty("description")]
    public string? Description {get; set;}
    
    [JsonProperty("bannerId")]
    public string? BannerId {get; set;}

    [JsonProperty("isArchived")]
    public bool? IsArchived {get; set;}
    
    [JsonProperty("pinnedNoteIds")]
    public string[]? PinnedNoteIds {get; set;}

    [JsonProperty("color")]
    public string? Color {get; set;}

    [JsonProperty("isSensitive")]
    public bool? IsSensitive {get; set;}

    [JsonProperty("allowRenoteToExternal")]
    public bool? AllowRenoteToExternal {get; set;}

    
}