using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Net.Entities;

/// <summary>
/// Represents the role type
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum RoleType
{
    /// <summary>
    /// When the role is only applied manually
    /// </summary>
    [EnumMember(Value = "manual")]
    Manual,
    /// <summary>
    /// When the role has conditions that apply it automatically
    /// </summary>
    [EnumMember(Value = "conditional")]
    Conditional
}