namespace Cardboard.Roles;

public interface IBadgeRole
{
    string Name { get; }
    Uri? IconUrl { get; }
    int DisplayOrder { get; }
}