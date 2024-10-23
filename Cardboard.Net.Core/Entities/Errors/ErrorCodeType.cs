using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Errors;

/// <summary>
///     Error code types for misskey
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ErrorCodeType
{
    /// <summary>
    ///     Represents the error given when you try to use an account that has
    /// migrated
    /// </summary>
    [EnumMember(Value = "YOUR_ACCOUNT_MOVED")]
    AccountMoved,
    /// <summary>
    ///     Represents the error given when you try to do an action you are require
    /// a role permission to do.
    /// </summary>
    [EnumMember(Value = "ROLE_PERMISSION_DENIED")]
    PermissionDenied
}