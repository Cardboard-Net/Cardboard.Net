using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class Ad
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("url")]
    public Uri? Url { get; set; }
    
    [JsonProperty("place")]
    public string Place { get; set; }
    
    [JsonProperty("ratio")]
    public int Ratio { get; set; }
    
    [JsonProperty("imageUrl")]
    public Uri? ImageUrl { get; set; }
    
    // TODO: Turn this into an enum
    [JsonProperty("dayOfWeek")]
    public int DayOfWeek { get; set; }
}