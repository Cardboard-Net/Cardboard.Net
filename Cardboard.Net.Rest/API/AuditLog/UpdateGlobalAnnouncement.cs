using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API.AuditLog;

internal class UpdateGlobalAnnouncement : AuditLogEntry
{
    // TODO: fix this.
    [JsonProperty("info")]
    public required UpdateGlobalAnnouncementInfo Info { get; set; }
}

internal class UpdateGlobalAnnouncementInfo
{
    [JsonProperty("announcementId")]
    public required string AnnouncementId { get; set; }

    [JsonProperty("before")]
    public required AdminAnnouncement Before { get; set; }
    
    [JsonProperty("after")]
    public required AdminAnnouncement After { get; set; }
}