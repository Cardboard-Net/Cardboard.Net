using Cardboard.Roles;

namespace Cardboard.Users;

public interface IUserLite : IMisskeyEntity
{
    string? Name { get; }
    string Username { get; }
    string? Host { get; }
    Uri? AvatarUrl { get; }
    string? AvatarBlurhash { get; }
    IUserDecoration[] AvatarDecorations { get; }
    bool IsAdmin { get; }
    bool IsModerator { get; }
    bool IsSilenced { get; }
    bool NoIndex { get; }
    bool IsBot { get; }
    bool IsCat { get; }
    bool SpeakAsCat { get; }
    IUserInstance Instance { get; }
    //TODO: Add emojis
    StatusType OnlineStatus { get; }
    IBadgeRole[] BadgeRoles { get; }
}