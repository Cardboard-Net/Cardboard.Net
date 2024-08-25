using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Net.Entities.Instance.Announcements;

[JsonConverter(typeof(StringEnumConverter))]
public enum IconType
{
    /// <summary>
    /// Info icon
    /// </summary>
    [EnumMember(Value = "info")]
    Info,
    /// <summary>
    /// Warning icon
    /// </summary>
    [EnumMember(Value = "warning")]
    Warning,
    /// <summary>
    /// Error icon
    /// </summary>
    [EnumMember(Value = "error")]
    Error,
    /// <summary>
    /// Success icon
    /// </summary>
    [EnumMember(Value = "success")]
    Success
}
