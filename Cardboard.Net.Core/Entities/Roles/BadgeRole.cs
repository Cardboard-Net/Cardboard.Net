using Cardboard.Roles;

namespace Cardboard.Net.Core.Entities.Roles;

public class BadgeRole : IBadgeRole
{
    /// <inheritdoc/>
    public string Name { get; internal set; }
    
    /// <inheritdoc/>
    public Uri? IconUrl { get; internal set; }
    
    /// <inheritdoc/>
    public int DisplayOrder { get; internal set; }
}