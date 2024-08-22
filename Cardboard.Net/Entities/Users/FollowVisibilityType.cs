using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Cardboard.Net.Entities.Users;

/// <summary>
/// Value representing follower and following visibility
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<FollowVisibilityType>))]
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