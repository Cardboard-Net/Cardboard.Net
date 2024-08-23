using System.Text.Json;
using System.Text.Json.Serialization;
using Cardboard.Net.Clients;
using Cardboard.Net.Entities;
using Cardboard.Net.Entities.Drives;
using Cardboard.Net.Entities.Notes;
using Cardboard.Net.Entities.Users;
using Cardboard.Net.Rest.Interceptors;
using RestSharp;
using RestSharp.Serializers.Json;
using DriveFile = Cardboard.Net.Entities.Drives.DriveFile;

namespace Cardboard.Net.Rest;

public class MisskeyApiClient : IDisposable
{
    readonly RestClient _client;
    readonly JsonSerializerOptions _jopts;
    readonly BaseMisskeyClient _misskey;
    
    public MisskeyApiClient(string token, Uri host, BaseMisskeyClient client)
    {
        RestClientOptions options = new RestClientOptions(host);
        options.UserAgent = "cardboard.NET/v0.0.1a";
        options.Interceptors = [new StatusInterceptor(), new RawJsonInterceptor()];
        _jopts = new JsonSerializerOptions();
        _jopts.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

        _client = new RestClient
        (
            options,
            configureSerialization: s => s.UseSystemTextJson(_jopts)
        );

        _client.AddDefaultHeader("Authorization", $"Bearer {token}");
        
        _misskey = client;
    }
    
    #region Users

    internal async ValueTask<User> GetUserAsync(string userId)
    {
        RestRequest request = new RestRequest();
        request.AddJsonBody(JsonSerializer.Serialize(new {userId = userId}));
        request.Resource = Endpoints.USERS_SHOW;
        RestResponse<User> response = await _client.ExecutePostAsync<User>(request);
        response.Data!.Misskey = _misskey;
        return response.Data!;
    }
    
    internal async ValueTask<User> GetUserAsync(string username, string? host = null)
    {
        RestRequest request = new RestRequest();
        request.AddJsonBody(JsonSerializer.Serialize(new {username = username, host = host}));
        request.Resource = Endpoints.USERS_SHOW;
        RestResponse<User> response = await _client.ExecutePostAsync<User>(request);
        response.Data!.Misskey = _misskey;
        return response.Data!;
    }

    internal async ValueTask FollowUserAsync(string userId, bool withReplies = false)
    {
        RestRequest request = new RestRequest();
        request.AddJsonBody(JsonSerializer.Serialize(new { userId = userId, withReplies = withReplies }));
        request.Resource = Endpoints.FOLLOW_CREATE;
        await this._client.ExecutePostAsync<User>(request);
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
        RestRequest request = new RestRequest();

        request.AddJsonBody(JsonSerializer.Serialize(new 
        {
            text = text, 
            cw = contentWarning, 
            visibility = visibility,
            localOnly = isLocal,
            reactionAcceptance = acceptance
        }, _jopts));
        
        request.Resource = Endpoints.NOTE_CREATE;

        RestResponse<CreatedNote> response = await _client.ExecutePostAsync<CreatedNote>(request);
        
        Note responseNote = response.Data!.Note;
        responseNote.Misskey = this._misskey;
        
        return responseNote;
    }
    
    internal async ValueTask<Note> GetNoteAsync(string noteId)
    {
        RestRequest request = new RestRequest();
        request.AddBody(JsonSerializer.Serialize(new {noteId = noteId }));
        request.Resource = Endpoints.NOTE_SHOW;
        RestResponse<Note> response = await _client.ExecutePostAsync<Note>(request);
        response.Data!.Misskey = this._misskey;
        return response.Data!;
    }
    
    internal async ValueTask DeleteNoteAsync(string noteId)
    {
        RestRequest request = new RestRequest();
        request.AddBody(JsonSerializer.Serialize(new {noteId = noteId }));
        request.Resource = Endpoints.NOTE_DELETE;
        await _client.ExecutePostAsync(request);
    }
    
    internal async ValueTask CreateReactAsync(string noteId, string reaction)
    {
        RestRequest request = new RestRequest();
        request.AddBody(JsonSerializer.Serialize(new {noteId = noteId, reaction = reaction }));
        request.Resource = Endpoints.NOTE_REACTS_CREATE;
        await _client.ExecutePostAsync(request);
    }

    internal async ValueTask DeleteReactAsync(string noteId)
    {
        RestRequest request = new RestRequest();
        request.AddBody(JsonSerializer.Serialize(new {noteId = noteId }));
        request.Resource = Endpoints.NOTE_REACTS_DELETE;
        await _client.ExecutePostAsync(request);
    }
    
    #endregion
    
    #region Emoji

    internal async ValueTask<Emoji> GetEmojiAsync(string name)
    {
        RestRequest request = new RestRequest();
        request.AddJsonBody(JsonSerializer.Serialize(new {name = name}));
        request.Resource = Endpoints.EMOJI;
        
        /*
         * For some reason, despite api-doc showing this as "GET /api/emoji" it
         * seems as though the server only wants me to send it a post request.
         */
        RestResponse<Emoji> response = await _client.ExecutePostAsync<Emoji>(request);
        response.Data!.Misskey = _misskey;
        return response.Data!;
    }
    
    #endregion
    
    #region Drive
    
    internal async ValueTask<DriveUsage> GetDriveUsageAsync()
    {
        RestRequest request = new RestRequest();
        /*
         * For some reason misskey gets pissy if I do not provide a body
         * contradicting api-docs. I have figured out sending an empty json
         * payload makes the server happy again.
         */
        request.AddJsonBody(JsonSerializer.Serialize(new { }));
        request.Resource = Endpoints.DRIVE;
        RestResponse<DriveUsage> response = await _client.ExecutePostAsync<DriveUsage>(request);
        return response.Data!;
    }

    internal async ValueTask<DriveFile> GetDriveFileAsync(string input, ShowType type)
    {
        RestRequest request = new RestRequest();
        
        switch (type)
        {
            case ShowType.FileId:
                request.AddJsonBody(JsonSerializer.Serialize(new {fileId = input}));
                break;
            case ShowType.FileUrl:
                request.AddJsonBody(JsonSerializer.Serialize(new { url = input }));
                break;
        }

        request.Resource = Endpoints.DRIVE_FILE_SHOW;
        RestResponse<DriveFile> response = await _client.ExecutePostAsync<DriveFile>(request);
        response.Data!.Misskey = _misskey;
        return response.Data!;
    }

    internal async ValueTask<DriveFolder> GetDriveFolderAsync(string folderId)
    {
        RestRequest request = new RestRequest();
        request.AddJsonBody(JsonSerializer.Serialize(new { folderId = folderId }));
        request.Resource = Endpoints.DRIVE_FOLDER_SHOW;
        RestResponse<DriveFolder> response = await _client.ExecutePostAsync<DriveFolder>(request);
        response.Data!.Misskey = _misskey;
        return response.Data!;
    }

    internal async ValueTask<DriveFolder> CreateDriveFolderAsync(string name, string? parentId = null)
    {
        RestRequest request = new RestRequest();
        request.AddJsonBody(JsonSerializer.Serialize(new { name = name, parentId = parentId }));
        request.Resource = Endpoints.DRIVE_FOLDER_CREATE;
        RestResponse<DriveFolder> response = await _client.ExecutePostAsync<DriveFolder>(request);
        response.Data!.Misskey = _misskey;
        return response.Data!;
    }

    internal async ValueTask DeleteDriveFolderAsync(string folderId)
    {
        RestRequest request = new RestRequest();
        request.AddJsonBody(JsonSerializer.Serialize(new { folderId = folderId }));
        request.Resource = Endpoints.DRIVE_FOLDER_DELETE;
        RestResponse response = await _client.ExecutePostAsync(request);
    }

    internal async ValueTask<DriveFolder> FindDriveFolderAsync(string name, string? parentId = null)
    {
        RestRequest request = new RestRequest();
        request.AddJsonBody(JsonSerializer.Serialize(new {name = name, parentId = parentId}));
        request.Resource = Endpoints.DRIVE_FOLDER_FIND;
        RestResponse<DriveFolder> response = await _client.ExecutePostAsync<DriveFolder>(request);
        response.Data!.Misskey = _misskey;
        return response.Data!; 
    }
    
    #endregion
    
    #region CurrentInstance
    internal async ValueTask<int> GetOnlineUserCountAsync()
    {
        RestResponse<UserCount> response = await _client.ExecuteGetAsync<UserCount>(Endpoints.INSTANCE_USERS_ONLINE);
        return response.Data!.Count;
    }
    
    internal async ValueTask<Stats> GetStatsAsync()
    {
        RestRequest request = new RestRequest();
        request.Resource = Endpoints.INSTANCE_STATS;
        RestResponse<Stats> response = await _client.ExecutePostAsync<Stats>(request);
        return response.Data!;
    }
    
    #endregion

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}
