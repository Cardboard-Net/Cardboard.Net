using Cardboard.Users;

namespace Cardboard.Instances;

/// <summary>
///     Represents the instance the user is currently on
/// </summary>
public interface ISelfInstance : IMisskeyEntity
{
    /// <summary>
    ///     The instance actor
    /// </summary>
    IUser InstanceActor { get; }
    
    IMeta Meta { get; }
    
    Task GetOnlineUsersCountAsync();
    Task GetServerInfoAsync();
    Task GetStatsAsync();
    Task PingAsync();
}