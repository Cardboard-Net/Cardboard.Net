using Cardboard.AuditLogs;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class AuditLog
{
    [JsonProperty("id")]
    public required string Id { get; set; }
    
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
    
    [JsonProperty("type")]
    public AuditLogType Type { get; set; }
    
    [JsonProperty("info")]
    public object Info { get; set; }
    
    [JsonProperty("userId")]
    public required string UserId { get; set; }
    
    [JsonProperty("user")]
    public required User User { get; set; }
}