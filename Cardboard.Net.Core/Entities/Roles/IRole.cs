namespace Cardboard.Roles;

public interface IRole : IRoleLite
{
    DateTime CreatedAt { get; }
    DateTime? UpdatedAt { get; }
    // TODO: target
    // TODO: condFormula
    bool IsPublic { get; }
    bool IsExplorable { get; }
    bool AsBadge { get; }
    bool ModEditUsers { get; }
    // TODO: policies
    int UsersCount { get; }
}