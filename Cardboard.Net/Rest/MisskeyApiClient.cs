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
        RestResponse<User> response = await SendRequestAsync<User>(Endpoints.USERS_SHOW,
            JsonSerializer.Serialize(new {userId = userId}));
        response.Data!.Misskey = _misskey;
        return response.Data!;
    }
    
    internal async ValueTask<User> GetUserAsync(string username, string? host = null)
    {
        RestResponse<User> response = await SendRequestAsync<User>(Endpoints.USERS_SHOW,
            JsonSerializer.Serialize(new {username = username, host = host}));
        response.Data!.Misskey = _misskey;
        return response.Data!;
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
        string body = JsonSerializer.Serialize(new 
        {
            text = text, 
            cw = contentWarning, 
            visibility = visibility,
            localOnly = isLocal,
            reactionAcceptance = acceptance
        }, _jopts);
        
        RestResponse<CreatedNote> response = await SendRequestAsync<CreatedNote>(Endpoints.NOTE_CREATE, body);
        
        Note responseNote = response.Data!.Note;
        responseNote.Misskey = this._misskey;
        
        return responseNote;
    }
    
    internal async ValueTask<Note> GetNoteAsync(string noteId)
    {
        RestResponse<Note> response = await SendRequestAsync<Note>(Endpoints.NOTE_SHOW, JsonSerializer.Serialize(new {noteId = noteId }));
        response.Data!.Misskey = this._misskey;
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
        response.Data!.Misskey = _misskey;
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
        response.Data!.Misskey = _misskey;
        return response.Data!;
    }

    internal async Task<DriveFolder> GetDriveFolderAsync(string folderId)
    {
        RestResponse<DriveFolder> response = await SendRequestAsync<DriveFolder>(Endpoints.DRIVE_FOLDER_SHOW,
            JsonSerializer.Serialize(new { folderId = folderId }));
        response.Data!.Misskey = _misskey;
        return response.Data!;
    }

    internal async ValueTask<DriveFolder> CreateDriveFolderAsync(string name, string? parentId = null)
    {
        RestResponse<DriveFolder> response = await SendRequestAsync<DriveFolder>(Endpoints.DRIVE_FOLDER_CREATE,
            JsonSerializer.Serialize(new { name = name, parentId = parentId }));
        response.Data!.Misskey = _misskey;
        return response.Data!;
    }
    
    internal async ValueTask<DriveFolder> FindDriveFolderAsync(string name, string? parentId = null)
    {
        RestResponse<DriveFolder> response = await SendRequestAsync<DriveFolder>(Endpoints.DRIVE_FOLDER_FIND, 
            JsonSerializer.Serialize(new { name = name, parentId = parentId }));
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
        RestResponse<Stats> response = await SendRequestAsync<Stats>(Endpoints.INSTANCE_STATS);
        return response.Data!;
    }
    
    #endregion
    
    internal async Task<RestResponse<T>> SendRequestAsync<T>(string endpoint, string body = "{}")
    {
        RestRequest request = new RestRequest();
        request.Resource = endpoint;
        request.AddJsonBody(body);
        return await _client.ExecutePostAsync<T>(request);
    }

    internal async Task<RestResponse> SendRequestAsync(string endpoint, string body = "{}")
    {
        RestRequest request = new RestRequest();
        request.Resource = endpoint;
        request.AddJsonBody(body);
        return await _client.ExecutePostAsync(request);
    }
    
    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}
