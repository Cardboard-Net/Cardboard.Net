using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Cardboard.Net.Entities;
using Cardboard.Net.Entities.Drives;
using Cardboard.Net.Entities.Notes;
using Cardboard.Net.Rest;

namespace Cardboard.Net.Clients;

public class MisskeyClient : BaseMisskeyClient
{
    public MisskeyClient(string token, Uri host) : base()
    {
        this.ApiClient = new MisskeyApiClient(token, host);
        this.ApiClient.SetClient(this);
    }
    
    #region Users
    
    /// <summary>
    /// Gets a misskey user with the given id
    /// </summary>
    /// <param name="userId">misskey:id of the user</param>
    /// <returns>User</returns>
    public async Task<User?> GetUserAsync(string userId)
        => await this.ApiClient.GetUserAsync(userId);

    /// <summary>
    /// Gets a misskey user with the given username & host
    /// </summary>
    /// <param name="username">username of the user</param>
    /// <param name="host">host of the user, leave null for local</param>
    /// <returns>User</returns>
    public async Task<User?> GetUserAsync(string username, string? host = null)
        => await this.ApiClient.GetUserAsync(username, host);
    
    /// <summary>
    /// Creates a follow request to a user with the given id
    /// </summary>
    /// <param name="userId">id of the user to follow</param>
    /// <param name="withReplies">whether to display replies in timeline</param>
    public async Task FollowUserAsync(string userId, bool withReplies = false)
        => await this.ApiClient.SendRequestAsync<User>(Endpoints.FOLLOW_CREATE, 
            JsonSerializer.Serialize(new { userId = userId, withReplies = withReplies }));

    /// <summary>
    /// Suspends a user
    /// </summary>
    /// <param name="userId">An id of the user you want to suspend</param>
    /// <param name="selfsuspend">overrides default behavior (throwing an exception) to allow user to delete itself</param>
    public async Task SuspendUserAsync(string userId, bool selfsuspend = false)
        => await this.ApiClient.SuspendUserAsync(userId);

    /// <summary>
    /// Unsuspends a user
    /// </summary>
    /// <param name="userId">An id of the user you want to unsuspend</param>
    public async Task UnsuspendUserAsync(string userId)
        => await this.ApiClient.UnsuspendUserAsync(userId);

    /// <summary>
    /// Silences a user
    /// </summary>
    /// <param name="userId">An id of the user you want to silence</param>
    /// <param name="selfsilence">overrides default behavior (throwing an exception) to allow user to delete itself</param>
    public async Task SilenceUserAsync(string userId, bool selfsilence = false)
        => await this.ApiClient.SilenceUserAsync(userId);

    /// <summary>
    /// Unsilences a user
    /// </summary>
    /// <param name="userId">An id of the user you want to unsilence</param>
    public async Task UnsilenceUserAsync(string userId)
        => await this.ApiClient.SilenceUserAsync(userId);
    
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
    
    /// <summary>
    /// Deletes a note
    /// </summary>
    /// <param name="noteId">The id of the note to delete</param>
    public async Task DeleteNoteAsync(string noteId)
        => await this.ApiClient.SendRequestAsync(Endpoints.NOTE_DELETE,
            JsonSerializer.Serialize(new {noteId = noteId }));
    
    /// <summary>
    /// Creates a reaction on a note
    /// </summary>
    /// <param name="noteId">The id of the note to react to</param>
    /// <param name="reaction">The emoji you want to react with</param>
    public async Task CreateReactAsync(string noteId, string reaction)
        => await this.ApiClient.SendRequestAsync(Endpoints.NOTE_REACTS_CREATE,
            JsonSerializer.Serialize(new { noteId = noteId, reaction = reaction }));
    
    /// <summary>
    /// Deletes a reaction
    /// </summary>
    /// <param name="noteId">The note you want to remove the reaction from</param>
    public async Task DeleteReactAsync(string noteId)
        => await this.ApiClient.SendRequestAsync(Endpoints.NOTE_REACTS_DELETE,
            JsonSerializer.Serialize(new { noteId = noteId }));
    
    #endregion

    #region Emoji

    /// <summary>
    /// Gets the requested emoji from the instance the client is on.
    /// </summary>
    /// <param name="name">Name of the emoji to fetch</param>
    /// <returns>Emoji</returns>
    public async Task<Emoji> GetEmojiAsync(string name)
        => await this.ApiClient.GetEmojiAsync(name);

    #endregion
    
    #region Drive
    
    /// <summary>
    /// Fetches information about drive usage
    /// </summary>
    /// <returns>DriveUsage</returns>
    public async Task<DriveUsage> GetDriveUsageAsync()
        => await this.ApiClient.GetDriveUsageAsync();

    /// <summary>
    /// Fetches a file from the drive given a fileid
    /// </summary>
    /// <param name="fileId">Id of the file to retrieve</param>
    /// <returns>DriveFile</returns>
    public async Task<DriveFile> GetDriveFileAsync(string fileId)
        => await this.ApiClient.GetDriveFileAsync(fileId, ShowType.FileId);
    
    /// <summary>
    /// Fetches a file from the drive given a uri
    /// </summary>
    /// <param name="url">Url corresponding to a drive file</param>
    /// <returns>DriveFile</returns>
    public async Task<DriveFile> GetDriveFileAsync(Uri url)
        => await this.ApiClient.GetDriveFileAsync(url.ToString(), ShowType.FileUrl);
    
    /// <summary>
    /// Fetches a drive folder given the folderId
    /// </summary>
    /// <param name="folderId">Id of the folder to fetch</param>
    /// <returns>DriveFolder</returns>
    public async Task<DriveFolder> GetDriveFolderAsync(string folderId)
        => await this.ApiClient.GetDriveFolderAsync(folderId);

    /// <summary>
    /// Retrieve folders from drive
    /// </summary>
    /// <param name="limit">Limit (default 10, max 100)</param>
    /// <param name="folderId">Id of the folder (leave as null for the root folder)</param>
    /// <param name="searchQuery"></param>
    /// <returns></returns>
    [Experimental("FoldersExperiment")]
    public async Task<IReadOnlyList<DriveFolder>> GetDriveFoldersAsync(int limit = 10, string? folderId = null, string searchQuery = "")
        => await this.ApiClient.GetDriveFoldersAsync(limit, folderId, searchQuery);
    
    /// <summary>
    /// Retrieve folders from drive
    /// </summary>
    /// <param name="beforeId">folder id for folders before</param>
    /// <param name="limit">Limit (default 10, max 100)</param>
    /// <param name="folderId">Id of the folder (leave as null for the root folder)</param>
    /// <param name="searchQuery"></param>
    /// <returns></returns>
    [Experimental("FoldersExperiment")]
    public async Task<IReadOnlyList<DriveFolder>> GetDriveFoldersAsync(string beforeId, int limit = 10, string? folderId = null, string searchQuery = "")
        => await this.ApiClient.GetDriveFoldersAsync(beforeId, limit, folderId, searchQuery);
    
    /// <summary>
    /// Retrieve folders from drive
    /// </summary>
    /// <param name="beforeId">folder id for folders before</param>
    /// <param name="untilId">folder id for folders until</param>
    /// <param name="limit">Limit (default 10, max 100)</param>
    /// <param name="folderId">Id of the folder (leave as null for the root folder)</param>
    /// <param name="searchQuery"></param>
    /// <returns></returns>
    [Experimental("FoldersExperiment")]
    public async Task<IReadOnlyList<DriveFolder>> GetDriveFilesAsync(string beforeId, string untilId, int limit = 10, string? folderId = null, string searchQuery = "")
        => await this.ApiClient.GetDriveFoldersAsync(beforeId, untilId, limit, folderId, searchQuery);
    
    /// <summary>
    /// Finds a drive folder given a folder name
    /// </summary>
    /// <param name="name">Name of the folder</param>
    /// <param name="parentId">Id of the parent</param>
    /// <returns>DriveFolder</returns>
    public async Task<DriveFolder> FindDriveFolderAsync(string name, string? parentId = null)
        => await this.ApiClient.FindDriveFolderAsync(name, parentId);
    
    /// <summary>
    /// Creates a drive folder
    /// </summary>
    /// <param name="name">Name of the folder</param>
    /// <param name="parentId">Optional parent id if it's a subfolder</param>
    /// <returns></returns>
    public async Task<DriveFolder> CreateDriveFolderAsync(string name, string? parentId = null)
        => await this.ApiClient.CreateDriveFolderAsync(name, parentId);

    /// <summary>
    /// Deletes a drive folder
    /// </summary>
    /// <param name="folderId">id of the folder to delete</param>
    public async Task DeleteDriveFolderAsync(string folderId)
        => await this.ApiClient.SendRequestAsync(Endpoints.DRIVE_FOLDER_DELETE,
            JsonSerializer.Serialize(new { folderId = folderId }));
    
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