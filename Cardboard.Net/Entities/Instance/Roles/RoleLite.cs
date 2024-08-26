using Newtonsoft.Json;

namespace Cardboard.Net.Entities;

public class RoleLite : MisskeyObject
{
    /// <summary>
    /// Name of the role
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; internal set; }
    
    /// <summary>
    /// Color of the role if there is one
    /// </summary>
    [JsonProperty("color")]
    public string? Color { get; internal set; }

    /// <summary>
    /// Url of the icon if there is one
    /// </summary>
    [JsonProperty("iconUrl")]
    public Uri? IconUrl { get; internal set; }

    /// <summary>
    /// Description of the role
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; internal set; }
    
    /// <summary>
    /// Whether the role is moderator
    /// </summary>
    [JsonProperty("isModerator")]
    public bool IsModerator { get; internal set; }
    
    /// <summary>
    /// Whether the role is administrator
    /// </summary>
    [JsonProperty("isAdministrator")]
    public bool IsAdministrator { get; internal set; }
    
    /// <summary>
    /// DisplayOrder of the role
    /// </summary>
    [JsonProperty("displayOrder")]
    public int DisplayOrder { get; internal set; }

    public async Task<Role?> GetRoleAsync()
        => throw new NotImplementedException();

}