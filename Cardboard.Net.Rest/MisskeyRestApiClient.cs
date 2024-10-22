using System.Net;
using Cardboard.Drives;
using Cardboard.Net.Rest;
using Cardboard.Net.Rest.API;
using Cardboard.Net.Rest.Interceptors;
using Cardboard.Notes;
using Cardboard.Rest.Drives;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using Poll = Cardboard.Notes.Poll;

namespace Cardboard;

internal class MisskeyRestApiClient : IDisposable
{
    protected readonly JsonSerializerSettings _serializerSettings;
    protected readonly SemaphoreSlim _stateLock;
    
    protected bool _isDisposed;
    
    private ILogger Logger { get; }
    internal string AuthToken { get; private set; }
    internal RestClient RestClient { get; private set; }
    internal RequestInterceptor RequestInterceptor { get; private set; }
    internal SelfUser FirstLoginUser { get; private set; }
    
    public string UserAgent { get; }

    public MisskeyRestApiClient(
        IOptions<MisskeyConfig> options,
        ILogger<MisskeyRestApiClient> logger,
        RequestInterceptor requestInterceptor
    )
    {
        Logger = logger;
        UserAgent = options.Value.UserAgent;
        RequestInterceptor = requestInterceptor;
        _serializerSettings = options.Value.SerializerSettings;
        _stateLock = new SemaphoreSlim(1, 1);
    }

    internal void SetBaseUrl(Uri baseUrl)
    {
        this.RestClient?.Dispose();
        RestClientOptions clientOptions = new RestClientOptions(baseUrl)
        {
            UserAgent = UserAgent,
            Interceptors = [RequestInterceptor]
        };
        this.RestClient = new RestClient(clientOptions, configureSerialization: s => s.UseNewtonsoftJson(_serializerSettings));
    }
    
    public async Task LoginAsync(string token, Uri baseUrl)
    {
        await _stateLock.WaitAsync().ConfigureAwait(false);
        try
        {
            AuthToken = token;
            SetBaseUrl(baseUrl);

            RestResponse<SelfUser> response = await WrappedRequestAuthAsync<SelfUser>("/api/i");
            
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    FirstLoginUser = response.Data!;
                    Logger.LogInformation("Authentication Success!");
                    break;
                case HttpStatusCode.Forbidden:
                    throw new InvalidOperationException("Token is invalid");
                default:
                    throw new InvalidOperationException("Server responded with an unknown error");
            }
        }
        finally { _stateLock.Release(); }
    }
    
    #region Announcements
    
    /// <summary>
    ///     Fetches an announcement given the announcementId
    /// </summary>
    /// <remarks>
    ///     api-doc#tag/meta/operation/announcements
    ///
    ///     Does not require auth
    /// </remarks>
    /// <param name="id">id corresponding to the announcement</param>
    /// <returns>An instance of UserAnnouncement if found</returns>
    public async Task<UserAnnouncement?> GetAnnouncementAsync(string id)
        => await RequestAsync<UserAnnouncement>("/api/announcements/show",
            JsonConvert.SerializeObject(new { announcementId = id }));
    
    /// <summary>
    ///     Fetches all announcements matching the specified parameters
    /// </summary>
    /// <remarks>
    ///     api-doc#tag/meta/operation/announcements
    ///
    ///     Does not require auth
    /// </remarks>
    /// <param name="args">The DTO containing request arguments to serialize into json</param>
    /// <returns>An array of UserAnnouncement objects</returns>
    public async Task<UserAnnouncement[]?> GetAnnouncementsAsync(GetAnnouncementsParam args)
        => await RequestAsync<UserAnnouncement[]>("/api/announcements",
            JsonConvert.SerializeObject(args,
                new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
    
    /// <summary>
    ///     Reads an announcement
    /// </summary>
    /// <remarks>
    ///     api-doc#tag/account/operation/i___read-announcement
    ///
    ///     Requires auth and scope write:account
    /// </remarks>
    /// <param name="id"></param>
    public async Task ReadAnnouncementAsync(string id)
        => await RequestAuthAsync("/api/i/read-announcement", JsonConvert.SerializeObject(new { announcementId = id }));

    /// <summary>
    ///     Creates an announcement
    /// </summary>
    /// <remarks>
    ///     api-doc#tag/admin/operation/admin___announcements___create
    ///
    ///     Requires auth and scope write:admin:announcements
    /// </remarks>
    /// <param name="args">The DTO containing the request parameters to serialize into json</param>
    /// <returns>an instance of AdminAnnouncement containing the newly created announcement</returns>
    /// <exception cref="InvalidOperationException">Thrown if unable to create the announcement</exception>
    public async Task<AdminAnnouncement> CreateAnnouncementAsync(CreateAnnouncementParams args)
    {
        RestResponse<AdminAnnouncement> response = await WrappedRequestAuthAsync<AdminAnnouncement>
        (
            "/api/admin/announcements/create",
            JsonConvert.SerializeObject(args, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore })
        );
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("error creating announcement");
        }
        return response.Data!;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<bool> ModifyAnnouncementAsync(ModifyAnnouncementParams args)
    {
        RestResponse response = await WrappedRequestAuthAsync("/api/admin/announcements/update", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to update announcement");
        }
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task DeleteAnnouncementAsync(string id)
    {
        RestResponse response = await SendWrappedRequestAsync("/api/announcements/delete", JsonConvert.SerializeObject(new { id = id }));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to delete announcement");
        }
    }
    
    #endregion
    
    #region Antennas

    public async Task<Antenna?> GetAntennaAsync(string id)
        => await SendRequestAsync<Antenna>("/api/antennas/show", JsonConvert.SerializeObject(new { antennaId = id }));
    
    public async Task<Note[]?> GetAntennaNotesAsync(GetAntennaNotesParams args)
    {
        RestResponse<Note[]> response = await SendWrappedRequestAsync<Note[]>("/api/antennas/notes", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        return response.Data;
    }
    
    public async Task<Antenna?> CreateAntennaAsync(CreateAntennaParams args)
    {
        RestResponse<Antenna> response = await SendWrappedRequestAsync<Antenna>("/api/antennas/create",
            JsonConvert.SerializeObject(args,
                new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("error creating antenna");
        }
        return response.Data;
    }
    
    public async Task<Antenna?> ModifyAntennaAsync(ModifyAntennaParams args)
    {
        RestResponse<Antenna> response = await SendWrappedRequestAsync<Antenna>("/api/antennas/update", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("error modifying the antenna");
        }
        
        return response.Data;
    }
    
    public async Task DeleteAntennaAsync(string id)
    {
        RestResponse response = await SendWrappedRequestAsync("/api/antennas/delete", JsonConvert.SerializeObject(new { antennaId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to delete antenna");
        }
    }
    
    #endregion
    
    #region Clips

    public async Task<Clip?> GetClipAsync(string id)
        => await SendRequestAsync<Clip>("/api/clips/show", JsonConvert.SerializeObject(new { clipId = id }));

    public async Task<Clip> CreateClipAsync(CreateClipParams args)
    {
        RestRequest request = new RestRequest
        {
            Resource = "/api/clips/create"
        };
        request.AddJsonBody(JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        RestResponse<Clip> response = await RestClient.ExecutePostAsync<Clip>(request);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("error creating clip");
        }
        return response.Data!;
    }
    
    public async Task FavoriteClipAsync(string id)
    {
        RestResponse response = await SendWrappedRequestAsync("/api/clips/favorite", JsonConvert.SerializeObject(new { clipId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to favorite clip");
        }
    }
    
    public async Task UnfavoriteClipAsync(string id)
    {
        RestResponse response = await SendWrappedRequestAsync("/api/clips/unfavorite", JsonConvert.SerializeObject(new { clipId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to unfavorite clip");
        }
    }

    public async Task<Note[]?> GetClipNotesAsync(GetClipNotesParams args)
        => await SendRequestAsync<Note[]>("/api/clips/notes", JsonConvert.SerializeObject(args, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));

    public async Task<Clip?> ModifyClipAsync(ModifyClipParams args)
    {
        RestResponse<Clip> response = await SendWrappedRequestAsync<Clip>("/api/clips/update", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("error modifying the clip");
        }
        
        return response.Data;
    }
    
    public async Task DeleteClipAsync(string id)
    {
        RestResponse response = await SendWrappedRequestAsync("/api/clips/delete", JsonConvert.SerializeObject(new { clipId = id }));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to delete clip");
        }
    }
    
    #endregion
    
    #region Channels
    public async Task<Channel> CreateChannelAsync(CreateChannelParams args) {
        RestRequest request = new RestRequest
        {
            Resource = "/api/channels/create"
        };
        request.AddJsonBody(JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        RestResponse<Channel> response = await RestClient.ExecutePostAsync<Channel>(request);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("Something went wrong while creating the channel.");
        }
        return response.Data!;
    }

    public async Task<Channel> ModifyChannelAsync(ModifyChannelParams args)
    {
        RestResponse<Channel> response = await SendWrappedRequestAsync<Channel>("/api/channels/update", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("Something went wrong while updating the channel.");
        }
        
        return response.Data!;
    }

    public async Task ArchiveChannelAsync(
        string ChannelId
    ) {
        await SendRequestAsync("/api/channels/update", JsonConvert.SerializeObject(new {channelId = ChannelId, isArchived = true}));
    }

    #endregion

    #region Charts

    public async Task<ActiveUserChart> GetActiveUserChartAsync(GetChartParams args)
    {
        ActiveUserChart? chart = await SendRequestAsync<ActiveUserChart>("/api/charts/active-users", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        return chart!;
    }
    
    public async Task<ApRequestChart> GetApRequestChartAsync(GetChartParams args)
    {
        ApRequestChart? chart = await SendRequestAsync<ApRequestChart>("/api/charts/ap-request", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        return chart!;
    }
    
    public async Task<DriveChart> GetDriveChartAsync(GetChartParams args)
    {
        DriveChart? chart = await SendRequestAsync<DriveChart>("/api/charts/drive", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        return chart!;
    }
    
    public async Task<FederationChart> GetFederationChartAsyncc(GetChartParams args)
    {
        FederationChart? chart = await SendRequestAsync<FederationChart>("/api/charts/federation", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        return chart!;
    }
    
    public async Task<InstanceUserChart> GetUsersChartAsync(GetChartParams args)
    {
        InstanceUserChart? chart = await SendRequestAsync<InstanceUserChart>("/api/charts/users", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        return chart!;
    }
    
    #endregion
    
    #region Notes

    public async Task<Note?> GetNoteAsync(string id)
        => await SendRequestAsync<Note>("/api/notes/show", JsonConvert.SerializeObject(new { noteId = id }));

    public async Task<Note[]?> GetRenotesAsync(GetRenotesParam args)
    {
        RestResponse<Note[]> response = await SendWrappedRequestAsync<Note[]>("/api/notes/renotes", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        return response.Data;
    }
    
    public async Task<Note[]?> GetRepliesAsync(GetRepliesParam args)
    {
        RestResponse<Note[]> response = await SendWrappedRequestAsync<Note[]>("/api/notes/replies", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        return response.Data;
    }

    public async Task<Clip[]?> GetClipsAsync()
    {
        RestResponse<Clip[]> response = await SendWrappedRequestAsync<Clip[]>("/api//clips/list");
        return response.Data;
    }
    
    public async Task<Clip[]?> GetClipsAsync(string id)
    {
        RestResponse<Clip[]> response =
            await SendWrappedRequestAsync<Clip[]>("/api/notes/clips", JsonConvert.SerializeObject(new { noteId = id }));
        return response.Data;
    }

    public async Task<Note?> CreateNoteAsync(CreateNoteParams args)
    {
        RestRequest request = new RestRequest
        {
            Resource = "/api/notes/create"
        };
        request.AddJsonBody(JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        RestResponse<CreatedNote> response = await RestClient.ExecutePostAsync<CreatedNote>(request);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("error creating note");
        }
        return response.Data?.Note;
    }
    
    public async Task MuteNoteAsync(string id)
    {
        RestResponse response = await SendWrappedRequestAsync("/api/notes/thread-muting-create", JsonConvert.SerializeObject(new {noteId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to mute note");
        }
    }
    
    public async Task UnmuteNoteAsync(string id)
    {
        RestResponse response = await SendWrappedRequestAsync("/api/notes/thread-muting-delete", JsonConvert.SerializeObject(new {noteId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to unmute note");
        }
    }
    
    public async Task FavoriteNoteAsync(string id)
    {
        RestResponse response = await SendWrappedRequestAsync("/api/notes/favorites/create", JsonConvert.SerializeObject(new {noteId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to favorite note");
        }
    }
    
    public async Task UnfavoriteNoteAsync(string id)
    {
        RestResponse response = await SendWrappedRequestAsync("/api/notes/favorites/delete", JsonConvert.SerializeObject(new {noteId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to unfavorite note");
        }
    }
    
    public async Task<Note?> ModifyNoteAsync(ModifyNoteParams args)
    {
        RestResponse<CreatedNote> response = await SendWrappedRequestAsync<CreatedNote>("/api/notes/edit", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("error modifying the note");
        }
        
        return response.Data?.Note;
    }
    
    public async Task DeleteNoteAsync(string id)
    {
        RestResponse response = await SendWrappedRequestAsync("/api/notes/delete", JsonConvert.SerializeObject(new {noteId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to delete note");
        }
    }
    
    #endregion
    
    #region Drive

    public async Task<DriveFile> GetFileAsync(string id)
        => await SendRequestAsync<DriveFile>("/api/drive/files/show", JsonConvert.SerializeObject(new {fileId = id}));
    
    public async Task<DriveFile> GetFileAsync(Uri url)
        => await SendRequestAsync<DriveFile>("/api/drive/files/show", JsonConvert.SerializeObject(new {url = url.ToString()}));

    public async Task<DriveFolder> GetFolderAsync(string id)
        => await SendRequestAsync<DriveFolder>("/api/drive/folders/show", JsonConvert.SerializeObject(new {folderId = id}));
    
    public async Task UploadFileUriAsync(Uri url, string? folderId = null, string? comment = null, string? marker = null,
        bool? isSensitive = false, bool force = false)
    {
        CreateFileUriParams file = new CreateFileUriParams()
        {
            Url = url,
            FolderId = folderId,
            Comment = comment,
            Marker = marker, 
            IsSensitive = isSensitive,
            Force = force
        };
        
        RestRequest request = new RestRequest();
        request.Resource = "/api/drive/files/upload-from-url";
        request.AddJsonBody(JsonConvert.SerializeObject(file, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        RestResponse response = await RestClient.ExecutePostAsync(request);
        
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("error uploading file");
        }
    }

    public async Task UploadFileAsync()
        => throw new NotImplementedException();
    
    // TODO: CreateFolderAsync

    // saving this one for kyla, i want to teach her a basic request
    public async Task<DriveFolder> CreateFolderAsync(string name, string? parentId = null)
        => throw new NotImplementedException();
    
    public async Task<DriveFile> ModifyDriveFileAsync(string fileId, ModifyFileParams args)
    {
        RestResponse<DriveFile> response = await SendWrappedRequestAsync<DriveFile>("/api/drive/files/update", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("error modifying the file");
        }
        
        return response.Data!;
    }

    public async Task<DriveFolder> ModifyDriveFolderAsync(string folderId, ModifyFolderParams args)
    {
        RestResponse<DriveFolder> response = await SendWrappedRequestAsync<DriveFolder>("/api/drive/folder/update", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("error modifying the folder");
        }
        
        return response.Data!;
    }
    
    public async Task DeleteFileAsync(string id)
    {
        RestResponse response = await SendWrappedRequestAsync("/api/drive/files/delete", JsonConvert.SerializeObject(new {fileId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to delete file");
        }
    }
    
    public async Task DeleteFolderAsync(string id)
    {
        RestResponse response = await SendWrappedRequestAsync("/api/drive/folders/delete", JsonConvert.SerializeObject(new {folderId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to delete folder");
        }
    }
    
    #endregion

    #region Instances

    /// <summary>
    ///     Fetches instance meta
    /// </summary>
    /// <remarks>
    ///     api-doc#tag/meta/operation/meta
    ///
    ///     Does not require auth
    /// </remarks>
    /// <returns>an instance of Meta</returns>
    public async Task<Meta?> GetMetaAsync()
        => await RequestAsync<Meta>("/api/meta");
    
    public async Task<AdminMeta?> GetAdminMetaAsync()
    {
        RestResponse<AdminMeta> response = await SendWrappedRequestAsync<AdminMeta>("/api/admin/meta");
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("you do not have permission to get admin meta");
        }

        return response.Data;
    }
    
    public async Task<FederatedInstance?> GetFederatedInstanceAsync(string host)
        => await SendRequestAsync<FederatedInstance>("/api/federation/show-instance", JsonConvert.SerializeObject(new { host = host }));

    public async Task<FederatedInstance[]?> GetFederatedInstancesAsync(GetFederatedInstancesParams args)
        => await SendRequestAsync<FederatedInstance[]>("/api/federation/instances", JsonConvert.SerializeObject(args, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
    
    public async Task<FederatedInstanceRelation[]?> GetFederatedInstanceFollowingAsync(
        GetFederatedInstanceRelationParams args)
        => await SendRequestAsync<FederatedInstanceRelation[]>("/api/federation/following", JsonConvert.SerializeObject(args, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
    
    public async Task<FederatedInstanceRelation[]?> GetFederatedInstanceFollowersAsync(
        GetFederatedInstanceRelationParams args)
        => await SendRequestAsync<FederatedInstanceRelation[]>("/api/federation/followers", JsonConvert.SerializeObject(args, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));

    public async Task<User[]?> GetFederatedInstanceUsersAsync(GetFederatedInstanceUsersParams args)
        => await SendRequestAsync<User[]>("/api/federation/users",
            JsonConvert.SerializeObject(args,
                new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
    
    public async Task RefreshFederatedInstanceAsync(string host)
    {
        RestResponse response = await SendWrappedRequestAsync("/api/admin/federation/refresh-remote-instance-metadata", JsonConvert.SerializeObject(new {host = host}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("you do not have permission to refresh instance metadata");
        }
    }
    
    public async Task DeleteFederatedInstanceFilesAsync(string host)
    {
        RestResponse response = await SendWrappedRequestAsync("/api/admin/federation/delete-all-files", JsonConvert.SerializeObject(new {host = host}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("you do not have permission to delete all remote instance's files cached locally");
        }
    }
    
    public async Task RemoveFederatedInstanceFollowingAsync(string host)
    {
        RestResponse response = await SendWrappedRequestAsync("/api/admin/federation/remove-all-following", JsonConvert.SerializeObject(new {host = host}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("you do not have permission to destroy remote instance's relation");
        }
    }
    
    public async Task<bool> ModifyFederatedInstanceAsync(ModifyFederatedInstanceParams args)
    {
        RestResponse response = await SendWrappedRequestAsync("/api/admin/federation/update-instance", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to update instance");
        }

        return true;
    }
    
    public async Task<bool> ModifyMetaAsync(ModifyMetaParams args)
    {
        RestResponse response = await SendWrappedRequestAsync("/api/admin/update-meta", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to update instance meta");
        }

        return true;
    }

    public async Task<Ping?> PingAsync()
        => await SendRequestAsync<Ping>("/api/ping");
    
    public async Task<OnlineUsersCount?> GetOnlineUsersAsync()
        => await SendRequestAsync<OnlineUsersCount>("/api/get-online-users-count");
    
    #endregion
    
    #region Lists

    public async Task<Cardboard.Net.Rest.API.List?> GetListAsync(string id, bool forPublic = false)
        => await SendRequestAsync<Cardboard.Net.Rest.API.List>("/api/antennas/show", JsonConvert.SerializeObject(new { listId = id, forPublic = forPublic }));
    
    #endregion
    
    #region Relays
    
    public async Task<Relay[]?> GetRelaysAsync()
    {
        RestResponse<Relay[]> response = await SendWrappedRequestAsync<Relay[]>("/api/admin/relays/list");
        
        if (response.StatusCode == HttpStatusCode.Forbidden)
        {
            throw new InvalidOperationException("you do not have permission to view relays");
        }
        
        return response.Data;
    }

    public async Task<Relay> CreateRelayAsync(Uri inbox)
    {
        RestResponse<Relay> response = await SendWrappedRequestAsync<Relay>("/api/admin/relays/add", JsonConvert.SerializeObject(new { inbox = inbox }));
        
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("unable to add relay");
        }

        return response.Data!;
    }
    
    public async Task DeleteRelayAsync(Uri inbox)
    {
        RestResponse response = await SendWrappedRequestAsync("/api/admin/relays/delete", JsonConvert.SerializeObject(new { inbox = inbox }));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to delete relay");
        }
    }
    
    #endregion
    
    #region Roles

    public async Task<Role?> GetRoleAsync(string id)
    {
        return await SendRequestAsync<Role>($"/api/roles/show", JsonConvert.SerializeObject(new { roleId = id}));
    }
    
    #endregion

    #region Users
    
    /// <summary>
    ///     Fetches the account class from the currently logged-in user
    /// </summary>
    /// <remarks>
    ///     api-doc#tag/account/operation/i
    ///
    ///     Requires auth and scope read:account
    /// </remarks>
    /// <returns>an instance of SelfUser</returns>
    public async Task<SelfUser?> GetSelfUserAsync()
        => await RequestAuthAsync<SelfUser>("/api/i");

    /// <summary>
    ///     Fetches a user given a userId
    /// </summary>
    /// <remarks>
    ///     api-doc#tag/users/operation/users___show
    ///
    ///     Does not require auth
    /// </remarks>
    /// <param name="id">The id of the user to fetch</param>
    /// <returns>an instance of User</returns>
    public async Task<User?> GetUserAsync(string id)
        => await RequestAsync<User>("/api/users/show", JsonConvert.SerializeObject(new { userId = id}));

    /// <summary>
    ///     Fetches a user given a username and optional hostname
    /// </summary>
    /// <remarks>
    ///     api-doc#tag/users/operation/users___show
    /// 
    ///     Does not require auth
    /// </remarks>
    /// <param name="username">The username of the user to fetch</param>
    /// <param name="host">The optional host of the user (null if local)</param>
    /// <returns>an instance of User</returns>
    public async Task<User?> GetUserAsync(string username, Uri? host)
        => await RequestAsync<User>("/api/users/show", JsonConvert.SerializeObject(new { username = username, host = host?.Host}));

    /// <summary>
    ///     Fetches an array of User
    /// </summary>
    /// <remarks>
    ///     api-doc#tag/users/operation/users___show
    /// 
    ///     Does not require auth
    /// </remarks>
    /// <param name="userIds">An array of userIds to fetch</param>
    /// <returns>An array of User objects</returns>
    public async Task<User[]?> GetUsersAsync(string[] userIds)
        => await RequestAsync<User[]>("/api/users/show", JsonConvert.SerializeObject(new { userIds = userIds }));
    
    /// <summary>
    ///     Fetches the current account's relation to another user
    /// </summary>
    /// <remarks>
    ///     api-doc#tag/users/operation/users__relation
    ///
    ///     Requires auth and scope read:account
    /// </remarks>
    /// <param name="userId">The id of the user to fetch the relation for</param>
    /// <returns>an instance of UserRelation</returns>
    public async Task<UserRelation?> GetUserRelation(string userId)
        => await RequestAuthAsync<UserRelation>("/api/users/relation",
            JsonConvert.SerializeObject(new { userId = userId }));
    
    public async Task ReportUserAsync(string id, string comment)
        => await SendRequestAsync("/api/users/report-abuse", JsonConvert.SerializeObject(new { userId = id, comment = comment}));
    
    public async Task AcceptFollowRequestFromUserAsync(string id)
        => await SendRequestAsync("/api/following/requests/accept", JsonConvert.SerializeObject(new { userId = id }));

    public async Task RejectFollowRequestFromUserAsync(string id)
        => await SendRequestAsync("/api/following/requests/reject", JsonConvert.SerializeObject(new { userId = id }));

    public async Task CancelFollowRequestFromUserAsync(string id)
        => await SendRequestAsync("/api/following/requests/cancel", JsonConvert.SerializeObject(new { userId = id }));
    
    public async Task SilenceUserAsync(string id)
        => await SendRequestAsync("/api/admin/silence-user", JsonConvert.SerializeObject(new { userId = id}));

    public async Task DeleteAllFilesOfUserAsync(string id)
        => await SendRequestAsync("/api/admin/admin/delete-all-files-of-a-user", JsonConvert.SerializeObject(new { userId = id}));

    public async Task UnsetUserAvatarAsync(string id)
        => await SendRequestAsync("/api/admin/unset-user-avatar", JsonConvert.SerializeObject(new {userId = id}));

    public async Task UnsetUserBannerAsync(string id)
        => await SendRequestAsync("/api/admin/unset-user-banner", JsonConvert.SerializeObject(new {userId = id}));

    public async Task<Note[]?> GetNotesAsync(GetUserNotesParams args)
        => await SendRequestAsync<Note[]>("/api/users/notes", JsonConvert.SerializeObject(args, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
    
    #endregion

    internal async Task<T?> RequestAuthAsync<T>(string endpoint, string body = "{}")
        => await RequestAsync<T>(endpoint, body, [new ("Authorization", $"Bearer {this.AuthToken}")]);
    
    internal async Task RequestAuthAsync(string endpoint, string body = "{}")
        => await RequestAsync(endpoint, body, [new ("Authorization", $"Bearer {this.AuthToken}")]);
    
    internal async Task<T?> RequestAsync<T>(string endpoint, string body = "{}", List<KeyValuePair<string, string>>? headers = null)
    {
        RestResponse<T> response = await WrappedRequestAsync<T>(endpoint, body, headers);
        return response.Data;
    }
    
    internal async Task RequestAsync(string endpoint, string body = "{}", List<KeyValuePair<string, string>>? headers = null)
        => await WrappedRequestAsync(endpoint, body, headers);
    
    internal async Task<RestResponse<T>> WrappedRequestAuthAsync<T>(string endpoint, string body = "{}")
        => await WrappedRequestAsync<T>(endpoint, body, [new ("Authorization", $"Bearer {this.AuthToken}")]);
    
    internal async Task<RestResponse> WrappedRequestAuthAsync(string endpoint, string body = "{}")
        => await WrappedRequestAsync(endpoint, body, [new ("Authorization", $"Bearer {this.AuthToken}")]);
    
    internal async Task<RestResponse<T>> WrappedRequestAsync<T>(string endpoint, string body = "{}", List<KeyValuePair<string, string>>? headers = null)
    {
        RestRequest request = new RestRequest{ Resource = endpoint }.AddJsonBody(body);
        
        if (headers != null) request.AddHeaders(headers);
        
        return await RestClient.ExecutePostAsync<T>(request);
    }

    internal async Task<RestResponse> WrappedRequestAsync(string endpoint, string body = "{}", List<KeyValuePair<string, string>>? headers = null)
    {
        RestRequest request = new RestRequest{ Resource = endpoint }.AddJsonBody(body);

        if (headers != null) request.AddHeaders(headers);
        
        return await RestClient.ExecutePostAsync(request);
    }
    
    public void Dispose() => Dispose(true);
    
    internal virtual void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            if (disposing)
            {
                RestClient?.Dispose();
                _stateLock?.Dispose();
            }
            _isDisposed = true;
        }
    }
}