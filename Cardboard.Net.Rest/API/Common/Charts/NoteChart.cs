using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class NoteChart
{
    [JsonProperty("local")]
    public required GenericChartNotes Local { get; set; }
    
    [JsonProperty("remote")]
    public required GenericChartNotes Remote { get; set; }
}