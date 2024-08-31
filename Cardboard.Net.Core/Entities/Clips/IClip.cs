using Cardboard.Users;

namespace Cardboard.Clips;

public interface IClip : IMisskeyEntity, IDeletable
{
    /// <summary>
    ///     The date in which this clip was created
    /// </summary>
    DateTime CreatedAt { get; }
    
    /// <summary>
    ///     The date in which this clip last clipped a note
    /// </summary>
    DateTime? LastClipped { get; }
    
    /// <summary>
    ///     The owner of the clip
    /// </summary>
    IUserLite Owner { get; }
    
    /// <summary>
    ///     The name of the clip
    /// </summary>
    string Name { get; }
    
    /// <summary>
    ///     The description of the clip
    /// </summary>
    string? Description { get; }
    
    /// <summary>
    ///     Whether the clip is public
    /// </summary>
    bool IsPublic { get; }
    
    /// <summary>
    ///     The favorited count of the clip
    /// </summary>
    int FavoritedCount { get; }
    
    /// <summary>
    ///     Whether you have favorited this clip
    /// </summary>
    bool IsFavorited { get; }
    
    /// <summary>
    ///     The amount of notes in this clip
    /// </summary>
    int NotesCount { get; }
}