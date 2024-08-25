using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Net.Entities.Instance.Announcements;

/// <summary>
/// Display type of an announcement
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum DisplayType
{
    /// <summary>
    /// Normal announcement
    /// </summary>
    [EnumMember(Value = "normal")]
    Normal,
    /// <summary>
    /// Banner announcement
    /// </summary>
    [EnumMember(Value = "banner")]
    Banner,
    /// <summary>
    /// Dialog announcement
    /// </summary>
    [EnumMember(Value = "dialog")]
    Dialog   
}