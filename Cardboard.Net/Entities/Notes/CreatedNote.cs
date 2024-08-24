using Newtonsoft.Json;

namespace Cardboard.Net.Entities.Notes;

/// <summary>
/// When using /api/notes/create it returns 
/// { "createdAt":{
///     [...]
/// }}
/// This encapsulates a created note
/// </summary>
internal record CreatedNote
{
    /// <summary>
    /// The note contained within
    /// </summary>
    [JsonProperty("createdNote")]
    public required Note Note { get; init; }
}