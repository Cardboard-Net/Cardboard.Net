using Cardboard.Net.Entities;
using Cardboard.Net.Entities.Notes;

namespace Cardboard.Net.Rest;

public interface IMisskeyClient
{
    /// <summary>
    /// Gets a misskey user with the given id
    /// </summary>
    /// <param name="userId">misskey:id of the user</param>
    /// <returns>User</returns>
    Task<User> GetUserAsync(string userId);
    
    /// <summary>
    /// Gets a misskey user with the given username & host
    /// </summary>
    /// <param name="username">username of the user</param>
    /// <param name="host">host of the user, leave null for local</param>
    /// <returns>User</returns>
    Task<User> GetUserAsync(string username, string? host = null);

    /// <summary>
    /// Creates a note
    /// </summary>
    /// <param name="text">The contents of the note</param>
    /// <param name="contentWarning">The content warning of the note</param>
    /// <param name="visibility">The visibility setting of the note</param>
    /// <param name="isLocal">Whether the note is local only </param>
    /// <param name="acceptance">The reaction acceptance level</param>
    /// <returns>Note</returns>
    Task<Note> CreateNoteAsync
    (
        string text,
        string? contentWarning = null,
        VisibilityType visibility = VisibilityType.Public,
        bool isLocal = false, 
        AcceptanceType acceptance = AcceptanceType.NonSensitiveOnly
    );

    /// <summary>
    /// Follows a user given the userId
    /// </summary>
    /// <param name="userId">The id of the user to follow</param>
    /// <param name="withReplies">Whether or not you want to see replies in timeline from that user</param>
    /// <returns>User</returns>
    Task<User> FollowUserAsync(string userId, bool withReplies = false);
    
    /// <summary>
    /// Unfollows a user given the userId
    /// </summary>
    /// <param name="userId">The id of the user to unfollow</param>
    /// <returns>User</returns>
    Task<User> UnfollowUserAsync(string userId);
    
    /// <summary>
    /// Deletes a note
    /// </summary>
    /// <param name="noteId">id of the note to be deleted</param>
    /// <returns></returns>
    Task DeleteNoteAsync(string noteId);
    
    /// <summary>
    /// Gets the current number of online users
    /// </summary>
    /// <returns>int</returns>
    Task<int> GetOnlineUserCountAsync();
}

