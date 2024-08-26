using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Net.Entities.Federation;

/// <summary>
/// Suspension state types for remote instances
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum SuspensionStateType
{
    /// <summary>
    /// Not suspended
    /// </summary>
    [EnumMember(Value = "none")]
    None,
    /// <summary>
    /// Manually suspended
    /// </summary>
    [EnumMember(Value = "manuallySuspended")]
    ManuallySuspended,
    /// <summary>
    /// Gone suspended
    /// </summary>
    [EnumMember(Value = "goneSuspended")]
    GoneSuspended,
    /// <summary>
    /// Auto suspended for no response
    /// </summary>
    [EnumMember(Value = "autoSuspendedForNotResponding")]
    AutoSuspended
}