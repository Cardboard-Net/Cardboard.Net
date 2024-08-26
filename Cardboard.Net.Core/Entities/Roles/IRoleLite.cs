namespace Cardboard.Roles;

public interface IRoleLite : IBadgeRole, IMisskeyEntity
{
    string? Color { get; }
    string Description { get; }
    bool IsModerator { get; }
    bool IsAdministrator { get; }
}