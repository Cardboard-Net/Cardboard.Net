using Cardboard.Users;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class GetAdminShowUsersParams
{
    [JsonProperty("limit")]
    public int? Limit { get; set; }
    
    [JsonProperty("offset")]
    public int? Offset { get; set; }
    
    [JsonProperty("sort")]
    public UserSortType? Sort { get; set; }
    
    [JsonProperty("state")]
    public UserStateType? State { get; set; }
    
    [JsonProperty("origin")]
    public UserOriginType? Origin { get; set; }
    
    [JsonProperty("username")]
    public string? Username { get; set; }
    
    [JsonProperty("hostname")]
    public string? Hostname { get; set; }
}