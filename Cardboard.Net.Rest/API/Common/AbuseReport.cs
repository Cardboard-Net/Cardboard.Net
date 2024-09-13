using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class AbuseReport
{
    [JsonProperty("id")]
    public required string Id { get; set; }
    
    [JsonProperty("createdAt")]
    public required DateTime CreatedAt { get; set; }
    
    [JsonProperty("comment")]
    public required string Comment { get; set; }
    
    [JsonProperty("resolved")]
    public required bool Resolved { get; set; }
    
    [JsonProperty("reporterId")]
    public required string ReporterId { get; set; }
    
    [JsonProperty("targetUserId")]
    public required string TargetUserId { get; set; }
    
    [JsonProperty("assigneeId")]
    public required string? AssigneeId { get; set; }
    
    [JsonProperty("reporter")]
    public required User Reporter { get; set; }
    
    [JsonProperty("targetUser")]
    public required User TargetUser { get; set; }
    
    [JsonProperty("assignee")]
    public required User? Assignee { get; set; }
}