using Cardboard.Lists;
using Cardboard.Notes;
using Cardboard.Users;

namespace Cardboard.Antennas;

/// <summary>
///     Represents a misskey antenna
/// </summary>
public interface IAntenna : IMisskeyEntity, IDeletable
{
    /// <summary>
    ///     The date in which this antenna was created at
    /// </summary>
    DateTime CreatedAt { get; }
    
    /// <summary>
    ///     The name of the antenna
    /// </summary>
    string Name { get; }
    
    /// <summary>
    ///     A list of keywords the antenna listens for
    /// </summary>
    IReadOnlyList<string> Keywords { get; }
    
    /// <summary>
    ///     A list of keywords the antenna ignores
    /// </summary>
    IReadOnlyList<string> ExcludeKeywords { get; }
    
    /// <summary>
    ///     The source of the antenna (whether that's a user list and so on)
    /// </summary>
    AntennaSourceType Source { get; }
    
    /// <summary>
    ///     Whether the antenna is case sensitive
    /// </summary>
    bool CaseSensitive { get; }
    
    /// <summary>
    ///     Whether the antenna only listens to local notes
    /// </summary>
    bool LocalOnly { get; }
    
    /// <summary>
    ///     Whether the antenna excludes bots
    /// </summary>
    bool ExcludeBots { get; }
    
    /// <summary>
    ///     Whether the antenna grabs replies
    /// </summary>
    bool WithReplies { get; }
    
    /// <summary>
    ///     Whether the antenna grabs notes with files
    /// </summary>
    bool WithFile { get; }
    
    /// <summary>
    ///     Whether the antenna is active
    /// </summary>
    bool IsActive { get; }
    
    /// <summary>
    ///     Whether the antenna has unread notes
    /// </summary>
    bool HasUnreadNote { get; }
    
    /// <summary>
    ///     Whether the antenna is set to notify you
    /// </summary>
    bool Notify { get; }

    /// <summary>
    ///     Gets the user list this antenna sources from
    /// </summary>
    Task<IList?> GetListAsync();
    
    /// <summary>
    ///     Gets all users in this antenna
    /// </summary>
    Task<IReadOnlyList<IUser>> GetUsersAsync();
}