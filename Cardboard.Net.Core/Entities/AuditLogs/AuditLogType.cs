using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.AuditLogs;

[JsonConverter(typeof(StringEnumConverter))]
public enum AuditLogType
{
    /// <summary>
    ///     Recorded when the instance meta is updated
    /// </summary>
    [EnumMember(Value = "updateServerSettings")]
    UpdateServerSettings,
    /// <summary>
    ///     Recorded when a custom emoji is updated
    /// </summary>
    [EnumMember(Value = "updateCustomEmoji")]
    UpdateCustomEmoji,
    /// <summary>
    ///     Recorded when a new user has been approved
    /// </summary>
    [EnumMember(Value = "approve")]
    Approve,
    /// <summary>
    ///     Recorded when a custom emoji is added
    /// </summary>
    [EnumMember(Value = "addCustomEmoji")]
    AddCustomEmoji,
    /// <summary>
    ///     Recorded when a user is suspended
    /// </summary>
    [EnumMember(Value = "suspend")]
    Suspend,
    /// <summary>
    ///     Recorded when an abuse report is resolved
    /// </summary>
    [EnumMember(Value = "resolveAbuseReport")]
    ResolveAbuseReport,
    /// <summary>
    ///     Recorded when a user note is updated
    /// </summary>
    [EnumMember(Value = "updateUserNote")]
    UpdateUserNote,
    /// <summary>
    ///     Recorded when a remote instance's note is updated
    /// </summary>
    [EnumMember(Value = "updateRemoteInstanceNote")]
    UpdateRemoteInstanceNote,
    /// <summary>
    ///     Recorded when a remote instance is suspended
    /// </summary>
    [EnumMember(Value = "suspendRemoteInstance")]
    SuspendRemoteInstance,
    /// <summary>
    ///     Recorded when a note is deleted
    /// </summary>
    [EnumMember(Value = "deleteNote")]
    DeleteNote,
    /// <summary>
    ///     Recorded when a user has their avatar forcefully unset
    /// </summary>
    [EnumMember(Value = "unsetUserAvatar")]
    UnsetUserAvatar,
    /// <summary>
    ///     Recorded when a user has a role unassigned from them
    /// </summary>
    [EnumMember(Value = "unassignRole")]
    UnassignRole,
    /// <summary>
    ///     Recorded when an emoji is deleted
    /// </summary>
    [EnumMember(Value = "deleteCustomEmoji")]
    DeleteCustomEmoji,
    /// <summary>
    ///     (Dunno for sure, but might be when the queue is emptied)
    /// </summary>
    [EnumMember(Value = "promoteQueue")]
    PromoteQueue
}