using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Users;

/// <summary>
/// Notification filter type
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum NotificationFilterType
{
    /// <summary>
    /// All notifications
    /// </summary>
    [EnumMember(Value = "all")]
    All,
    /// <summary>
    /// Only from users you're following
    /// </summary>
    [EnumMember(Value = "following")]
    Following,
    /// <summary>
    /// Only from users who follow you
    /// </summary>
    [EnumMember(Value = "follower")]
    Follower,
    /// <summary>
    /// Only from mutuals
    /// </summary>
    [EnumMember(Value = "mutualFollow")]
    MutualFollow,
    /// <summary>
    /// Only from users you follow, or who follow you
    /// </summary>
    [EnumMember(Value = "followingOrFollower")]
    FollowingOrFollower,
    /// <summary>
    /// Never
    /// </summary>
    [EnumMember(Value = "never")]
    Never
}