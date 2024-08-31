namespace Cardboard.Roles;

public interface IRoleLite : IBadgeRole, IMisskeyEntity
{
    /// <summary>
    ///     The optional color of the role
    /// </summary>
    string? Color { get; }
    
    /// <summary>
    ///     The optional description of the role
    /// </summary>
    string Description { get; }
    
    /// <summary>
    ///     Whether the role is moderator
    /// </summary>
    bool IsModerator { get; }
    
    /// <summary>
    ///     Whether the role is administrator
    /// </summary>
    bool IsAdministrator { get; }
}