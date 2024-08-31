using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class GenericChart
{
    [JsonProperty("total")]
    public virtual required int[] Total { get; set; }
    
    [JsonProperty("inc")]
    public virtual required int[] Increase { get; set; }
    
    [JsonProperty("dec")]
    public virtual required int[] Decrease { get; set; }
}

internal class GenericChartNotes : GenericChart
{
    [JsonProperty("diffs")]
    public required GenericNotesDiffs Diffs { get; set; }
}

internal class GenericNotesDiffs
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

internal class GenericDriveChart
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