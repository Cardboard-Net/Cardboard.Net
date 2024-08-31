using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class UserDriveChart : GenericDriveChart
{
    [JsonProperty("totalCount")]
    public required int[] TotalCount { get; set; }
    
    [JsonProperty("totalSize")]
    public required ulong[] TotalSize { get; set; }
}