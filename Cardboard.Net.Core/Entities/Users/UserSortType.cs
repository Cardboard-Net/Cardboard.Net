using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Users;

/// <summary>
///     The sort type for admin/show-users
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum UserSortType
{
    /// <summary>
    ///     Follower count, ascending
    /// </summary>
    [EnumMember(Value = "+follower")]
    FollowerAsc,
    /// <summary>
    ///     Follower count, descending
    /// </summary>
    [EnumMember(Value = "-follower")]
    FollowerDesc,
    /// <summary>
    ///     Account creation date, ascending
    /// </summary>
    [EnumMember(Value = "+createdAt")]
    CreatedAtAsc,
    /// <summary>
    ///     Account creation date, descending
    /// </summary>
    [EnumMember(Value = "-createdAt")]
    CreatedAtDesc,
    /// <summary>
    ///     Account updated at, ascending
    /// </summary>
    [EnumMember(Value = "+updatedAt")]
    UpdatedAtAsc,
    /// <summary>
    ///     Account updated at, descending
    /// </summary>
    [EnumMember(Value = "-updatedAt")]
    UpdatedAtDesc,
    /// <summary>
    ///     Last time the account was active, ascending
    /// </summary>
    [EnumMember(Value = "+lastActiveDate")]
    LastActiveAsc,
    /// <summary>
    ///     Last time the account was active, descending
    /// </summary>
    [EnumMember(Value = "-lastActiveDate")]
    LastActiveDesc
}