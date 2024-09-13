using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API.AuditLog;

internal class CreateGlobalAnnouncement : AuditLogEntry
{
    // TODO: fix this.
    [JsonProperty("info")]
    public required CreateGlobalAnnouncementInfo Info { get; set; }
}

internal class CreateGlobalAnnouncementInfo
{
    [JsonProperty("announcement")]
    public required AdminAnnouncement Announcement { get; set; }
    
    [JsonProperty("announcementId")]
    public required string AnnouncementId { get; set; }
}