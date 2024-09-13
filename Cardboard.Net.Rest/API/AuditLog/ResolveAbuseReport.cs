using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API.AuditLog;

internal class ResolveAbuseReport : AuditLogEntry
{
    // TODO: fix this.
    [JsonProperty("info")]
    public required ResolveAbuseReportInfo Info { get; set; }
}

internal class ResolveAbuseReportInfo
{
    [JsonProperty("report")]
    public required AbuseReport Report { get; set; }
    
    [JsonProperty("reportId")]
    public required string ReportId { get; set; }
    
    [JsonProperty("forwarded")]
    public required bool Forwarded { get; set; }
}