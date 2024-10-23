using Cardboard.Errors;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class Error
{
    [JsonProperty("error")]
    public required ErrorBody Body { get; set; }
}

internal class ErrorBody
{
    [JsonProperty("message")]
    public required string Message { get; set; }
    
    [JsonProperty("code")]
    public required string Code { get; set; }
    
    [JsonProperty("id")]
    public required string Id { get; set; }
    
    [JsonProperty("kind")]
    public required ErrorKindType Kind { get; set; }
}