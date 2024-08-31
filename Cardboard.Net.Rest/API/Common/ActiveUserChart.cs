using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class ActiveUserChart
{
    [JsonProperty("readWrite")]
    public required int[] ReadWrite { get; set; } = [];

    [JsonProperty("read")] 
    public required int[] Read { get; set; } = [];

    [JsonProperty("write")] 
    public required int[] Write { get; set; } = [];

    [JsonProperty("registeredPastWeek")] 
    public required int[] RegisteredPastWeek { get; set; } = [];

    [JsonProperty("registeredPastMonth")] 
    public required int[] RegisteredPastMonth { get; set; } = [];

    [JsonProperty("registeredPastYear")] 
    public required int[] RegisteredPastYear { get; set; } = [];

    [JsonProperty("registeredBeforeWeek")] 
    public required int[] RegisteredBeforeWeek { get; set; } = [];

    [JsonProperty("registeredBeforeMonth")]
    public required int[] RegisteredBeforeMonth { get; set; } = [];

    [JsonProperty("registeredBeforeYear")]
    public required int[] RegisteredBeforeYear { get; set; } = [];
}