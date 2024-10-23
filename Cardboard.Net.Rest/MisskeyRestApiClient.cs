using System.Diagnostics.CodeAnalysis;
using System.Net;
using Cardboard.Errors;
using Cardboard.Net.Rest.API;
using Cardboard.Net.Rest.Interceptors;
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
        this.Logger = logger;
        this.UserAgent = options.Value.UserAgent;
        this.RequestInterceptor = requestInterceptor;
        this._serializerSettings = options.Value.SerializerSettings;
        this._stateLock = new SemaphoreSlim(1, 1);
    }

    internal void SetBaseUrl(Uri baseUrl)
    {
        this.RestClient?.Dispose();
        RestClientOptions clientOptions = new RestClientOptions(baseUrl)
        {
            UserAgent = this.UserAgent,
            Interceptors = [this.RequestInterceptor]
        };
        this.RestClient = new RestClient(clientOptions, configureSerialization: s => s.UseNewtonsoftJson(this._serializerSettings));
    }
    
    public async Task LoginAsync(string token, Uri baseUrl)
    {
        await this._stateLock.WaitAsync().ConfigureAwait(false);
        try
        {
            this.AuthToken = token;
            SetBaseUrl(baseUrl);

            RestResponse<SelfUser> response = await WrappedRequestAuthAsync<SelfUser>("/api/i");
            
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    this.FirstLoginUser = response.Data!;
                    this.Logger.LogInformation("Authentication Success!");
                    break;
                case HttpStatusCode.Forbidden:
                    throw new InvalidOperationException("Token is invalid");
                default:
                    throw new InvalidOperationException("Server responded with an unknown error");
            }
        }
        finally { this._stateLock.Release(); }
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
        => await this.RequestAsync<UserAnnouncement>("/api/announcements/show",
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
        => await this.RequestAsync<UserAnnouncement[]>("/api/announcements",
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
        => await this.RequestAuthAsync("/api/i/read-announcement", JsonConvert.SerializeObject(new { announcementId = id }));

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
        RestResponse<AdminAnnouncement> response = await this.WrappedRequestAuthAsync<AdminAnnouncement>
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
        RestResponse response = await this.WrappedRequestAuthAsync("/api/admin/announcements/update", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        
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
        RestResponse response = await WrappedRequestAuthAsync("/api/announcements/delete", JsonConvert.SerializeObject(new { id = id }));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to delete announcement");
        }
    }
    
    #endregion
    
    #region Antennas

    public async Task<Antenna?> GetAntennaAsync(string id)
        => await RequestAuthAsync<Antenna>("/api/antennas/show", JsonConvert.SerializeObject(new { antennaId = id }));
    
    public async Task<Note[]?> GetAntennaNotesAsync(GetAntennaNotesParams args)
    {
        RestResponse<Note[]> response = await WrappedRequestAuthAsync<Note[]>("/api/antennas/notes", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        return response.Data;
    }
    
    public async Task<Antenna?> CreateAntennaAsync(CreateAntennaParams args)
    {
        RestResponse<Antenna> response = await WrappedRequestAuthAsync<Antenna>("/api/antennas/create",
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
        RestResponse<Antenna> response = await WrappedRequestAuthAsync<Antenna>("/api/antennas/update", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("error modifying the antenna");
        }
        
        return response.Data;
    }
    
    public async Task DeleteAntennaAsync(string id)
    {
        RestResponse response = await WrappedRequestAuthAsync("/api/antennas/delete", JsonConvert.SerializeObject(new { antennaId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to delete antenna");
        }
    }
    
    #endregion
    
    #region Clips

    public async Task<Clip?> GetClipAsync(string id)
        => await RequestAuthAsync<Clip>("/api/clips/show", JsonConvert.SerializeObject(new { clipId = id }));

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
        RestResponse response = await WrappedRequestAuthAsync("/api/clips/favorite", JsonConvert.SerializeObject(new { clipId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to favorite clip");
        }
    }
    
    public async Task UnfavoriteClipAsync(string id)
    {
        RestResponse response = await WrappedRequestAuthAsync("/api/clips/unfavorite", JsonConvert.SerializeObject(new { clipId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to unfavorite clip");
        }
    }

    public async Task<Note[]?> GetClipNotesAsync(GetClipNotesParams args)
        => await RequestAuthAsync<Note[]>("/api/clips/notes", JsonConvert.SerializeObject(args, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));

    public async Task<Clip?> ModifyClipAsync(ModifyClipParams args)
    {
        RestResponse<Clip> response = await WrappedRequestAuthAsync<Clip>("/api/clips/update", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("error modifying the clip");
        }
        
        return response.Data;
    }
    
    public async Task DeleteClipAsync(string id)
    {
        RestResponse response = await WrappedRequestAuthAsync("/api/clips/delete", JsonConvert.SerializeObject(new { clipId = id }));
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
        RestResponse<Channel> response = await WrappedRequestAuthAsync<Channel>("/api/channels/update", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("Something went wrong while updating the channel.");
        }
        
        return response.Data!;
    }

    public async Task ArchiveChannelAsync(
        string ChannelId
    ) {
        await RequestAuthAsync("/api/channels/update", JsonConvert.SerializeObject(new {channelId = ChannelId, isArchived = true}));
    }

    #endregion

    #region Charts

    public async Task<ActiveUserChart> GetActiveUserChartAsync(GetChartParams args)
    {
        ActiveUserChart? chart = await RequestAuthAsync<ActiveUserChart>("/api/charts/active-users", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        return chart!;
    }
    
    public async Task<ApRequestChart> GetApRequestChartAsync(GetChartParams args)
    {
        ApRequestChart? chart = await RequestAuthAsync<ApRequestChart>("/api/charts/ap-request", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        return chart!;
    }
    
    public async Task<DriveChart> GetDriveChartAsync(GetChartParams args)
    {
        DriveChart? chart = await RequestAuthAsync<DriveChart>("/api/charts/drive", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        return chart!;
    }
    
    public async Task<FederationChart> GetFederationChartAsyncc(GetChartParams args)
    {
        FederationChart? chart = await RequestAuthAsync<FederationChart>("/api/charts/federation", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        return chart!;
    }
    
    public async Task<InstanceUserChart> GetUsersChartAsync(GetChartParams args)
    {
        InstanceUserChart? chart = await RequestAuthAsync<InstanceUserChart>("/api/charts/users", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        return chart!;
    }
    
    #endregion
    
    #region Notes

    public async Task<Note?> GetNoteAsync(string id)
        => await RequestAuthAsync<Note>("/api/notes/show", JsonConvert.SerializeObject(new { noteId = id }));

    public async Task<Note[]?> GetRenotesAsync(GetRenotesParam args)
    {
        RestResponse<Note[]> response = await WrappedRequestAuthAsync<Note[]>("/api/notes/renotes", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        return response.Data;
    }
    
    public async Task<Note[]?> GetRepliesAsync(GetRepliesParam args)
    {
        RestResponse<Note[]> response = await WrappedRequestAuthAsync<Note[]>("/api/notes/replies", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        return response.Data;
    }

    public async Task<Clip[]?> GetClipsAsync()
    {
        RestResponse<Clip[]> response = await WrappedRequestAuthAsync<Clip[]>("/api//clips/list");
        return response.Data;
    }
    
    public async Task<Clip[]?> GetClipsAsync(string id)
    {
        RestResponse<Clip[]> response =
            await WrappedRequestAuthAsync<Clip[]>("/api/notes/clips", JsonConvert.SerializeObject(new { noteId = id }));
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
        RestResponse response = await WrappedRequestAuthAsync("/api/notes/thread-muting-create", JsonConvert.SerializeObject(new {noteId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to mute note");
        }
    }
    
    public async Task UnmuteNoteAsync(string id)
    {
        RestResponse response = await WrappedRequestAuthAsync("/api/notes/thread-muting-delete", JsonConvert.SerializeObject(new {noteId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to unmute note");
        }
    }
    
    public async Task FavoriteNoteAsync(string id)
    {
        RestResponse response = await WrappedRequestAuthAsync("/api/notes/favorites/create", JsonConvert.SerializeObject(new {noteId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to favorite note");
        }
    }
    
    public async Task UnfavoriteNoteAsync(string id)
    {
        RestResponse response = await WrappedRequestAuthAsync("/api/notes/favorites/delete", JsonConvert.SerializeObject(new {noteId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to unfavorite note");
        }
    }
    
    public async Task<Note?> ModifyNoteAsync(ModifyNoteParams args)
    {
        RestResponse<CreatedNote> response = await WrappedRequestAuthAsync<CreatedNote>("/api/notes/edit", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("error modifying the note");
        }
        
        return response.Data?.Note;
    }
    
    public async Task DeleteNoteAsync(string id)
    {
        RestResponse response = await WrappedRequestAuthAsync("/api/notes/delete", JsonConvert.SerializeObject(new {noteId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to delete note");
        }
    }
    
    #endregion
    
    #region Drive

    public async Task<DriveFile> GetFileAsync(string id)
        => await RequestAuthAsync<DriveFile>("/api/drive/files/show", JsonConvert.SerializeObject(new {fileId = id}));
    
    public async Task<DriveFile> GetFileAsync(Uri url)
        => await RequestAuthAsync<DriveFile>("/api/drive/files/show", JsonConvert.SerializeObject(new {url = url.ToString()}));

    public async Task<DriveFolder> GetFolderAsync(string id)
        => await RequestAuthAsync<DriveFolder>("/api/drive/folders/show", JsonConvert.SerializeObject(new {folderId = id}));
    
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
        RestResponse<DriveFile> response = await WrappedRequestAuthAsync<DriveFile>("/api/drive/files/update", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("error modifying the file");
        }
        
        return response.Data!;
    }

    public async Task<DriveFolder> ModifyDriveFolderAsync(string folderId, ModifyFolderParams args)
    {
        RestResponse<DriveFolder> response = await WrappedRequestAuthAsync<DriveFolder>("/api/drive/folder/update", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("error modifying the folder");
        }
        
        return response.Data!;
    }
    
    public async Task DeleteFileAsync(string id)
    {
        RestResponse response = await WrappedRequestAuthAsync("/api/drive/files/delete", JsonConvert.SerializeObject(new {fileId = id}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to delete file");
        }
    }
    
    public async Task DeleteFolderAsync(string id)
    {
        RestResponse response = await WrappedRequestAuthAsync("/api/drive/folders/delete", JsonConvert.SerializeObject(new {folderId = id}));
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
        RestResponse<AdminMeta> response = await WrappedRequestAuthAsync<AdminMeta>("/api/admin/meta");
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("you do not have permission to get admin meta");
        }
        
        return response.Data;
    }
    
    public async Task<FederatedInstance?> GetFederatedInstanceAsync(string host)
        => await RequestAuthAsync<FederatedInstance>("/api/federation/show-instance", JsonConvert.SerializeObject(new { host = host }));

    public async Task<FederatedInstance[]?> GetFederatedInstancesAsync(GetFederatedInstancesParams args)
        => await RequestAuthAsync<FederatedInstance[]>("/api/federation/instances", JsonConvert.SerializeObject(args, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
    
    public async Task<FederatedInstanceRelation[]?> GetFederatedInstanceFollowingAsync(
        GetFederatedInstanceRelationParams args)
        => await RequestAuthAsync<FederatedInstanceRelation[]>("/api/federation/following", JsonConvert.SerializeObject(args, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
    
    public async Task<FederatedInstanceRelation[]?> GetFederatedInstanceFollowersAsync(
        GetFederatedInstanceRelationParams args)
        => await RequestAuthAsync<FederatedInstanceRelation[]>("/api/federation/followers", JsonConvert.SerializeObject(args, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));

    public async Task<User[]?> GetFederatedInstanceUsersAsync(GetFederatedInstanceUsersParams args)
        => await RequestAuthAsync<User[]>("/api/federation/users",
            JsonConvert.SerializeObject(args,
                new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
    
    public async Task RefreshFederatedInstanceAsync(string host)
    {
        RestResponse response = await WrappedRequestAuthAsync("/api/admin/federation/refresh-remote-instance-metadata", JsonConvert.SerializeObject(new {host = host}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("you do not have permission to refresh instance metadata");
        }
    }
    
    public async Task DeleteFederatedInstanceFilesAsync(string host)
    {
        RestResponse response = await WrappedRequestAuthAsync("/api/admin/federation/delete-all-files", JsonConvert.SerializeObject(new {host = host}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("you do not have permission to delete all remote instance's files cached locally");
        }
    }
    
    public async Task RemoveFederatedInstanceFollowingAsync(string host)
    {
        RestResponse response = await WrappedRequestAuthAsync("/api/admin/federation/remove-all-following", JsonConvert.SerializeObject(new {host = host}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("you do not have permission to destroy remote instance's relation");
        }
    }
    
    public async Task<bool> ModifyFederatedInstanceAsync(ModifyFederatedInstanceParams args)
    {
        RestResponse response = await WrappedRequestAuthAsync("/api/admin/federation/update-instance", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to update instance");
        }

        return true;
    }
    
    public async Task<bool> ModifyMetaAsync(ModifyMetaParams args)
    {
        RestResponse response = await WrappedRequestAuthAsync("/api/admin/update-meta", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to update instance meta");
        }

        return true;
    }

    public async Task<Ping?> PingAsync()
        => await RequestAsync<Ping>("/api/ping");
    
    public async Task<OnlineUsersCount?> GetOnlineUsersAsync()
        => await RequestAsync<OnlineUsersCount>("/api/get-online-users-count");
    
    #endregion
    
    #region Lists

    public async Task<Cardboard.Net.Rest.API.List?> GetListAsync(string id, bool forPublic = false)
        => await RequestAuthAsync<Cardboard.Net.Rest.API.List>("/api/antennas/show", JsonConvert.SerializeObject(new { listId = id, forPublic = forPublic }));
    
    #endregion
    
    #region Relays
    
    public async Task<Relay[]?> GetRelaysAsync()
    {
        RestResponse<Relay[]> response = await WrappedRequestAuthAsync<Relay[]>("/api/admin/relays/list");
        
        if (response.StatusCode == HttpStatusCode.Forbidden)
            throw new InvalidOperationException("you do not have permission to view relays");
        
        return response.Data;
    }

    public async Task<Relay> CreateRelayAsync(Uri inbox)
    {
        RestResponse<Relay> response = await WrappedRequestAuthAsync<Relay>("/api/admin/relays/add", JsonConvert.SerializeObject(new { inbox = inbox }));
        
        if (response.StatusCode != HttpStatusCode.OK)
            throw new InvalidOperationException("unable to add relay");

        return response.Data!;
    }
    
    /// <summary>
    ///     Deletes a relay given a Uri encoded string
    /// </summary>
    /// <remarks>
    ///     api-doc#tag/admin/operation/admin___relays___remove
    ///
    ///     Requires auth and scope write:admin:relays
    /// </remarks>
    /// <param name="inbox">The inbox uri of the relay to delete</param>
    /// <exception cref="InvalidOperationException">An exception is thrown when the relay is unable to be deleted</exception>
    public async Task DeleteRelayAsync(Uri inbox)
    {
        RestResponse response = await WrappedRequestAuthAsync("/api/admin/relays/remove", JsonConvert.SerializeObject(new { inbox = inbox }));
        
        if (response.StatusCode != HttpStatusCode.NoContent)
            throw new InvalidOperationException("unable to delete relay");
    }
    
    #endregion
    
    #region Roles

    /// <summary>
    ///     Fetches a role given the role id
    /// </summary>
    /// <remarks>
    ///     api-doc#tag/role/operation/roles___show
    ///
    ///     Does not require auth
    /// </remarks>
    /// <param name="id">The id of the role to fetch</param>
    /// <returns>An instance of Role</returns>
    public async Task<Role?> GetRoleAsync(string id)
        => await RequestAsync<Role>("/api/roles/show", JsonConvert.SerializeObject(new { roleId = id}));
    
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
    ///     api-doc#tag/users/operation/users___relation
    ///
    ///     Requires auth and scope read:account
    /// </remarks>
    /// <param name="userId">The id of the user to fetch the relation for</param>
    /// <returns>an instance of UserRelation</returns>
    public async Task<UserRelation?> GetUserRelation(string userId)
        => await RequestAuthAsync<UserRelation>("/api/users/relation",
            JsonConvert.SerializeObject(new { userId = userId }));
    
    /// <summary>
    ///     Gets an array of Note objects
    /// </summary>
    /// <remarks>
    ///     api-doc#tag/users/operation/users___notes
    ///
    ///     Does not require auth
    /// </remarks>
    /// <param name="args"></param>
    /// <returns></returns>
    public async Task<Note[]?> GetNotesAsync(GetUserNotesParams args)
        => await RequestAsync<Note[]>("/api/users/notes", JsonConvert.SerializeObject(args, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
    
    /// <summary>
    ///     Reports a user
    /// </summary>
    /// <remarks>
    ///     api-doc#tag/users/operation/users___report-abuse
    ///
    ///     Requires auth and scope write:report-abuse
    /// </remarks>
    /// <param name="id">The id corresponding to the user to report</param>
    /// <param name="comment">The report comment</param>
    public async Task ReportUserAsync(string id, string comment)
        => await RequestAuthAsync("/api/users/report-abuse", JsonConvert.SerializeObject(new { userId = id, comment = comment}));
    
    #region Following
    
    /*
     * Need to implement the following endpoints:
     * TODO: api-doc#tag/following/operation/following___create
     * TODO: api-doc#tag/following/operation/following___delete
     * TODO: api-doc#tag/following/operation/following___update
     * TODO: api-doc#tag/following/operation/following___update-all
     * TODO: api-doc#tag/following/operation/following___invalidate
     * TODO: api-doc#tag/following/operation/following___requests___list
     */
    
    /// <summary>
    ///     Accepts an incoming follow request
    /// </summary>
    /// <remarks>
    ///     api-doc#tag/following/operation/following___requests___accept
    ///
    ///     Requires auth and scope write:following
    /// </remarks>
    /// <param name="id">The id corresponding to the user who sent the request</param>
    public async Task AcceptFollowRequestAsync(string id)
        => await RequestAuthAsync("/api/following/requests/accept", JsonConvert.SerializeObject(new { userId = id }));
    
    /// <summary>
    ///     Rejects an incoming follow request
    /// </summary>
    /// <remarks>
    ///     api-doc#tag/following/operation/following___requests___reject
    ///
    ///     Requires auth and scope write:following
    /// </remarks>
    /// <param name="id"></param>
    public async Task RejectFollowRequestAsync(string id)
        => await RequestAuthAsync("/api/following/requests/reject", JsonConvert.SerializeObject(new { userId = id }));

    /// <summary>
    ///     Cancels an outgoing follow request
    /// </summary>
    /// <remarks>
    ///     api-doc#tag/following/operation/following___requests___cancel
    ///
    ///     Requires auth and scope write:following
    /// </remarks>
    /// <param name="id"></param>
    public async Task CancelFollowRequestAsync(string id)
        => await RequestAuthAsync("/api/following/requests/cancel", JsonConvert.SerializeObject(new { userId = id }));
    
    #endregion
    
    #region Moderation
    
    /// <summary>
    ///     Silences a user
    /// </summary>
    /// <remarks>
    ///     api-doc#tag/admin/operation/admin___silence-user
    ///
    ///     Requires auth and scope write:admin:silence-user
    /// </remarks>
    /// <param name="id">The id of the user to silence</param>
    public async Task SilenceUserAsync(string id)
        => await this.RequestAuthAsync("/api/admin/silence-user", JsonConvert.SerializeObject(new { userId = id}));
    
    /// <summary>
    ///     
    /// </summary>
    /// <param name="id"></param>
    public async Task DeleteAllFilesOfUserAsync(string id)
        => await this.RequestAuthAsync("/api/admin/admin/delete-all-files-of-a-user", JsonConvert.SerializeObject(new { userId = id}));

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="id"></param>
    public async Task UnsetUserAvatarAsync(string id)
        => await this.RequestAuthAsync("/api/admin/unset-user-avatar", JsonConvert.SerializeObject(new {userId = id}));

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="id"></param>
    public async Task UnsetUserBannerAsync(string id)
        => await this.RequestAuthAsync("/api/admin/unset-user-banner", JsonConvert.SerializeObject(new {userId = id}));

    #endregion
    
    #endregion

    /// <summary>
    ///     Sends a post request with Authorization headers given an endpoint, a body
    /// </summary>
    /// <param name="endpoint">A string containing the api endpoint to invoke this request on</param>
    /// <param name="body">The request body</param>
    /// <returns>an instance of type T</returns>
    internal async Task<T?> RequestAuthAsync<T>(string endpoint, string body = "{}")
        => await RequestAsync<T>(endpoint, body, [new ("Authorization", $"Bearer {this.AuthToken}")]);
    
    /// <summary>
    ///     Sends a post request with Authorization headers given an endpoint, a body
    /// </summary>
    /// <param name="endpoint">A string containing the api endpoint to invoke this request on</param>
    /// <param name="body">The request body</param>
    /// <returns></returns>
    internal async Task RequestAuthAsync(string endpoint, string body = "{}")
        => await RequestAsync(endpoint, body, [new ("Authorization", $"Bearer {this.AuthToken}")]);
    
    /// <summary>
    ///     Sends a post request given an endpoint, a body, and optional headers
    /// </summary>
    /// <param name="endpoint">A string containing the api endpoint to invoke this request on</param>
    /// <param name="body">The request body</param>
    /// <param name="headers">An optional List of KeyValuePairs</param>
    /// <typeparam name="T">A type to deserialize the json response into</typeparam>
    /// <returns>an instance of type T</returns>
    internal async Task<T?> RequestAsync<T>(string endpoint, string body = "{}", List<KeyValuePair<string, string>>? headers = null)
    {
        RestResponse<T> response = await WrappedRequestAsync<T>(endpoint, body, headers);
        return response.Data;
    }
    
    /// <summary>
    ///     Sends a post request given an endpoint, a body, and optional headers
    /// </summary>
    /// <param name="endpoint">A string containing the api endpoint to invoke this request on</param>
    /// <param name="body">The request body</param>
    /// <param name="headers">An optional List of KeyValuePairs</param>
    /// <returns></returns>
    internal async Task RequestAsync(string endpoint, string body = "{}", List<KeyValuePair<string, string>>? headers = null)
        => await WrappedRequestAsync(endpoint, body, headers);
    
    /// <summary>
    ///     Sends a post request with Authorization headers given an endpoint, a body
    /// </summary>
    /// <param name="endpoint">A string containing the api endpoint to invoke this request on</param>
    /// <param name="body">The request body</param>
    /// <typeparam name="T">A type to deserialize the json response into</typeparam>
    /// <returns>an instance of RestResponse with the result deserialized into type T</returns>
    internal async Task<RestResponse<T>> WrappedRequestAuthAsync<T>(string endpoint, string body = "{}")
        => await WrappedRequestAsync<T>(endpoint, body, [new ("Authorization", $"Bearer {this.AuthToken}")]);
    
    /// <summary>
    ///     Sends a post request with Authorization headers given an endpoint, a body
    /// </summary>
    /// <param name="endpoint">A string containing the api endpoint to invoke this request on</param>
    /// <param name="body">The request body</param>
    /// <returns>an instance of RestResponse containing the result of the POST request</returns>
    internal async Task<RestResponse> WrappedRequestAuthAsync(string endpoint, string body = "{}")
        => await WrappedRequestAsync(endpoint, body, [new ("Authorization", $"Bearer {this.AuthToken}")]);
    
    /// <summary>
    ///     Sends a post request given an endpoint, a body, and optional headers
    /// </summary>
    /// <param name="endpoint">A string containing the api endpoint to invoke this request on</param>
    /// <param name="body">The request body</param>
    /// <param name="headers">An optional List of KeyValuePairs</param>
    /// <typeparam name="T">A type to deserialize the json response into</typeparam>
    /// <returns>an instance of RestResponse with the result deserialized into type T</returns>
    internal async Task<RestResponse<T>> WrappedRequestAsync<T>(string endpoint, string body = "{}", List<KeyValuePair<string, string>>? headers = null)
    {
        RestRequest request = new RestRequest{ Resource = endpoint }.AddJsonBody(body);
        
        if (headers != null) request.AddHeaders(headers);
        
        return await RestClient.ExecutePostAsync<T>(request);
    }

    /// <summary>
    ///     Sends a post request given an endpoint, a body, and optional headers
    /// </summary>
    /// <param name="endpoint">A string containing the api endpoint to invoke this request on</param>
    /// <param name="body">The request body</param>
    /// <param name="headers">An optional List of KeyValuePairs</param>
    /// <returns>an instance of RestResponse containing the result of the POST request</returns>
    internal async Task<RestResponse> WrappedRequestAsync(string endpoint, string body = "{}", List<KeyValuePair<string, string>>? headers = null)
    {
        RestRequest request = new RestRequest{ Resource = endpoint }.AddJsonBody(body);

        if (headers != null) request.AddHeaders(headers);
        
        return await RestClient.ExecutePostAsync(request);
    }

    [Experimental("ExpRequestAsync")]
    internal async Task<(T?, IMisskeyError?)> ExpRequestAsync<T>(string endpoint, string body = "{}", List<KeyValuePair<string, string>>? headers = null)
    {
        RestRequest request = new RestRequest{ Resource = endpoint }.AddJsonBody(body);
        
        if (headers != null) request.AddHeaders(headers);

        RestResponse response = await RestClient.PostAsync(request);

        switch (response.StatusCode)
        {
            case HttpStatusCode.GatewayTimeout:
            case HttpStatusCode.BadGateway:
            case HttpStatusCode.NoContent:
                return (default, null);
            case HttpStatusCode.OK:
                return (JsonConvert.DeserializeObject<T>(response.Content!, _serializerSettings), null);
            default:
                break;
        }
        
        Error? err = JsonConvert.DeserializeObject<Error>(response.Content!, _serializerSettings);
                
        /*
         * Ideally, we would replace this with reflection. I'd like to include
         * attributes in the mix. This is a terrible way of doing this.
         */
        IMisskeyError? t = err switch
        {
            not null when err.Body.Id == "c3d38592-54c0-429d-be96-5636b0431a61" => new NotAdministratorError(),
            _ => null
        };

        return (default, t);
    }
    
    public void Dispose() => Dispose(true);
    
    internal virtual void Dispose(bool disposing)
    {
        if (_isDisposed) return;
        
        if (disposing)
        {
            this.RestClient?.Dispose();
            this._stateLock?.Dispose();
        }
        
        this._isDisposed = true;
    }
}