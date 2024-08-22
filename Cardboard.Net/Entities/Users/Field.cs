using System.Text.Json.Serialization;

namespace Cardboard.Net.Entities.Users;

/// <summary>
/// User configurable profile field
/// </summary>
public record class Field
{
    /// <summary>
    /// Name of the field
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    
    /// <summary>
    /// Description of the field
    /// </summary>
    [JsonPropertyName("value")]
    public required string Description { get; init; }
}