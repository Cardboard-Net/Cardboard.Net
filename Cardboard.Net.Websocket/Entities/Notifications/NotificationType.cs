namespace Cardboard.Net.Websocket.Entities.Notifications;

/// <summary>
/// Notification types
/// </summary>
// TODO: Follow Request and some other notification types such as achievement
public enum NotificationType
{
    /// <summary>
    ///     Incoming follow
    /// </summary>
    Follow,
    /// <summary>
    ///     Incoming reaction
    /// </summary>
    Reaction,
    /// <summary>
    ///     Incoming reply
    /// </summary>
    Reply,
    /// <summary>
    ///     Incoming renote/boost
    /// </summary>
    Renote,
    /// <summary>
    ///     Incoming quote
    /// </summary>
    Quote
}