using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API.AuditLog;

internal class SuspendUser : AuditLogEntry
{
    // TODO: fix this.
    [JsonProperty("info")]
    public required SuspendUserInfo Info { get; set; }
}

internal class SuspendUserInfo
{
    [JsonProperty("userId")]
    public required string UserId { get; set; }
    
    [JsonProperty("userHost")]
    public required Uri? Host { get; set; }
    
    [JsonProperty("userUsername")]
    public required string Username { get; set; }
}