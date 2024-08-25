using Newtonsoft.Json;

namespace Cardboard.Net.Entities.Users;

/// <summary>
/// Class representing what's returned by admin/show-user
/// </summary>
public class AdminUserInfo
{
    public string? Email { get; init; }
    public bool EmailVerified { get; init; }
    public bool AutoAcceptFollow { get; init; }
    public bool NoCrawle { get; init; }
    public bool PreventAiLearning { get; init; }
}

/// <summary>
/// Class representing a user ip
/// </summary>
public class AdminUserIp
{
    /// <summary>
    /// Ip
    /// </summary>
    [JsonProperty("ip")]
    public string Ip { get; init; }
    /// <summary>
    /// When the IP was first registered
    /// </summary>
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; init; }
}