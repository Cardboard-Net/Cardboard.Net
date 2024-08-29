namespace Cardboard.Notes;

public interface IPoll
{
    /// <summary>
    ///     Optional date in which the poll expires
    /// </summary>
    DateTime? ExpiresAt { get; }
    
    /// <summary>
    ///     Optional amount of time until the poll expires
    /// </summary>
    TimeSpan? ExpiresAfter { get; }
    
    /// <summary>
    ///     A list containing the poll choices
    /// </summary>
    IReadOnlyList<string> Choices { get; }
    
    /// <summary>
    ///     Whether the poll allows multiple choices to be voted for
    /// </summary>
    bool MultipleChoice { get; }
}