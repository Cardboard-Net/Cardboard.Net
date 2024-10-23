using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Errors;

/// <summary>
///     Error code types for misskey
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ErrorKindType
{
    /// <summary>
    ///     Represents a permission error
    /// </summary>
    [EnumMember(Value = "permission")]
    Permission,
    /// <summary>
    ///     Represents a server error
    /// </summary>
    [EnumMember(Value = "server")]
    Server,
    /// <summary>
    ///     Represents a client error
    /// </summary>
    /// <remarks>
    ///     Yes, we get passed these. I assume it's split up from internal logic
    /// to frontend logic. If we send a malformed request that's a client error,
    /// if the server is unable to find a resource that's a server error.
    /// </remarks>
    [EnumMember(Value = "client")]
    Client
}