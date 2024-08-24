using Cardboard.Net.Clients;
using Newtonsoft.Json;

namespace Cardboard.Net.Entities;

/// <summary>
/// Represents a misskey object
/// </summary>
public abstract class MisskeyObject
{
    /// <summary>
    /// The misskey:id of the current object
    /// </summary>
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; internal set; }
    
    /// <summary>
    /// Gets the client instance this object is tied to
    /// </summary>
    [JsonIgnore]
    internal BaseMisskeyClient Misskey { get; set; }
    
    internal MisskeyObject() {}
}
