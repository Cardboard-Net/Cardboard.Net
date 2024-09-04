using Cardboard.Notes;

namespace Cardboard.Channels;

public interface IChannel : IMisskeyEntity
{
    /// <summary>
    ///     When this channel was created
    /// </summary>
    DateTime CreatedAt { get; }
    
    /// <summary>
    ///     When the last note was sent to this channel (if any)
    /// </summary>
    DateTime? LastNoteAt { get; }
    
    /// <summary>
    ///     The name of this channel
    /// </summary>
    string Name { get; }
    
    /// <summary>
    ///     The description of this channel (if any)
    /// </summary>
    string? Description { get; }
    
    /// <summary>
    ///     The userId of this channel (if any)
    /// </summary>
    string? UserId { get; }
    
    /// <summary>
    ///     The banner url of this channel
    /// </summary>
    Uri? BannerUrl { get; }
    
    /// <summary>
    ///     The pinned notes of this channel
    /// </summary>
    IReadOnlyCollection<INote> PinnedNotes { get; }
    
    /// <summary>
    ///     The color of this channel
    /// </summary>
    string Color { get; }
    
    /// <summary>
    ///     The amount of notes in this channel
    /// </summary>
    int NotesCount { get; }
    
    /// <summary>
    ///     The amount of users in this channel
    /// </summary>
    int UsersCount { get; }
    
    /// <summary>
    ///     Whether the channel is archived
    /// </summary>
    bool IsArchived { get; }
    
    /// <summary>
    ///     Whether the channel is marked sensitive
    /// </summary>
    bool IsSensitive { get; }
    
    /// <summary>
    ///     Whether the channel allows external renotes
    /// </summary>
    bool AllowExternalRenotes { get; }
    
    /// <summary>
    ///     Whether you are following this channel
    /// </summary>
    bool IsFollowing { get; }
    
    /// <summary>
    ///     Whether you have favorited this channel
    /// </summary>
    bool IsFavorited { get; }
}