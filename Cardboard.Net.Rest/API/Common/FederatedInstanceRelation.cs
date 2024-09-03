using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class FederatedInstanceRelation
{
    [JsonProperty("id")]
    public required string Id { get; set; }
    
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
    
    [JsonProperty("followeeId")]
    public required string FolloweeId { get; set; }
    
    [JsonProperty("followerId")]
    public required string FollowerId { get; set; }
    
    [JsonProperty("followee")]
    public required User Followee { get; set; }
    
    [JsonProperty("follower")]
    public required User Follower { get; set; }
}