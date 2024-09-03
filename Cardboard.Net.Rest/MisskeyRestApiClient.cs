using System.Net;
using Cardboard.Drives;
using Cardboard.Net.Rest.API;
using Cardboard.Notes;
using Cardboard.Rest.Drives;
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
    
    internal string AuthToken { get; private set; }
    internal RestClient RestClient { get; private set; }

    internal SelfUser FirstLoginUser { get; private set; }
    
    public string UserAgent { get; }
    
    public MisskeyRestApiClient(string userAgent, JsonSerializerSettings? serializerSettings = null)
    {
        UserAgent = userAgent;
        _serializerSettings = serializerSettings ?? new JsonSerializerSettings();
        _stateLock = new SemaphoreSlim(1, 1);
    }

    internal void SetBaseUrl(Uri baseUrl)
    {
        RestClient?.Dispose();
        RestClientOptions clientOptions = new RestClientOptions(baseUrl);
        clientOptions.UserAgent = UserAgent;
        this.RestClient = new RestClient(clientOptions, configureSerialization: s => s.UseNewtonsoftJson(_serializerSettings));
        this.RestClient.AddDefaultHeader("Authorization", $"Bearer {AuthToken}");
    }
    
    public async Task LoginAsync(string token, Uri baseUrl)
    {
        await _stateLock.WaitAsync().ConfigureAwait(false);
        try
        {
            AuthToken = token;
            SetBaseUrl(baseUrl);
            
            RestRequest request = new RestRequest();
            request.Resource = "/api/i";
            request.AddJsonBody("{}");
            RestResponse<SelfUser> response = await RestClient.ExecutePostAsync<SelfUser>(request);

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new InvalidOperationException("token is invalid");
            }

            FirstLoginUser = response.Data!;
        }
        finally { _stateLock.Release(); }
    }
    
    #region Announcements

    public async Task<UserAnnouncement?> GetAnnouncementAsync(string id)
        => await SendRequestAsync<UserAnnouncement>("/api/announcements/show",
            JsonConvert.SerializeObject(new { announcementId = id }));

    public async Task<UserAnnouncement[]?> GetAnnouncementsAsync(GetAnnouncementsParam args)
        => await SendRequestAsync<UserAnnouncement[]>("/api/announcements",
            JsonConvert.SerializeObject(args,
                new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
    
    public async Task ReadAnnouncementAsync(string id)
        => await SendRequestAsync("/api/i/read-announcement", JsonConvert.SerializeObject(new { announcementId = id }));

    public async Task<AdminAnnouncement> CreateAnnouncementAsync(CreateAnnouncementParams args)
    {
        RestRequest request = new RestRequest
        {
            Resource = "/api/admin/announcements/create"
        };
        request.AddJsonBody(JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        RestResponse<AdminAnnouncement> response = await RestClient.ExecutePostAsync<AdminAnnouncement>(request);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("error creating announcement");
        }
        return response.Data!;
    }
    
    public async Task<bool> ModifyAnnouncementAsync(ModifyAnnouncementParams args)
    {
        RestResponse response =
            await SendWrappedRequestAsync("/api/admin/announcements/update", JsonConvert.SerializeObject(args, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore}));
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidOperationException("unable to update announcement");
        }

        return true;
    }

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

    public async Task<Meta?> GetMetaAsync()
        => await SendRequestAsync<Meta>("/api/meta");
    
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
    
    public async Task<SelfUser> GetSelfUserAsync()
    {
        return await SendRequestAsync<SelfUser>("/api/i");
    }

    public async Task<User?> GetUserAsync(string id)
    {
        return await SendRequestAsync<User>($"/api/users/show", JsonConvert.SerializeObject(new { userId = id}));
    }
    
    public async Task<User?> GetUserAsync(string username, Uri? host)
    {
        return await SendRequestAsync<User>($"/api/users/show", JsonConvert.SerializeObject(new { username = username, host = host?.Host}));
    }

    public async Task<User[]?> GetUsersAsync(string[] userIds)
        => await SendRequestAsync<User[]>("/api/users/show", JsonConvert.SerializeObject(new { userIds = userIds }));
    
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


    #endregion
    
    internal async Task<T?> SendRequestAsync<T>(string endpoint, string body = "{}")
    {
        RestRequest request = new RestRequest();
        request.Resource = endpoint;
        request.AddJsonBody(body);
        return await RestClient.PostAsync<T>(request);
    }
    
    internal async Task SendRequestAsync(string endpoint, string body = "{}")
    {
        RestRequest request = new RestRequest();
        request.Resource = endpoint;
        request.AddJsonBody(body);
        await RestClient.PostAsync(request);
    }
    
    internal async Task<RestResponse<T>> SendWrappedRequestAsync<T>(string endpoint, string body = "{}")
    {
        RestRequest request = new RestRequest();
        request.Resource = endpoint;
        request.AddJsonBody(body);
        return await RestClient.ExecutePostAsync<T>(request);
    }

    internal async Task<RestResponse> SendWrappedRequestAsync(string endpoint, string body = "{}")
    {
        RestRequest request = new RestRequest();
        request.Resource = endpoint;
        request.AddJsonBody(body);
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