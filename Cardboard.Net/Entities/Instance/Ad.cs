using Newtonsoft.Json;

namespace Cardboard.Net.Entities;

/// <summary>
/// Class representing an advertisement
/// </summary>
public class Ad
{
    /// <summary>
    /// misskey:id representing the ad
    /// </summary>
    [JsonProperty("id", Required = Required.Always)]
#pragma warning disable CS8618
    public string Id { get; protected set; }
#pragma warning restore CS8618

    /// <summary>
    /// DateTime representing when the ad expires
    /// </summary>
    [JsonProperty("expiresAt")]
    public DateTime ExpiresAt { get; protected set; }

    /// <summary>
    /// DateTime representing when the ad starts
    /// </summary>
    [JsonProperty("startsAt")]
    public DateTime StartsAt { get; protected set; }

    /// <summary>
    /// Place
    /// </summary>
    [JsonProperty("place")]
#pragma warning disable CS8618
    public string Place { get; protected set; }
#pragma warning restore CS8618

    /// <summary>
    /// Ad priority
    /// </summary>
    [JsonProperty("priority")]
#pragma warning disable CS8618
    public string Priority { get; protected set; }
#pragma warning restore CS8618

    /// <summary>
    /// Ad ratio
    /// </summary>
    [JsonProperty("ratio")]
    public int Ratio { get; protected set; }

    /// <summary>
    /// Uri corresponding to the ad url
    /// </summary>
    [JsonProperty("url")]
#pragma warning disable CS8618
    public Uri Url { get; protected set; }
#pragma warning restore CS8618

    /// <summary>
    /// Uri corresponding to the ad's image
    /// </summary>
    [JsonProperty("imageUrl")]
#pragma warning disable CS8618
    public Uri ImageUrl { get; protected set; }
#pragma warning restore CS8618

    /// <summary>
    /// Ad memo
    /// </summary>
    [JsonProperty("memo")]
#pragma warning disable CS8618
    public string Memo { get; protected set; }
#pragma warning restore CS8618

    /// <summary>
    /// Number corresponding to day of week
    /// TODO: see if 0-6 or 1-7, make enum
    /// </summary>
    [JsonProperty("dayOfWeek")]
    public int DayOfWeek { get; protected set; }
}
