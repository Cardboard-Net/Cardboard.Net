using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API.AuditLog;

internal class UnassignRole : AuditLogEntry
{
    // TODO: fix this.
    [JsonProperty("info")]
    public required UnassignRoleInfo Info { get; set; }
}

internal class UnassignRoleInfo
{
    [JsonProperty("roleId")]
    public required string RoleId { get; set; }
    
    [JsonProperty("userId")]
    public required string UserId { get; set; }
    
    [JsonProperty("roleName")]
    public required string RoleName { get; set; }
    
    [JsonProperty("userHost")]
    public required Uri Host { get; set; }
    
    [JsonProperty("userUsername")]
    public required string Username { get; set; }
}