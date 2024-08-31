namespace Cardboard.Roles;

/// <summary>
///     Represents a badge role (icons on someone's profile name for instance)
/// </summary>
public interface IBadgeRole
{
    /// <summary>
    ///     Name of the badge role
    /// </summary>
    string Name { get; }
    
    /// <summary>
    ///     Optional icon url of the badge role
    /// </summary>
    Uri? IconUrl { get; }
    
    /// <summary>
    ///     The display order of the badge role
    /// </summary>
    int DisplayOrder { get; }
}