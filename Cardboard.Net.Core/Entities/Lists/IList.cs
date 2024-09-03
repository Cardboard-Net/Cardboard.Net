using Cardboard.Users;

namespace Cardboard.Lists;

public interface IList : IMisskeyEntity, IDeletable
{
    /// <summary>
    ///     When this list was created at
    /// </summary>
    DateTime CreatedAt { get; }
    
    /// <summary>
    ///     The name of the list
    /// </summary>
    string Name { get; }
    
    /// <summary>
    ///     Whether the list is public
    /// </summary>
    bool IsPublic { get; }

    /// <summary>
    ///     Adds a user to the current list
    /// </summary>
    /// <param name="user"></param>
    Task AddUserAsync(IUser user);
    
    /// <summary>
    ///     Removes a user from the current list
    /// </summary>
    /// <param name="user"></param>
    Task RemoveUserAsync(IUser user);
    
    /// <summary>
    ///     Gets all users in this list
    /// </summary>
    /// <returns>A read only list of all the users</returns>
    Task<IReadOnlyList<IUser>> GetUsersAsync();
}