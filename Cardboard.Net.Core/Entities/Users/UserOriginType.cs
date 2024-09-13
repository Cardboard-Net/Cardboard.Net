using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Users;

/// <summary>
///     The user origin type
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum UserOriginType
{
    /// <summary>
    ///     Aggregate of local & remote users
    /// </summary>
    [EnumMember(Value = "combined")]
    Combined,
    /// <summary>
    ///     Local users (to the instance you are on)
    /// </summary>
    [EnumMember(Value = "local")]
    Local,
    /// <summary>
    ///     Remote users (to the instance you are on)
    /// </summary>
    [EnumMember(Value = "remote")]
    Remote
}