using Cardboard.Roles;

namespace Cardboard.Users;

public interface IUserLite : IMisskeyEntity, IDeletable
{
    /// <summary>
    /// The optional display name of the user
    /// </summary>
    string? Name { get; }

    /// <summary>
    /// The username of the user
    /// </summary>
    string Username { get; }

    /// <summary>
    /// The host of the user, null if local
    /// </summary>
    string? Host { get; }

    /// <summary>
    /// The optional avatar url of the user
    /// </summary>
    Uri? AvatarUrl { get; }

    /// <summary>
    /// The optional blurhash of the avatar
    /// </summary>
    string? AvatarBlurhash { get; }
    
    //public IReadOnlyCollection<IUserDecoration> AvatarDecorations { get; }
    //public IReadOnlyCollection<IBadgeRole> BadgeRoles { get; }
    
    /// <summary>
    /// Whether the user is an admin
    /// </summary>
    bool IsAdmin { get; }

    /// <summary>
    /// Whether the user is a moderator
    /// </summary>
    bool IsModerator { get; }

    /// <summary>
    /// Whether the user is silenced
    /// </summary>
    bool IsSilenced { get; }

    /// <summary>
    /// Whether the user has indexing enabled
    /// </summary>
    bool NoIndex { get; }

    /// <summary>
    /// Whether the user is a bot
    /// </summary>
    bool IsBot { get; }

    /// <summary>
    /// Whether the user is a cat
    /// </summary>
    bool IsCat { get; }

    /// <summary>
    /// Whether the user speaks as a cat
    /// </summary>
    bool SpeakAsCat { get; }

    /// <summary>
    /// An optional parameter defining some basic information about the instance
    /// </summary>
    IUserInstance Instance { get; }

    //TODO: Add emojis

    /// <summary>
    /// The user status
    /// </summary>
    StatusType OnlineStatus { get; }
}