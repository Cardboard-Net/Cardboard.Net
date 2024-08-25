using Newtonsoft.Json;

/*
 * I am not going to force my opinion on everyone, this library *will* not handle
 * interspersing advertisements between notes. Whether you decide to include
 * loading advertisements in your client is *entirely* up to you. I know this
 * may be considered a dick move to instances utilizing ads, but I do not care to
 * enforce it on a library level. That is up to individual client developers, and
 * I *will* not budge on this. I wanted to provide the ability to view, modify
 * and create advertisements. This is a library intended to be used by both bots
 * and people wanting to develop various "user" clients such as something written
 * in Microsoft's maui. 
 * https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui?view=net-maui-8.0
 */

namespace Cardboard.Net.Entities;

/// <summary>
/// Class representing an advertisement
/// </summary>
public class Ad : MisskeyObject
{
    /// <summary>
    /// Place
    /// </summary>
    [JsonProperty("place")]
#pragma warning disable CS8618
    public string Place { get; internal set; }
#pragma warning restore CS8618

    /// <summary>
    /// Ad ratio
    /// </summary>
    [JsonProperty("ratio")]
    public int Ratio { get; internal set; }

    /// <summary>
    /// Uri corresponding to the ad url
    /// </summary>
    [JsonProperty("url")]
#pragma warning disable CS8618
    public Uri Url { get; internal set; }
#pragma warning restore CS8618

    /// <summary>
    /// Uri corresponding to the ad's image
    /// </summary>
    [JsonProperty("imageUrl")]
#pragma warning disable CS8618
    public Uri ImageUrl { get; internal set; }
#pragma warning restore CS8618
    
    /// <summary>
    /// Number corresponding to day of week
    /// TODO: see if 0-6 or 1-7, make enum
    /// </summary>
    [JsonProperty("dayOfWeek")]
    public int DayOfWeek { get; internal set; }
}

/// <summary>
/// Class representing the ad if you're an administrator
/// </summary>
public class AdminAd : Ad
{
    /// <summary>
    /// DateTime representing when the ad expires
    /// </summary>
    [JsonProperty("expiresAt")]
    public DateTime ExpiresAt { get; internal set; }

    /// <summary>
    /// DateTime representing when the ad starts
    /// </summary>
    [JsonProperty("startsAt")]
    public DateTime StartsAt { get; protected set; }

    /// <summary>
    /// Ad priority
    /// </summary>
    [JsonProperty("priority")]
    public string Priority { get; internal set; }

    /// <summary>
    /// Ad memo
    /// </summary>
    [JsonProperty("memo")]
#pragma warning disable CS8618
    public string? Memo { get; protected set; }
#pragma warning restore CS8618
}