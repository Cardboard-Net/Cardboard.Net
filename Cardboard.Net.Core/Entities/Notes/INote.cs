using System.Threading.Channels;
using Cardboard.Drives;
using Cardboard.Users;

namespace Cardboard.Notes;

public interface INote : IMisskeyEntity, IDeletable
{
    /// <summary>
    /// When the note was created
    /// </summary>
    DateTime CreatedAt { get; }
    
    /// <summary>
    /// When the note was deleted
    /// </summary>
    DateTime? DeletedAt { get; }
    
    /// <summary>
    /// The optional text of the note. Polls, and files do not need this set.
    /// </summary>
    string? Text { get; }
    
    /// <summary>
    /// The content warning of the note
    /// </summary>
    string? ContentWarning { get; }
    
    /// <summary>
    /// The user who wrote the note
    /// </summary>
    IUserLite? Author { get; }
    
    /// <summary>
    /// Parent note this is a reply to
    /// </summary>
    INote? Reply { get; }
    
    /// <summary>
    /// Parent note this is a renote of
    /// </summary>
    INote? Renote { get; }
    
    /// <summary>
    /// Whether the note is hidden
    /// </summary>
    bool IsHidden { get; }
    
    /// <summary>
    /// The visibility type of the note
    /// </summary>
    VisibilityType Visibility { get; }
    
    IReadOnlyCollection<string> Mentions { get; }
    
    IReadOnlyCollection<string> VisibleUserIds { get; }
    
    IReadOnlyCollection<IDriveFile> Files { get; }
    
    IReadOnlyCollection<string> Tags { get; }
    
    // TODO: emojis
 
    // TODO: poll
    
    //public Channel Channel { get; set; }
    
    bool LocalOnly { get; }
    
    /// <summary>
    /// The reaction acceptance level
    /// </summary>
    AcceptanceType? ReactionAcceptance { get; }
    
    // TODO: Reaction emojis
    
    // TODO: reactions
    
    /// <summary>
    /// The amount of reactions on this note in total
    /// </summary>
    int ReactionCount { get; }
    
    /// <summary>
    /// The total number of renotes
    /// </summary>
    int RenoteCount { get; }
    
    /// <summary>
    /// The total number of replies
    /// </summary>
    int RepliesCount { get; }
    
    Uri Url { get; }
    
    Uri Uri { get; }
    
    // TODO: reactionAndUserPairCache
    
    /// <summary>
    /// The amount of times this note has been clipped
    /// </summary>
    int ClippedCount { get; }
    
    /// <summary>
    /// Your reaction to the note
    /// </summary>
    string? MyReaction { get; }
}