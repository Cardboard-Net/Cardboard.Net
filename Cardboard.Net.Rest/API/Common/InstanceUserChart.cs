using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class InstanceUserChart
{
    [JsonProperty("local")]
    public required GenericChart Local { get; set; }
    
    [JsonProperty("remote")]
    public required GenericChart Remote { get; set; }
}