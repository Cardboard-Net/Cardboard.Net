using System.Runtime.Serialization;

namespace Cardboard.Users;

/// <summary>
/// Notification type
/// </summary>
public enum NotificationType
{
    /// <summary>
    /// Notification for note
    /// </summary>
    [EnumMember(Value = "note")] 
    Note,
    /// <summary>
    /// Notification for incoming follow
    /// </summary>
    [EnumMember(Value = "follow")]
    Follow,
    /// <summary>
    /// Notification for mention
    /// </summary>
    [EnumMember(Value = "mention")]
    Mention,
    /// <summary>
    /// Notification for reply
    /// </summary>
    [EnumMember(Value = "reply")]
    Reply,
    /// <summary>
    /// Notification for renote
    /// </summary>
    [EnumMember(Value = "renote")]
    Renote,
    /// <summary>
    /// Notification for quote
    /// </summary>
    [EnumMember(Value = "quote")]
    Quote,
    /// <summary>
    /// Notification for reaction
    /// </summary>
    [EnumMember(Value = "reaction")]
    Reaction,
    /// <summary>
    /// Notification for poll ended
    /// </summary>
    [EnumMember(Value = "pollEnded")]
    PollEnded,
    /// <summary>
    /// Notification for edited
    /// </summary>
    [EnumMember(Value = "edited")]
    Edited,
    /// <summary>
    /// Notification for receive follow request
    /// </summary>
    [EnumMember(Value = "receiveFollowRequest")]
    ReceiveFollowRequest,
    /// <summary>
    /// Notification for follow request accepted
    /// </summary>
    [EnumMember(Value = "followRequestAccepted")]
    AcceptedFollowRequest,
    /// <summary>
    /// Notification for role assigned
    /// </summary>
    [EnumMember(Value = "roleAssigned")]
    RoleAssigned,
    /// <summary>
    /// Notification for achievement earned
    /// </summary>
    [EnumMember(Value = "achievementEarned")]
    AchievementEarned,
    /// <summary>
    /// Notification for app
    /// </summary>
    [EnumMember(Value = "app")]
    App,
    /// <summary>
    /// Notification for test
    /// </summary>
    [EnumMember(Value = "test")]
    Test,
    /// <summary>
    /// Notification for poll vote (Idk if this is used?)
    /// </summary>
    [EnumMember(Value = "pollVote")]
    PollVote,
    /// <summary>
    /// Notification for group invite (Idk if this is used?)
    /// </summary>
    [EnumMember(Value = "groupInvited")]
    GroupInvited
}