using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API.AuditLog;

internal class DeleteNote : AuditLogEntry
{
    // TODO: fix this.
    [JsonProperty("info")]
    public required DeleteNoteInfo Info { get; set; }
}

internal class DeleteNoteInfo
{
    [JsonProperty("note")]
    public required Note Note { get; set; }
    
    [JsonProperty("noteId")]
    public required string NoteId { get; set; }
    
    [JsonProperty("noteUserId")]
    public required string AuthorId { get; set; }
    
    [JsonProperty("noteUserHost")]
    public required Uri? Host { get; set; }
    
    [JsonProperty("noteUserUsername")]
    public required string AuthorUsername { get; set; }
}