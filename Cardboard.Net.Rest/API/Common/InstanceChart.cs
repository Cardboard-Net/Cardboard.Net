using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class InstanceChart
{
    [JsonProperty("requests")]
    public required InstanceChartRequests Requests { get; set; }
    
    [JsonProperty("notes")]
    public required GenericChartNotes Notes { get; set; }
    
    [JsonProperty("users")]
    public required GenericChart Users { get; set; }
    
    [JsonProperty("following")]
    public required GenericChart Following { get; set; }
    
    [JsonProperty("followers")]
    public required GenericChart Followers { get; set; }
    
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

internal class InstanceChartDrive : GenericChart
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