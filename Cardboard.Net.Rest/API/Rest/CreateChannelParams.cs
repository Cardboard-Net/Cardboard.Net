

using Newtonsoft.Json;

internal class CreateChannelParams {
    [JsonProperty("name")]
    public required string Name {get; set;}    

    [JsonProperty("description")]
    public string? Description {get; set;}
    
    [JsonProperty("bannerId")]
    public string? BannerId {get; set;}

    [JsonProperty("color")]
    public string? Color {get; set;}

    [JsonProperty("isSensitive")]
    public bool? IsSensitive {get; set;}

    [JsonProperty("allowRenoteToExternal")]
    public bool? AllowRenoteToExternal {get; set;}
}