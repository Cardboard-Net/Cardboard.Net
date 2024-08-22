using System.Text.Json.Serialization;
using Cardboard.Net.Entities;

namespace Cardboard.Net.Rest.Entities;

/// <summary>
/// When using /api/notes/create it returns 
/// { "createdAt":{
///     [...]
/// }}
/// This encapsulates a created note
/// </summary>
internal record class CreatedNote
{
    /// <summary>
    /// The note contained within
    /// </summary>
    [JsonPropertyName("createdNote")]
    public required Note Note { get; init; }
}