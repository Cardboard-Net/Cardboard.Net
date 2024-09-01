using Cardboard.Instances;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class FederatedInstance
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("firstRetrievdAt")]
    public DateTime FirstRetrievedAt { get; set; }
    
    [JsonProperty("host")]
    public Uri Host { get; set; }
    
    [JsonProperty("usersCount")]
    public int UsersCount { get; set; }
    
    [JsonProperty("notesCount")]
    public int NotesCount { get; set; }
    
    [JsonProperty("followingCount")]
    public int FollowingCount { get; set; }
    
    [JsonProperty("followersCount")]
    public int FollowersCount { get; set; }
    
    [JsonProperty("isNotResponding")]
    public bool IsNotResponding { get; set; }
    
    [JsonProperty("isSuspended")]
    public bool IsSuspended { get; set; }
    
    [JsonProperty("suspensionState")]
    public SuspensionStateType SuspensionState { get; set; }
    
    [JsonProperty("isBlocked")]
    public bool IsBlocked { get; set; }
    
    [JsonProperty("softwareName")]
    public string? SoftwareName { get; set; }
    
    [JsonProperty("softwareVersion")]
    public string? SoftwareVersion { get; set; }
    
    [JsonProperty("openRegistrations")]
    public bool? OpenRegistrations { get; set; }
    
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("description")]
    public string? Description { get; set; }
    
    [JsonProperty("maintainerName")]
    public string? MaintainerName { get; set; }
    
    [JsonProperty("maintainerEmail")]
    public string? MaintainerEmail { get; set; }
    
    [JsonProperty("isSilenced")]
    public bool IsSilenced { get; set; }
    
    [JsonProperty("iconUrl")]
    public Uri? IconUrl { get; set; }
    
    [JsonProperty("faviconUrl")]
    public Uri? FaviconUrl { get; set; }
    
    [JsonProperty("themeColor")]
    public string? ThemeColor { get; set; }
    
    [JsonProperty("infoUpdatedAt")]
    public DateTime? LastUpdatedAt { get; set; }
    
    [JsonProperty("latestRequestReceivedAt")]
    public DateTime? LastRequestReceivedAt { get; set; }
    
    [JsonProperty("isNSFW")]
    public bool IsNSFW { get; set; }
    
    [JsonProperty("moderationNote")]
    public string? ModerationNote { get; set; }
}