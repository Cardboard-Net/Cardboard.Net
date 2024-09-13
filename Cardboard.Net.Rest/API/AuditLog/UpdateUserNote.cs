using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API.AuditLog;

internal class UpdateUserNote : AuditLogEntry
{
    // TODO: fix this.
    [JsonProperty("info")]
    public required UpdateUserNoteInfo Info { get; set; }
}

internal class UpdateUserNoteInfo
{
    [JsonProperty("after")]
    public required string After { get; set; }
    
    [JsonProperty("before")]
    public required string Before { get; set; }
    
    [JsonProperty("userId")]
    public required string UserId { get; set; }
    
    [JsonProperty("userHost")]
    public required string UserHost { get; set; }
    
    [JsonProperty("userUsername")]
    public required string Username { get; set; }
}