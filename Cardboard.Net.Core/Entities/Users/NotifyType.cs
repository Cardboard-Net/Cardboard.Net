using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Users;

[JsonConverter(typeof(StringEnumConverter))]
public enum NotifyType
{
    /// <summary>
    /// Normal notifications
    /// </summary>
    [EnumMember(Value = "normal")]
    Normal,
    /// <summary>
    /// No notifications
    /// </summary>
    [EnumMember(Value = "none")]
    None
}