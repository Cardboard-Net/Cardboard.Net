using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class DriveChart
{
    [JsonProperty("local")]
    public required DriveMetrics Local { get; set; }
    
    [JsonProperty("remote")]
    public required DriveMetrics Remote { get; set; }
}

internal class DriveMetrics
{
    [JsonProperty("incCount")]
    public required int[] IncreaseCount { get; set; }
    
    [JsonProperty("incSize")]
    public required ulong[] IncreaseSize { get; set; }
    
    [JsonProperty("decCount")]
    public required int[] DecreaseCount { get; set; }
    
    [JsonProperty("decSize")]
    public required ulong[] DecreaseSize { get; set; }
}