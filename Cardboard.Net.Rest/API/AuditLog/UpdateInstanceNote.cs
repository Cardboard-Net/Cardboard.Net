using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API.AuditLog;

internal class UpdateInstanceNote : AuditLogEntry
{
    // TODO: fix this.
    [JsonProperty("info")]
    public required UpdateInstanceNoteInfo Info { get; set; }
}

internal class UpdateInstanceNoteInfo
{
    [JsonProperty("id")]
    public required string Id { get; set; }
    
    [JsonProperty("host")]
    public required Uri Host { get; set; }
    
    [JsonProperty("before")]
    public required string Before { get; set; }
    
    [JsonProperty("after")]
    public required string After { get; set; }
}