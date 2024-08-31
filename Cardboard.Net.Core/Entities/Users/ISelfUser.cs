using Cardboard.Announcements;

namespace Cardboard.Users;

public interface ISelfUser : IUser
{
    /// <summary>
    ///     Whether the account has unread dms (specified notes)
    /// </summary>
    bool HasUnreadDms { get; }
    
    /// <summary>
    ///     Whether the account has unread mentions
    /// </summary>
    bool HasUnreadMentions { get; }
    
    /// <summary>
    ///     Whether the account has unread announcements
    /// </summary>
    bool HasUnreadAnnouncement { get; }
    
    /// <summary>
    ///     A list of unread announcements
    /// </summary>
    IReadOnlyCollection<IAnnouncement> UnreadAnnouncements { get; }
    
    int UnreadNotificationsCount { get; }
    int LoggedInDays { get; }
}