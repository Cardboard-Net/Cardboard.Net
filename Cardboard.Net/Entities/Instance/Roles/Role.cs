using Newtonsoft.Json;

namespace Cardboard.Net.Entities;

/// <summary>
/// A role on misskey
/// </summary>
public class Role : RoleLite
{
    /// <summary>
    /// DateTime of when the role was created
    /// </summary>
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; internal set; }
    
    /// <summary>
    /// DateTime of when the role was updated if ever
    /// </summary>
    [JsonProperty("updatedAt")]
    public DateTime? UpdatedAt { get; internal set; }
    
    /// <summary>
    /// If the role is public
    /// </summary>
    [JsonProperty("isPublic")]
    public bool IsPublic { get; internal set; }
    
    /// <summary>
    /// If you can see the role members
    /// </summary>
    [JsonProperty("isExplorable")]
    public bool IsExplorable { get; internal set; }
    
    /// <summary>
    /// Whether the role has a badge
    /// </summary>
    [JsonProperty("asBadge")]
    public bool AsBadge { get; internal set; }
    
    /// <summary>
    /// Whether moderators can edit the role's membership
    /// </summary>
    [JsonProperty("canEditMembersByModerator")]
    public bool CanModEditMembers { get; internal set; }
    
    /// <summary>
    /// Total amount of users with the role
    /// </summary>
    [JsonProperty("usersCount")]
    public int UsersCount { get; internal set; }
}