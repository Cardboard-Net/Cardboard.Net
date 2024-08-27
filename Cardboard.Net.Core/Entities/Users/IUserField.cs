namespace Cardboard.Users;

public interface IUserField
{
    /// <summary>
    /// Name of the field
    /// </summary>
    string Name { get; }
    /// <summary>
    /// The description of the field
    /// </summary>
    string Description { get; }
}