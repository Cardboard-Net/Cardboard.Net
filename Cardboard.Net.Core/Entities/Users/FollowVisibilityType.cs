using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Users;

/// <summary>
/// Value representing follower and following visibility
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum FollowVisibilityType
{
    /// <summary>
    /// Public, anyone can access
    /// </summary>
    [EnumMember(Value = "public")]
    Public,

    /// <summary>
    /// Followers only, only followers can access
    /// </summary>
    [EnumMember(Value = "followers")]
    Followers,
    
    /// <summary>
    /// Private, only the user can access.
    /// </summary>
    [EnumMember(Value = "private")]
    Private
}