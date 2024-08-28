using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class ModifyFolderParams
{
    [JsonProperty("folderId")]
    public required string Id { get; set; }
    
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("parentId")]
    public string? ParentId { get; set; }
}