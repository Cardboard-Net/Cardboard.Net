using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class IndexStats
{
    [JsonProperty("schemaname")]
    public required string SchemaName { get; set; }
    
    [JsonProperty("tablename")]
    public required string TableName { get; set; }
    
    [JsonProperty("indexname")]
    public required string IndexName { get; set; }
    
    [JsonProperty("tablespace")]
    public required string? TableSpace { get; set; }
    
    [JsonProperty("indexdef")]
    public required string IndexDef { get; set; }
}