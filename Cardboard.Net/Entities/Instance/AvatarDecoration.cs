using Newtonsoft.Json;

namespace Cardboard.Net.Entities;

/// <summary>
/// Represents an avatar decoration on the instance
/// </summary>
public class AvatarDecoration : MisskeyObject
{
    /// <summary>
    /// DateTime representing when the decoration was created
    /// </summary>
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; internal set; }
    
    /// <summary>
    /// DateTime representing when the decoration was updated (if ever)
    /// </summary>
    [JsonProperty("updatedAt")]
    public DateTime? UpdatedAt { get; internal set; }
    
    /// <summary>
    /// The name of the avatar decoration
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; internal set; }
    
    /// <summary>
    /// The description of the avatar decoration
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; internal set; }
    
    /// <summary>
    /// The url of the avatar decoration
    /// </summary>
    [JsonProperty("url")]
    public Uri Url { get; internal set; }
    
    [JsonIgnore]
    public IReadOnlyList<string> AllowedRoleIds
        => this.allowedRoleIds;

    [JsonProperty("roleIdsThatCanBeUsedThisDecoration")]
    internal List<string> allowedRoleIds = [];
    
    /// <summary>
    /// Fetches the roles corresponding with each id.
    /// </summary>
    /// <returns>IReadOnlyList containing the full role object</returns>
    public async Task<IReadOnlyList<Role>> GetRolesAsync()
        => throw new NotImplementedException("GetRoles is not implemented.");
    
    /// <summary>
    /// Updates this avatar decoration
    /// </summary>
    /// <param name="name">Optional name to change over to</param>
    /// <param name="description">Optional description</param>
    /// <param name="url">Optional url</param>
    /// <param name="roleIds">Optional list of role ids, set to null for no updating</param>
    /// <returns></returns>
    public async Task<AvatarDecoration> ModifyAsync(string? name = null, string? description = null, Uri? url = null, List<string>? roleIds = null)
        => throw new NotImplementedException("Modify is not implemented.");
    
    /// <summary>
    /// Deletes this avatar decoration
    /// </summary>
    public async Task DeleteAsync()
        => throw new NotImplementedException("Delete is not implemented.");
}