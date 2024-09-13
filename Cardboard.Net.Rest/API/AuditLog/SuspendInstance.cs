using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API.AuditLog;

internal class SuspendInstance : AuditLogEntry
{
    // TODO: fix this.
    [JsonProperty("info")]
    public required SuspendInstanceInfo Info { get; set; }
}

internal class SuspendInstanceInfo
{
    [JsonProperty("id")]
    public required string Id { get; set; }
    
    [JsonProperty("host")]
    public required Uri Host { get; set; }
}