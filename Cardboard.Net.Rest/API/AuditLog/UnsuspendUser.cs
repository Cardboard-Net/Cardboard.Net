using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API.AuditLog;

internal class UnsuspendUser : AuditLogEntry
{
    // TODO: fix this.
    [JsonProperty("info")]
    public required SuspendUserInfo Info { get; set; }
}