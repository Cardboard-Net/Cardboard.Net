namespace Cardboard.Users;

public interface IUserRelation : IMisskeyEntity
{
    bool HasOutgoingFollowRequest { get; }
    bool HasIncomingFollowRequest { get; }
    bool IsFollowed { get; }
    bool IsFollowing { get; }
    bool IsBlocked { get; }
    bool IsBlocking { get; }
    bool IsMuted { get; }
    bool IsRenoteMuted { get; }
}