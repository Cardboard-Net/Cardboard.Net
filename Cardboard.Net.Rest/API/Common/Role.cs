using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class BadgeRole
{
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("iconUrl")]
    public Uri? IconUrl { get; set; }
    
    [JsonProperty("displayOrder")]
    public int DisplayOrder { get; set; }
}

internal class RoleLite : BadgeRole
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("color")]
    public string? Color { get; set; }
    
    [JsonProperty("description")]
    public string Description { get; set; }
    
    [JsonProperty("isModerator")]
    public bool IsModerator { get; set; }
    
    [JsonProperty("isAdministrator")]
    public bool IsAdministrator { get; set; }
}

internal class Role : RoleLite
{
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
    
    [JsonProperty("updatedAt")]
    public DateTime? UpdatedeAt { get; set; }

    //TODO: target
    
    //TODO: condFormula
    
    [JsonProperty("isPublic")]
    public bool IsPublic { get; set; }
    
    [JsonProperty("isExplorable")]
    public bool IsExplorable { get; set; }
    
    [JsonProperty("asBadge")]
    public bool AsBadge { get; set; }
    
    [JsonProperty("canEditMembersByModerator")]
    public bool ModEditUsers { get; set; }
    
    //TODO: policies
    
    [JsonProperty("usersCount")]
    public int UsersCount { get; set; }
}