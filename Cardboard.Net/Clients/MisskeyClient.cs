using Cardboard.Net.Entities;
using Cardboard.Net.Entities.Notes;

namespace Cardboard.Net.Clients;

public class MisskeyClient : BaseMisskeyClient
{
    public MisskeyClient(string token, Uri host) : base(token, host) { }

    #region Users
    
    /// <summary>
    /// Gets a misskey user with the given id
    /// </summary>
    /// <param name="userId">misskey:id of the user</param>
    /// <returns>User</returns>
    public async Task<User> GetUserAsync(string userId)
        => await this.ApiClient.GetUserAsync(userId);

    /// <summary>
    /// Gets a misskey user with the given username & host
    /// </summary>
    /// <param name="username">username of the user</param>
    /// <param name="host">host of the user, leave null for local</param>
    /// <returns>User</returns>
    public async Task<User> GetUserAsync(string username, string? host = null)
        => await this.ApiClient.GetUserAsync(username, host);
    
    /// <summary>
    /// Creates a follow request to a user with the given id
    /// </summary>
    /// <param name="userId">id of the user to follow</param>
    /// <param name="withReplies">whether to display replies in timeline</param>
    public async Task FollowUserAsync(string userId, bool withReplies = false)
        => await this.ApiClient.FollowUserAsync(userId, withReplies);
    
    #endregion
    
    #region Notes
    
    /// <summary>
    /// Gets a note given the noteId
    /// </summary>
    /// <param name="noteId">The id of the note</param>
    /// <returns></returns>
    public async Task<Note> GetNoteAsync(string noteId)
        => await this.ApiClient.GetNoteAsync(noteId);

    /// <summary>
    /// Creates a note with the given arguments
    /// </summary>
    /// <param name="text">The contents of the note</param>
    /// <param name="contentWarning">The content warning for the note</param>
    /// <param name="visibility">Visibility level</param>
    /// <param name="isLocal">Whether the note is visible only on the local instance</param>
    /// <param name="acceptance">Reaction acceptance level</param>
    /// <returns>Note</returns>
    public async Task<Note> CreateNoteAsync(string text, string? contentWarning = null, VisibilityType visibility = VisibilityType.Public, bool isLocal = false, AcceptanceType acceptance = AcceptanceType.NonSensitiveOnly) 
        => await this.ApiClient.CreateNoteAsync(text, contentWarning, visibility, isLocal, acceptance);
    
    #endregion
    
    #region CurrentInstance

    /// <summary>
    /// Gets the number of currently online users from the instance the client is on
    /// </summary>
    /// <returns>int</returns>
    public async Task<int> GetOnlineUserCountAsync()
        => await this.ApiClient.GetOnlineUserCountAsync();
    
    /// <summary>
    /// Gets the stats from the instance the client is registered to.
    /// </summary>
    /// <returns></returns>
    public async Task<Stats> GetStatsAsync()
        => await this.ApiClient.GetStatsAsync();
    
    #endregion
    
    public override void Dispose()
    {
        throw new NotImplementedException();
    }
}