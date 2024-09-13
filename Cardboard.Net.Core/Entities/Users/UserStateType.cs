using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Users;

/// <summary>
///     The state type for admin/show-users
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum UserStateType
{
    /// <summary>
    ///     All users of all states
    /// </summary>
    [EnumMember(Value = "all")]
    All,
    /// <summary>
    ///     Alive users
    /// </summary>
    [EnumMember(Value = "alive")]
    Alive,
    /// <summary>
    ///     Available users
    /// </summary>
    [EnumMember(Value = "available")]
    Available,
    /// <summary>
    ///     Admin users
    /// </summary>
    [EnumMember(Value = "admin")]
    Admin,
    /// <summary>
    ///     Moderator users
    /// </summary>
    [EnumMember(Value = "moderator")]
    Moderator,
    /// <summary>
    ///     Admin or moderators (aggregate)
    /// </summary>
    [EnumMember(Value = "adminOrModerator")]
    AdminOrModerator,
    /// <summary>
    ///     Suspended users
    /// </summary>
    [EnumMember(Value = "suspended")]
    Suspended,
    /// <summary>
    ///     Approved users
    /// </summary>
    [EnumMember(Value = "approved")]
    Approved
}