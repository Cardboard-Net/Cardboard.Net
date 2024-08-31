using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class NoteChart
{
    [JsonProperty("local")]
    public required NoteMetrics Local { get; set; }
    
    [JsonProperty("remote")]
    public required NoteMetrics Remote { get; set; }
}

internal class NoteMetrics
{
    [JsonProperty("total")]
    public required int[] Total { get; set; }
    
    [JsonProperty("increase")]
    public required int[] Increase { get; set; }
    
    [JsonProperty("decrease")]
    public required int[] Decrease { get; set; }
    
    [JsonProperty("diffs")]
    public required NoteDiffs Diffs { get; set; }
}

internal class NoteDiffs
{
    [JsonProperty("normal")]
    public required int[] Normal { get; set; }
    
    [JsonProperty("reply")]
    public required int[] Reply { get; set; }
    
    [JsonProperty("renote")]
    public required int[] Renote { get; set; }
    
    [JsonProperty("withFile")]
    public required int[] WithFile { get; set; }
}