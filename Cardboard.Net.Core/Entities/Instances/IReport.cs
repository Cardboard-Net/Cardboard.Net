using Cardboard.Users;

namespace Cardboard.Instances;

/// <summary>
///     Represents a report on the local instance
/// </summary>
public interface IReport : IMisskeyEntity
{
    /// <summary>
    ///     The time this report was created
    /// </summary>
    DateTime CreatedAt { get; }
    
    /// <summary>
    ///     The text within the report
    /// </summary>
    string Comment { get; }
    
    /// <summary>
    ///     Whether the report has been resolved
    /// </summary>
    bool Resolved { get; }
    
    /// <summary>
    ///     Whether the report has been forwarded to the remote instance
    /// </summary>
    bool Forwarded { get; }
    
    /// <summary>
    ///     The user who reported
    /// </summary>
    IUserLite Reporter { get; }
    
    /// <summary>
    ///     The user being reported
    /// </summary>
    IUserLite Reportee { get; }
    
    /// <summary>
    ///     The optional assignee to handle the report
    /// </summary>
    IUserLite? Assignee { get; }

    Task ResolveAsync(bool forward = false);
}