using Cardboard.Charts;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class GetInstanceChartParams
{
    [JsonProperty("span")]
    public required ChartType Span { get; set; }
    
    [JsonProperty("limit")]
    public int? Limit { get; set; }
    
    [JsonProperty("offset")]
    public int? Offset { get; set; }
    
    [JsonProperty("host")]
    public required string Host { get; set; }
}