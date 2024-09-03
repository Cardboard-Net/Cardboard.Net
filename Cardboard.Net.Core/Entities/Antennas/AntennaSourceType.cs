using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Antennas;

/// <summary>
///     Represents the various sources for antennas
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum AntennaSourceType
{
    /// <summary>
    ///     The home timeline
    /// </summary>
    [EnumMember(Value = "home")]
    Home,
    /// <summary>
    ///     Specific users
    /// </summary>
    [EnumMember(Value = "users")]
    Users,
    /// <summary>
    ///     A user list
    /// </summary>
    [EnumMember(Value = "list")]
    List,
    /// <summary>
    ///     Users denylist (is this blocked users?)
    /// </summary>
    [EnumMember(Value = "users_blacklist")]
    UsersDenylist,
    /// <summary>
    ///     All
    /// </summary>
    [EnumMember(Value = "all")]
    All
}