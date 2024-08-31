using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class UserRelationChart
{
    [JsonProperty("local")]
    public required RelationChart Local { get; set; }
    
    [JsonProperty("remote")]
    public required RelationChart Remote { get; set; }
}

internal class RelationChart
{
    [JsonProperty("followings")]
    public required GenericChart Followings { get; set; }
    
    [JsonProperty("followers")]
    public required GenericChart Followers { get; set; }
}