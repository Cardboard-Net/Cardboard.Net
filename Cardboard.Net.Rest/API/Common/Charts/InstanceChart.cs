using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class InstanceChart
{
    [JsonProperty("requests")]
    public required InstanceChartRequests Requests { get; set; }
    
    [JsonProperty("notes")]
    public required InstanceChartNotes Notes { get; set; }
    
    [JsonProperty("users")]
    public required InstanceChartGeneric Users { get; set; }
    
    [JsonProperty("following")]
    public required InstanceChartGeneric Following { get; set; }
    
    [JsonProperty("followers")]
    public required InstanceChartGeneric Followers { get; set; }
    
    [JsonProperty("drive")]
    public required InstanceChartDrive Drive { get; set; }
}

internal class InstanceChartRequests
{
    [JsonProperty("failed")]
    public required int[] Failed { get; set; }
    
    [JsonProperty("succeeded")]
    public required int[] Succeeded { get; set; }
    
    [JsonProperty("received")]
    public required int[] Received { get; set; }
}

internal class InstanceChartGeneric
{
    [JsonProperty("total")]
    public virtual required int[] Total { get; set; }
    
    [JsonProperty("inc")]
    public virtual required int[] Increase { get; set; }
    
    [JsonProperty("dec")]
    public virtual required int[] Decrease { get; set; }
}

internal class InstanceChartNotes : InstanceChartGeneric
{
    [JsonProperty("diffs")]
    public required InstanceChartNotesDiffs Diffs { get; set; }
}

internal class InstanceChartNotesDiffs
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

internal class InstanceChartDrive : InstanceChartGeneric
{
    [JsonProperty("totalFiles")]
    public override required int[] Total { get; set; }
    
    [JsonProperty("incFile")]
    public override required int[] Increase { get; set; }
    
    [JsonProperty("decFiles")]
    public override required int[] Decrease { get; set; }
    
    [JsonProperty("incUsage")]
    public required ulong[] UsageIncrease { get; set; }
    
    [JsonProperty("decUsage")]
    public required ulong[] UsageDecrease { get; set; }
}