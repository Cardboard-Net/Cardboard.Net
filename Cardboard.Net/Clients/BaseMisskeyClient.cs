using System.Runtime.CompilerServices;
using Cardboard.Net.Entities;
using Cardboard.Net.Entities.Drives;
using Cardboard.Net.Entities.Notes;
using Cardboard.Net.Entities.Users;
using Cardboard.Net.Rest;
using Cardboard.Notes;
using Microsoft.Extensions.Logging;

namespace Cardboard.Net.Clients;

public abstract class BaseMisskeyClient : IDisposable, IMisskeyClient
{
    private ILogger Logger { get; }
    protected internal MisskeyApiClient ApiClient { get; internal init; }

    private Account? currentUser = null;
    private HomeInstance? currentInstance = null;
    
    // public Account? CurrentUser { get; internal set; }
    // public HomeInstance? CurrentInstance { get; internal set; }

    internal BaseMisskeyClient(ILogger logger)
    {
        Logger = logger;
    }

    public virtual async Task<Account?> GetCurrentUserAsync() =>
        currentUser ??= await ApiClient.GetCurrentUserAsync().ConfigureAwait(false);

    public virtual async Task<HomeInstance?> GetCurrentInstanceAsync()
    {
        if (this.currentInstance != null) return this.currentInstance;
        
        this.currentInstance = new HomeInstance() { Misskey = this };
        await currentInstance.RefreshMetaAsync();
        await currentInstance.RefreshStatsAsync();

        return this.currentInstance;
    }
    public virtual async Task InitializeAsync()
    {
        this.currentInstance ??= new HomeInstance() { Misskey = this };
        await this.currentInstance.RefreshMetaAsync();
        await this.currentInstance.RefreshStatsAsync();
    }

    public abstract Task<User?> GetUserAsync(string userId);
    public abstract Task<User?> GetUserAsync(string username, string? host = null);
    public abstract Task FollowUserAsync(string userId, bool withReplies = false);
    public abstract Task SuspendUserAsync(string userId, bool selfsuspend = false);
    public abstract Task UnsuspendUserAsync(string userId);
    public abstract Task SilenceUserAsync(string userId, bool selfsilence = false);
    public abstract Task UnsilenceUserAsync(string userId);
    public abstract Task<Note> GetNoteAsync(string noteId);

    public abstract Task<Note> CreateNoteAsync(string text, string? contentWarning = null, VisibilityType visibility = VisibilityType.Public,
        bool isLocal = false, AcceptanceType acceptance = AcceptanceType.NonSensitiveOnly);

    public abstract Task DeleteNoteAsync(string noteId);
    public abstract Task CreateReactAsync(string noteId, string reaction);
    public abstract Task DeleteReactAsync(string noteId);
    public abstract Task<Emoji> GetEmojiAsync(string name);
    public abstract Task<DriveUsage> GetDriveUsageAsync();
    public abstract Task<DriveFile> GetDriveFileAsync(string fileId);
    public abstract Task<DriveFile> GetDriveFileAsync(Uri url);
    public abstract Task<DriveFolder> GetDriveFolderAsync(string folderId);
    public abstract Task<IReadOnlyList<DriveFolder>> GetDriveFoldersAsync(int limit = 10, string? folderId = null, string searchQuery = "");
    public abstract Task<IReadOnlyList<DriveFolder>> GetDriveFoldersAsync(string beforeId, int limit = 10, string? folderId = null, string searchQuery = "");

    public abstract Task<IReadOnlyList<DriveFolder>> GetDriveFilesAsync(string beforeId, string untilId, int limit = 10, string? folderId = null,
        string searchQuery = "");

    public abstract Task<DriveFolder> FindDriveFolderAsync(string name, string? parentId = null);
    public abstract Task<DriveFolder> CreateDriveFolderAsync(string name, string? parentId = null);
    public abstract Task DeleteDriveFolderAsync(string folderId);
    public abstract Task<int> GetOnlineUserCountAsync();
    public abstract Task<Stats> GetStatsAsync();

    /// <summary>
    /// Disposes this client.
    /// </summary>
    public abstract void Dispose();
}
