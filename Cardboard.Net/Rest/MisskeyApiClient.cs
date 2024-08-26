using System.Diagnostics.CodeAnalysis;
using System.Net;
using Cardboard.Net.Clients;
using Cardboard.Net.Entities;
using Cardboard.Net.Entities.Drives;
using Cardboard.Net.Entities.Instance;
using Cardboard.Net.Entities.Instance.Announcements;
using Cardboard.Net.Entities.Notes;
using Cardboard.Net.Entities.Users;
using Cardboard.Net.Rest.Interceptors;
using Cardboard.Net.Util;
using Cardboard.Notes;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Cardboard.Net.Rest;

public sealed class MisskeyApiClient : IDisposable
{
    private readonly RestClient rest;
    private readonly JsonSerializerSettings jsonSettings;
    private ILogger Logger { get; }
    internal BaseMisskeyClient? client;
    
    public MisskeyApiClient(
        IOptions<MisskeyClientOptions> options, 
        ILogger<MisskeyApiClient> logger,
        StatusInterceptor statusInterceptor,
        RawJsonInterceptor rawJsonInterceptor)
    {
        Logger = logger;
        Utilities.NullOrWhitespaceCheck(nameof(options.Value.Token), options.Value.Token);

        RestClientOptions restClientOptions = new RestClientOptions(options.Value.Host);
        restClientOptions.UserAgent = "cardboard.NET/v0.0.1a";
        restClientOptions.Interceptors = [statusInterceptor, rawJsonInterceptor];
        jsonSettings = new JsonSerializerSettings();
        
        rest = new RestClient
        (
            restClientOptions,
            configureSerialization: s => s.UseNewtonsoftJson(jsonSettings)
        );

        rest.AddDefaultHeader("Authorization", $"Bearer {options.Value.Token}");
    }
    
    internal void SetClient(BaseMisskeyClient client)
        => this.client = client;
    
    #region Users

    internal async ValueTask<Account?> GetCurrentUserAsync()
    {
        RestResponse response = await SendRequestAsync(Endpoints.SELF_USER);
        if (null == response.Content) return null;
        
        Account? acc = JsonConvert.DeserializeObject<Account>(response.Content);
        if (null == acc) return null;
        
        if (acc.avatarDecorations.Any())
        {
            foreach (UserDecoration decoration in acc.avatarDecorations)
            {
                decoration.Misskey = client!;
            }
        }

        if (acc.pinnedNotes.Any())
        {
            foreach (Note note in acc.pinnedNotes)
            {
                note.Misskey = client!;
            }
        }
        
        acc.Misskey = client!;
        return acc;
    }
    
    internal async ValueTask<User?> GetUserAsync(string userId)
    {
        RestResponse response = await SendRequestAsync(Endpoints.USERS_SHOW,
            JsonSerializer.Serialize(new {userId = userId}));
        if (null == response.Content) return null;

        User? user = JsonConvert.DeserializeObject<User>(response.Content!);
        if (null == user) return null;
        
        if (user.avatarDecorations.Any())
        {
            foreach (UserDecoration decoration in user.avatarDecorations)
            {
                decoration.Misskey = client!;
            }
        }

        if (user.pinnedNotes.Any())
        {
            foreach (Note note in user.pinnedNotes)
            {
                note.Misskey = client!;
            }
        }
        
        user.Misskey = client!;
        return user;
    }
    
    internal async ValueTask<User?> GetUserAsync(string username, string? host = null)
    {
        RestResponse response = await SendRequestAsync(Endpoints.USERS_SHOW,
            JsonConvert.SerializeObject(new {username = username, host = host}));

        User? user = JsonConvert.DeserializeObject<User>(response.Content!);
        
        if (null == user) return null;
        
        if (user.avatarDecorations.Any())
        {
            foreach (UserDecoration decoration in user.avatarDecorations)
            {
                decoration.Misskey = client!;
            }
        }

        if (user.pinnedNotes.Any())
        {
            foreach (Note note in user.pinnedNotes)
            {
                note.Misskey = client!;
            }
        }
        
        user.Misskey = client!;
        return user;
    }

    internal async Task SilenceUserAsync(string userId, bool selfsilence = false)
    {
        if (client == null)
            throw new InvalidOperationException("Client is null in internal method");
        var currentUser = await client.GetCurrentUserAsync();
        if (!selfsilence && userId == currentUser?.Id)
        {
            /*
             * I actually haven't tested this for *obvious* reasons, but in my
             * opinion we should throw an error by default. I don't want people
             * potentially shooting themselves in the foot. If they're insistent
             * they can override this behavior.
             */
            throw new InvalidOperationException("Cannot silence self, to override: set selfsilence to true!");
        }
        
        RestResponse response = await SendRequestAsync(Endpoints.ADMIN_SILENCE_USER, 
            JsonConvert.SerializeObject(new {userId = userId}));
        
        if (response.StatusCode == HttpStatusCode.Forbidden) 
        {
            throw new InvalidOperationException("Account does not have permission to silence!");
        }
    }

    internal async Task UnsilenceUserAsync(string userId) {
        RestResponse response = await SendRequestAsync(Endpoints.ADMIN_UNSILENCE_USER, 
            JsonConvert.SerializeObject(new {userId = userId}));
        
        if (response.StatusCode == HttpStatusCode.Forbidden) 
        {
            throw new InvalidOperationException("Account does not have permission to unsilence!");
        }
    }

    internal async Task SuspendUserAsync(string userId, bool selfsuspend = false)
    {
        if (client == null)
            throw new InvalidOperationException("Client is null in internal method");
        var currentUser = await client.GetCurrentUserAsync();
        if (!selfsuspend && userId == currentUser?.Id)
        {
            /*
             * I actually haven't tested this for *obvious* reasons, but in my
             * opinion we should throw an error by default. I don't want people
             * potentially shooting themselves in the foot. If they're insistent
             * they can override this behavior.
             */
            throw new InvalidOperationException("Cannot silence self, to override: set selfsuspend to true!");
        }
        
        RestResponse response = await SendRequestAsync(Endpoints.ADMIN_SUSPEND_USER, 
            JsonConvert.SerializeObject(new {userId = userId}));

        if (response.StatusCode == HttpStatusCode.Forbidden)
        {
            throw new InvalidOperationException("Account does not have permission to suspend!");
        }
    }
    
    internal async Task UnsuspendUserAsync(string userId)
    {
        RestResponse response = await SendRequestAsync(Endpoints.ADMIN_UNSUSPEND_USER, 
            JsonConvert.SerializeObject(new {userId = userId}));

        if (response.StatusCode == HttpStatusCode.Forbidden)
        {
            throw new InvalidOperationException("Account does not have permission to unsuspend!");
        }
    }
    
    #endregion
    
    #region Notes

    internal async ValueTask<Note> CreateNoteAsync
    (
        string text,
        string? contentWarning = null,
        VisibilityType visibility = VisibilityType.Public,
        bool isLocal = false,
        AcceptanceType acceptance = AcceptanceType.NonSensitiveOnly
    )
    {
        if (client == null)
            throw new InvalidOperationException("Client is null in internal method");
        var instance = await client.GetCurrentInstanceAsync();
        if (instance != null)
        {
            if (text.Length > instance.Meta?.MaxNoteLength)
            {
                throw new ArgumentException($"Text is greater than note length for this instance {instance.Meta.MaxNoteLength}");
            }
        }
        
        RestResponse<CreatedNote> response = await SendRequestAsync<CreatedNote>(Endpoints.NOTE_CREATE,
            JsonConvert.SerializeObject(new {
                text = text,
                cw = contentWarning,
                visibility = visibility,
                localOnly = isLocal,
                reactionAcceptance = acceptance
            }    
        ));

        Note responseNote = response.Data!.Note;
        responseNote.Misskey = this.client!;
        
        return responseNote;
    }
    
    internal async ValueTask<Note> GetNoteAsync(string noteId)
    {
        RestResponse<Note> response = await SendRequestAsync<Note>(Endpoints.NOTE_SHOW, JsonSerializer.Serialize(new {noteId = noteId }));
        response.Data!.Misskey = this.client!;
        return response.Data!;
    }
    
    #endregion
    
    #region Emoji

    internal async ValueTask<Emoji> GetEmojiAsync(string name)
    {
        /*
         * api-doc is not an accurate source of information for this endpoint.
         * valid request types:
         *      POST $URL/api/emoji {"name":"example"}
         *      GET $URL/api/emoji?name=example
         */
        RestResponse<Emoji> response = await SendRequestAsync<Emoji>(Endpoints.EMOJI, JsonSerializer.Serialize(new {name = name}));
        response.Data!.Misskey = client!;
        return response.Data!;
    }
    
    #endregion
    
    #region Drive
    
    internal async ValueTask<DriveUsage> GetDriveUsageAsync()
    {
        RestResponse<DriveUsage> response = await SendRequestAsync<DriveUsage>(Endpoints.DRIVE);
        return response.Data!;
    }

    internal async Task<DriveFile> GetDriveFileAsync(string input, ShowType type)
    {
        string body = "";
        switch (type)
        {
            case ShowType.FileId:
                body = JsonSerializer.Serialize(new {fileId = input});
                break;
            case ShowType.FileUrl:
                body = JsonSerializer.Serialize(new { url = input });
                break;
        }

        RestResponse<DriveFile> response = await SendRequestAsync<DriveFile>(Endpoints.DRIVE_FILE_SHOW, body);
        response.Data!.Misskey = client!;
        return response.Data!;
    }

    internal async Task<DriveFolder> GetDriveFolderAsync(string folderId)
    {
        RestResponse<DriveFolder> response = await SendRequestAsync<DriveFolder>(Endpoints.DRIVE_FOLDER_SHOW,
            JsonSerializer.Serialize(new { folderId = folderId }));
        response.Data!.Misskey = client!;
        return response.Data!;
    }

    internal async ValueTask<DriveFolder> CreateDriveFolderAsync(string name, string? parentId = null)
    {
        RestResponse<DriveFolder> response = await SendRequestAsync<DriveFolder>(Endpoints.DRIVE_FOLDER_CREATE,
            JsonSerializer.Serialize(new { name = name, parentId = parentId }));
        response.Data!.Misskey = client!;
        return response.Data!;
    }
    
    internal async ValueTask<DriveFolder> FindDriveFolderAsync(string name, string? parentId = null)
    {
        RestResponse<DriveFolder> response = await SendRequestAsync<DriveFolder>(Endpoints.DRIVE_FOLDER_FIND, 
            JsonConvert.SerializeObject(new { name = name, parentId = parentId }));
        response.Data!.Misskey = client!;
        return response.Data!; 
    }
    
    
    [Experimental(diagnosticId: "FoldersExperiment")]
    internal async ValueTask<IReadOnlyList<DriveFolder>> GetDriveFoldersAsync(int limit = 10, string? folderId = null, string searchQuery = "")
    {
        RestResponse response = await SendRequestAsync(Endpoints.DRIVE_FOLDERS,
            JsonSerializer.Serialize(new {limit = limit, folderId = folderId }));

        if (null == response.Content)
        {
            return new List<DriveFolder>();
        }

        return JsonSerializer.Deserialize<List<DriveFolder>>(response.Content) ?? new List<DriveFolder>();
    }
    
    [Experimental(diagnosticId: "FoldersExperiment")]
    internal async ValueTask<IReadOnlyList<DriveFolder>> GetDriveFoldersAsync
    (
        string beforeId, 
        int limit = 10, 
        string? folderId = null, 
        string searchQuery = ""
    )
    {
        RestResponse response = await SendRequestAsync(Endpoints.DRIVE_FOLDERS,
            JsonConvert.SerializeObject(new {limit = limit, beforeId = beforeId, folderId = folderId, searchQuery = searchQuery }));

        if (null == response.Content)
        {
            return new List<DriveFolder>();
        }

        return JsonSerializer.Deserialize<List<DriveFolder>>(response.Content) ?? new List<DriveFolder>();
    }
    
    [Experimental(diagnosticId: "FoldersExperiment")]
    internal async ValueTask<IReadOnlyList<DriveFolder>> GetDriveFoldersAsync
    (
        string beforeId, 
        string untilId, 
        int limit = 10, 
        string? folderId = null, 
        string searchQuery = ""
    )
    {
        RestResponse response = await SendRequestAsync(Endpoints.DRIVE_FOLDERS,
            JsonConvert.SerializeObject(new {limit = limit, beforeId = beforeId, untilId = untilId, folderId = folderId, searchQuery = searchQuery }));

        if (null == response.Content)
        {
            return new List<DriveFolder>();
        }

        return JsonSerializer.Deserialize<List<DriveFolder>>(response.Content) ?? new List<DriveFolder>();
    }
    
    #endregion
    
    #region CurrentInstance
    
    internal async ValueTask<int> GetOnlineUserCountAsync()
    {
        RestResponse<UserCount> response = await rest.ExecuteGetAsync<UserCount>(Endpoints.INSTANCE_USERS_ONLINE);
        return response.Data!.Count;
    }
    
    #region Announcements
    
    internal async Task<Announcement?> GetAnnouncementAsync(string announcementId)
    {
        Utilities.NullOrWhitespaceCheck(nameof(announcementId), announcementId);
        
        RestResponse response = await SendRequestAsync(Endpoints.INSTANCE_ANNOUNCEMENTS_SHOW, 
            JsonConvert.SerializeObject(new { announcementId = announcementId }));
        if (null == response.Content) return null;
        
        Announcement? announcement = JsonSerializer.Deserialize<Announcement>(response.Content); 
        if (null == announcement) return null;
        
        announcement.Misskey = client!;
        return announcement;
    }

    internal async Task<IReadOnlyList<Announcement>> GetAnnouncementsAsync
    (
        int limit = 10,
        string? sinceId = null,
        string? untilId = null,
        bool isActive = true
    )
    {
        Utilities.CheckLimit(nameof(limit), limit);
        
        string body = JsonConvert.SerializeObject(new
        {
            limit = limit,
            sinceId = sinceId,
            untilId = untilId,
            isactive = isActive
        }, new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore});
        
        RestResponse response = await SendRequestAsync(Endpoints.INSTANCE_ANNOUNCEMENTS, body);
        if (null == response.Content) return [];
        
        List<Announcement> announcements = JsonConvert.DeserializeObject<List<Announcement>>(response.Content) ?? [];
        if (!announcements.Any()) return announcements;

        foreach (Announcement announcement in announcements)
        {
            announcement.Misskey = client!;
            announcement.IsActive = isActive;
        }
        
        return announcements;
    }

    /// <summary>
    /// Gets announcements with the reads property
    /// </summary>
    /// <param name="limit">Limit</param>
    /// <param name="sinceId"></param>
    /// <param name="untilId"></param>
    /// <param name="userId">user id if it's for a given user</param>
    /// <returns></returns>
    internal async Task<IReadOnlyList<AdminAnnouncementLite>> GetAnnouncementsAdminAsync
    (
        int limit = 10,
        string? sinceId = null,
        string? untilId = null,
        string? userId = null
    )
    {
        Utilities.CheckLimit(nameof(limit), limit);
        
        string body = JsonConvert.SerializeObject(new
        {
            limit = limit,
            sinceId = sinceId,
            untilId = untilId,
            userId = userId
        }, new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore});
        
        RestResponse response = await SendRequestAsync(Endpoints.ADMIN_INSTANCE_ANNOUNCEMENTS_LIST, body);
        
        if (response.StatusCode == HttpStatusCode.Forbidden)
        {
            throw new InvalidOperationException("Account does not have the ability to list announcements from admin view");
        }
        
        if (null == response.Content) return [];
        
        List<AdminAnnouncementLite> announcements = JsonConvert.DeserializeObject<List<AdminAnnouncementLite>>(response.Content) ?? [];
        if (!announcements.Any()) return announcements;

        foreach (AdminAnnouncementLite announcement in announcements)
        {
            announcement.Misskey = client!;
            announcement.IsActive = null;
        }
        
        return announcements;
    }
    
    internal async Task<AnnouncementLite?> CreateAnnouncementAsync
    (
        string title, 
        string text,
        Uri? imageUrl = null, 
        DisplayType displayType = DisplayType.Normal,
        IconType iconType = IconType.Info,
        bool existingUsers = false,
        bool silence = false,
        bool readConfirmation = false,
        string? userId = null
    )
    {
        Utilities.NullOrWhitespaceCheck(nameof(title), title);
        Utilities.NullOrWhitespaceCheck(nameof(text), text);

        string body = JsonConvert.SerializeObject(new
        {
            title = title,
            text = text,
            imageUrl = imageUrl,
            displayType = displayType,
            iconType = iconType,
            existingUsers = existingUsers,
            silence = silence,
            readConfirmation = readConfirmation,
            userId = userId
        }, new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore});
        
        RestResponse response = await SendRequestAsync(Endpoints.ADMIN_INSTANCE_ANNOUNCEMENTS_CREATE, body);

        if (response.StatusCode == HttpStatusCode.Forbidden)
        {
            throw new InvalidOperationException("Account does not have the ability to create announcements");
        }
        
        if (null == response.Content) return null;
        
        AnnouncementLite? announcement = JsonConvert.DeserializeObject<AnnouncementLite>(response.Content);
        if (announcement == null) return null;
        
        announcement.Misskey = client!;
        announcement.IsActive = true;
        
        return announcement;
    }
    
    internal async Task<bool> ModifyAnnouncementAsync
    (
        string announcementId,
        string? title = null, 
        string? text = null,
        Uri? imageUrl = null, 
        bool? existingUsers = null,
        bool? isActive = null
    )
    {
        Utilities.NullOrWhitespaceCheck(nameof(title), announcementId);
        
        string body = JsonConvert.SerializeObject(new
        {
            announcementId = announcementId,
            title = title,
            text = text,
            imageUrl = imageUrl,
            existingUsers = existingUsers,
            isActive = isActive
        }, new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore});
        
        RestResponse response = await SendRequestAsync(Endpoints.ADMIN_INSTANCE_ANNOUNCEMENTS_UPDATE, body);

        if (response.StatusCode == HttpStatusCode.Forbidden)
        {
            throw new InvalidOperationException("Account does not have the ability to modify announcements");
        }

        return response.StatusCode == HttpStatusCode.NoContent;
    }
    
    internal async Task<bool> ModifyAnnouncementAsync
    (
        string announcementId,
        string? title = null, 
        string? text = null,
        Uri? imageUrl = null, 
        IconType? iconType = null,
        DisplayType? displayType = null,
        bool? existingUsers = null,
        bool? silence = null,
        bool? readConfirmation = null,
        bool? isActive = null
    )
    {
        Utilities.NullOrWhitespaceCheck(nameof(title), announcementId);
        
        string body = JsonConvert.SerializeObject(new
        {
            announcementId = announcementId,
            title = title,
            text = text,
            imageUrl = imageUrl,
            displayType = displayType,
            existingUsers = existingUsers,
            silence = silence,
            readConfirmation = readConfirmation,
            isActive = isActive
        }, new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore});
        
        RestResponse response = await SendRequestAsync(Endpoints.ADMIN_INSTANCE_ANNOUNCEMENTS_UPDATE, body);

        if (response.StatusCode == HttpStatusCode.Forbidden)
        {
            throw new InvalidOperationException("Account does not have the ability to modify announcements");
        }

        return response.StatusCode == HttpStatusCode.NoContent;
    }

    
    internal async Task DeleteAnnouncementAsync(string announcementId)
    {
        RestResponse response = await SendRequestAsync(Endpoints.ADMIN_INSTANCE_ANNOUNCEMENTS_DELETE,
            JsonConvert.SerializeObject(new { announcementId = announcementId }));

        if (response.StatusCode == HttpStatusCode.Forbidden)
        {
            throw new InvalidOperationException("Account does not have permission to delete announcements");
        }
    }
    
    #endregion
    
    internal async ValueTask<IReadOnlyList<AvatarDecoration>> GetAvatarDecorationsAsync()
    {
        RestResponse response = await SendRequestAsync(Endpoints.AVATAR_DECORATIONS_GET);
        if (null == response.Content) return [];
        
        List<AvatarDecoration> decorations = JsonConvert.DeserializeObject<List<AvatarDecoration>>(response.Content) ?? [];
        if (!decorations.Any()) return decorations;
        
        foreach (AvatarDecoration decoration in decorations)
        {
            decoration.Misskey = client!;
        }

        return decorations;
    }

    internal async ValueTask<Meta> GetMetaAsync()
    {
        RestResponse<Meta> response = await SendRequestAsync<Meta>(Endpoints.INSTANCE_META);

        if (!response.Data!.ads.Any()) return response.Data!;
        
        foreach (Ad ad in response.Data!.ads)
        {
            ad.Misskey = client!;
        }

        return response.Data!;
    }

    internal async ValueTask<IReadOnlyList<AdminUserIp>> GetUserIpsAsync(string userId)
    {
        RestResponse response = await SendRequestAsync(Endpoints.ADMIN_USER_IPS,
            JsonConvert.SerializeObject(new {userId = userId}));

        if (response.StatusCode == HttpStatusCode.Forbidden)
        {
            throw new InvalidOperationException("Account does not have permission to get ips");
        }
        
        if (null == response.Content) return [];

        List<AdminUserIp> ips = JsonConvert.DeserializeObject<List<AdminUserIp>>(response.Content) ?? [];
        return ips;
    }
    
    internal async ValueTask DeleteUserAsync(string userId, bool selfdelete = false)
    {
        if (client == null)
            throw new InvalidOperationException("Client is null in internal method");
        var currentUser = await client.GetCurrentUserAsync();
        if (!selfdelete && userId == currentUser?.Id)
        {
            /*
             * I actually haven't tested this for *obvious* reasons, but in my
             * opinion we should throw an error by default. I don't want people
             * potentially shooting themselves in the foot. If they're insistent
             * they can override this behavior.
             */
            throw new InvalidOperationException("Cannot delete self, to override: set selfdelete to true!");
        }
        
        RestResponse response = await SendRequestAsync(Endpoints.ADMIN_ACCOUNTS_DELETE, 
            JsonConvert.SerializeObject(new {userId = userId}));

        if (response.StatusCode == HttpStatusCode.Forbidden)
        {
            throw new InvalidOperationException("Account does not have permission to delete user");
        }
    }
    
    #endregion
    
    internal async Task<RestResponse<T>> SendRequestAsync<T>(string endpoint, string body = "{}")
    {
        RestRequest request = new RestRequest();
        request.Resource = endpoint;
        request.AddJsonBody(body);
        return await rest.ExecutePostAsync<T>(request);
    }

    internal async Task<RestResponse> SendRequestAsync(string endpoint, string body = "{}")
    {
        RestRequest request = new RestRequest();
        request.Resource = endpoint;
        request.AddJsonBody(body);
        return await rest.ExecutePostAsync(request);
    }
    
    public void Dispose()
    {
        rest?.Dispose();
        GC.SuppressFinalize(this);
    }
}
