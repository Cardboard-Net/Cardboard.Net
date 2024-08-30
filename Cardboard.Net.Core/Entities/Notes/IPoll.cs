using System.Collections.Immutable;

namespace Cardboard.Notes;

public interface IPoll
{
    /// <summary>
    ///     Optional date in which the poll expires
    /// </summary>
    DateTime? ExpiresAt { get; }
    
    /// <summary>
    ///     A list containing the poll choices
    /// </summary>
    ImmutableArray<PollChoice> Choices { get; }
    
    /// <summary>
    ///     Whether the poll allows multiple choices to be voted for
    /// </summary>
    bool MultipleChoice { get; }
}