namespace Cardboard.Roles;

public interface IRole : IRoleLite
{
    /// <summary>
    ///     When the role was created at
    /// </summary>
    DateTime CreatedAt { get; }
    
    /// <summary>
    ///     When the role was last updated at (if ever)
    /// </summary>
    DateTime? UpdatedAt { get; }
    
    // TODO: target
    // TODO: condFormula
    
    /// <summary>
    ///     Whether the role is public
    /// </summary>
    bool IsPublic { get; }
    
    /// <summary>
    ///     Whether the role is explorable
    /// </summary>
    bool IsExplorable { get; }
    
    /// <summary>
    ///     Whether the role has a badge
    /// </summary>
    bool AsBadge { get; }
    
    /// <summary>
    ///     Whether mods can assign users (i assume?)
    /// </summary>
    bool ModEditUsers { get; }
    
    // TODO: policies
    
    /// <summary>
    ///     The amount of users assigned to this role
    /// </summary>
    int UsersCount { get; }
}