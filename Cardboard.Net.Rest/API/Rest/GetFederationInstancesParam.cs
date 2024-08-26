using Cardboard.Instances;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class GetFederationInstancesParam
{
    [JsonProperty("host")]
    public string? Host { get; set; }
    
    [JsonProperty("blocked")]
    public bool? Blocked { get; set; }
    
    [JsonProperty("notResponding")]
    public bool? NotResponding { get; set; }
    
    [JsonProperty("suspended")]
    public bool? Suspended { get; set; }
    
    [JsonProperty("silenced")]
    public bool? Silenced { get; set; }
    
    [JsonProperty("federating")]
    public bool? Federating { get; set; }
    
    [JsonProperty("subscribing")]
    public bool? Subscribing { get; set; }
    
    [JsonProperty("publishing")]
    public bool? Publishing { get; set; }
    
    [JsonProperty("nsfw")]
    public bool? Nsfw { get; set; }
    
    [JsonProperty("bubble")]
    public bool? Bubble { get; set; }
    
    [JsonProperty("limit")]
    public int Limit { get; set; }
    
    [JsonProperty("offset")]
    public int Offset { get; set; }
    
    [JsonProperty("sort")]
    public InstanceSortType? Sort { get; set; }
}