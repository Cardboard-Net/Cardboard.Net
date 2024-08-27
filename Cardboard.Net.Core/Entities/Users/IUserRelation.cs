namespace Cardboard.Users;

/// <summary>
/// User relation interface
/// </summary>
public interface IUserRelation : IMisskeyEntity
{
    /// <summary>
    /// Whether you have an outgoing follow request to the user
    /// </summary>
    bool HasOutgoingFollowRequest { get; }
    
    /// <summary>
    /// Whether you have an incoming follow request from the user
    /// </summary>
    bool HasIncomingFollowRequest { get; }
    
    /// <summary>
    /// Whether you follow the user
    /// </summary>
    bool IsFollowed { get; }
    
    /// <summary>
    /// Whether the user is following you
    /// </summary>
    bool IsFollowing { get; }
    
    /// <summary>
    /// Whether the user is blocked by you
    /// </summary>
    bool IsBlocked { get; }
    
    /// <summary>
    /// Whether the user is blocking you
    /// </summary>
    bool IsBlocking { get; }
    
    /// <summary>
    /// Whether the user is muted by you
    /// </summary>
    bool IsMuted { get; }
    
    /// <summary>
    /// Whether the user is renote muted by you (boosts)
    /// </summary>
    bool IsRenoteMuted { get; }
}