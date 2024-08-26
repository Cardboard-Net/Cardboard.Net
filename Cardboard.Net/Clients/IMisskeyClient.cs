using Cardboard.Net.Entities;
using Cardboard.Net.Entities.Drives;
using Cardboard.Net.Entities.Notes;
using Cardboard.Net.Entities.Users;

namespace Cardboard.Net.Clients;

public interface IMisskeyClient
{
    /// <summary>
    /// Gets the current user
    /// </summary>
    /// <returns>Current user</returns>
    Task<Account?> GetCurrentUserAsync();

    /// <summary>
    /// Gets the current instance
    /// </summary>
    /// <returns>Current instance</returns>
    Task<HomeInstance?> GetCurrentInstanceAsync();
    
    /// <summary>
    /// Gets a misskey user with the given id
    /// </summary>
    /// <param name="userId">misskey:id of the user</param>
    /// <returns>User</returns>
    Task<User?> GetUserAsync(string userId);

    /// <summary>
    /// Gets a misskey user with the given username & host
    /// </summary>
    /// <param name="username">username of the user</param>
    /// <param name="host">host of the user, leave null for local</param>
    /// <returns>User</returns>
    Task<User?> GetUserAsync(string username, string? host = null);

    /// <summary>
    /// Creates a follow request to a user with the given id
    /// </summary>
    /// <param name="userId">id of the user to follow</param>
    /// <param name="withReplies">whether to display replies in timeline</param>
    Task FollowUserAsync(string userId, bool withReplies = false);

    /// <summary>
    /// Suspends a user
    /// </summary>
    /// <param name="userId">An id of the user you want to suspend</param>
    /// <param name="selfsuspend">overrides default behavior (throwing an exception) to allow user to delete itself</param>
    Task SuspendUserAsync(string userId, bool selfsuspend = false);

    /// <summary>
    /// Unsuspends a user
    /// </summary>
    /// <param name="userId">An id of the user you want to unsuspend</param>
    Task UnsuspendUserAsync(string userId);

    /// <summary>
    /// Silences a user
    /// </summary>
    /// <param name="userId">An id of the user you want to silence</param>
    /// <param name="selfsilence">overrides default behavior (throwing an exception) to allow user to delete itself</param>
    Task SilenceUserAsync(string userId, bool selfsilence = false);

    /// <summary>
    /// Unsilences a user
    /// </summary>
    /// <param name="userId">An id of the user you want to unsilence</param>
    Task UnsilenceUserAsync(string userId);

    /// <summary>
    /// Gets a note given the noteId
    /// </summary>
    /// <param name="noteId">The id of the note</param>
    /// <returns></returns>
    Task<Note> GetNoteAsync(string noteId);

    /// <summary>
    /// Creates a note with the given arguments
    /// </summary>
    /// <param name="text">The contents of the note</param>
    /// <param name="contentWarning">The content warning for the note</param>
    /// <param name="visibility">Visibility level</param>
    /// <param name="isLocal">Whether the note is visible only on the local instance</param>
    /// <param name="acceptance">Reaction acceptance level</param>
    /// <returns>Note</returns>
    Task<Note> CreateNoteAsync(string text, string? contentWarning = null, VisibilityType visibility = VisibilityType.Public, bool isLocal = false, AcceptanceType acceptance = AcceptanceType.NonSensitiveOnly);

    /// <summary>
    /// Deletes a note
    /// </summary>
    /// <param name="noteId">The id of the note to delete</param>
    Task DeleteNoteAsync(string noteId);

    /// <summary>
    /// Creates a reaction on a note
    /// </summary>
    /// <param name="noteId">The id of the note to react to</param>
    /// <param name="reaction">The emoji you want to react with</param>
    Task CreateReactAsync(string noteId, string reaction);

    /// <summary>
    /// Deletes a reaction
    /// </summary>
    /// <param name="noteId">The note you want to remove the reaction from</param>
    Task DeleteReactAsync(string noteId);

    /// <summary>
    /// Gets the requested emoji from the instance the client is on.
    /// </summary>
    /// <param name="name">Name of the emoji to fetch</param>
    /// <returns>Emoji</returns>
    Task<Emoji> GetEmojiAsync(string name);

    /// <summary>
    /// Fetches information about drive usage
    /// </summary>
    /// <returns>DriveUsage</returns>
    Task<DriveUsage> GetDriveUsageAsync();

    /// <summary>
    /// Fetches a file from the drive given a fileid
    /// </summary>
    /// <param name="fileId">Id of the file to retrieve</param>
    /// <returns>DriveFile</returns>
    Task<DriveFile> GetDriveFileAsync(string fileId);

    /// <summary>
    /// Fetches a file from the drive given a uri
    /// </summary>
    /// <param name="url">Url corresponding to a drive file</param>
    /// <returns>DriveFile</returns>
    Task<DriveFile> GetDriveFileAsync(Uri url);

    /// <summary>
    /// Fetches a drive folder given the folderId
    /// </summary>
    /// <param name="folderId">Id of the folder to fetch</param>
    /// <returns>DriveFolder</returns>
    Task<DriveFolder> GetDriveFolderAsync(string folderId);

    /// <summary>
    /// Retrieve folders from drive
    /// </summary>
    /// <param name="limit">Limit (default 10, max 100)</param>
    /// <param name="folderId">Id of the folder (leave as null for the root folder)</param>
    /// <param name="searchQuery"></param>
    /// <returns></returns>
    Task<IReadOnlyList<DriveFolder>> GetDriveFoldersAsync(int limit = 10, string? folderId = null, string searchQuery = "");

    /// <summary>
    /// Retrieve folders from drive
    /// </summary>
    /// <param name="beforeId">folder id for folders before</param>
    /// <param name="limit">Limit (default 10, max 100)</param>
    /// <param name="folderId">Id of the folder (leave as null for the root folder)</param>
    /// <param name="searchQuery"></param>
    /// <returns></returns>
    Task<IReadOnlyList<DriveFolder>> GetDriveFoldersAsync(string beforeId, int limit = 10, string? folderId = null, string searchQuery = "");

    /// <summary>
    /// Retrieve folders from drive
    /// </summary>
    /// <param name="beforeId">folder id for folders before</param>
    /// <param name="untilId">folder id for folders until</param>
    /// <param name="limit">Limit (default 10, max 100)</param>
    /// <param name="folderId">Id of the folder (leave as null for the root folder)</param>
    /// <param name="searchQuery"></param>
    /// <returns></returns>
    Task<IReadOnlyList<DriveFolder>> GetDriveFilesAsync(string beforeId, string untilId, int limit = 10, string? folderId = null, string searchQuery = "");

    /// <summary>
    /// Finds a drive folder given a folder name
    /// </summary>
    /// <param name="name">Name of the folder</param>
    /// <param name="parentId">Id of the parent</param>
    /// <returns>DriveFolder</returns>
    Task<DriveFolder> FindDriveFolderAsync(string name, string? parentId = null);

    /// <summary>
    /// Creates a drive folder
    /// </summary>
    /// <param name="name">Name of the folder</param>
    /// <param name="parentId">Optional parent id if it's a subfolder</param>
    /// <returns></returns>
    Task<DriveFolder> CreateDriveFolderAsync(string name, string? parentId = null);

    /// <summary>
    /// Deletes a drive folder
    /// </summary>
    /// <param name="folderId">id of the folder to delete</param>
    Task DeleteDriveFolderAsync(string folderId);

    /// <summary>
    /// Gets the number of currently online users from the instance the client is on
    /// </summary>
    /// <returns>int</returns>
    Task<int> GetOnlineUserCountAsync();

    /// <summary>
    /// Gets the stats from the instance the client is registered to.
    /// </summary>
    /// <returns></returns>
    Task<Stats> GetStatsAsync();

    void Dispose();
    Task InitializeAsync();
}