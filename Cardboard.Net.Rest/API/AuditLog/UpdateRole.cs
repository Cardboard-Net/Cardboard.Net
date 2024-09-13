using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API.AuditLog;

internal class UpdateRole : AuditLogEntry
{
    // TODO: fix this.
    [JsonProperty("info")]
    public required UpdateRoleInfo Info { get; set; }
}

internal class UpdateRoleInfo
{
    [JsonProperty("before")]
    public required Role Before { get; set; }
    
    [JsonProperty("after")]
    public required Role After { get; set; }
    
    [JsonProperty("roleId")]
    public required string RoleId { get; set; }
}