using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class DriveChart
{
    [JsonProperty("local")]
    public required GenericDriveChart Local { get; set; }
    
    [JsonProperty("remote")]
    public required GenericDriveChart Remote { get; set; }
}