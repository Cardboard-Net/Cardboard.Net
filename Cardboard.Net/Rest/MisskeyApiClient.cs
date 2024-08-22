using System.Text.Json;
using System.Text.Json.Serialization;
using Cardboard.Net.Entities;
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

    public MisskeyApiClient(string token, Uri host)
    {
        RestClientOptions options = new RestClientOptions(host);
        options.UserAgent = "cardboard.NET/v0.0.1a";

        _jopts = new JsonSerializerOptions();
        _jopts.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

        _client = new RestClient
        (
            options,
            configureSerialization: s => s.UseSystemTextJson(_jopts)
        );

        _client.AddDefaultHeader("Authorization", $"Bearer {token}");
    }
    
    #region Users

    internal async ValueTask<User> GetUserAsync(string userId)
    {
        RestRequest request = new RestRequest();
        request.AddJsonBody(JsonSerializer.Serialize(new {userId = userId}));
        request.Resource = Endpoints.USERS_SHOW;
        User? response = await this._client.PostAsync<User>(request); 
        return response!;
    }
    
    internal async ValueTask<User> GetUserAsync(string username, string? host = null)
    {
        RestRequest request = new RestRequest();
        request.AddJsonBody(JsonSerializer.Serialize(new {username = username, host = host}));
        request.Resource = Endpoints.USERS_SHOW;
        User? response = await _client.PostAsync<User>(request); 
        return response!;    
    }

    internal async ValueTask FollowUserAsync(string userId, bool withReplies = false)
    {
        RestRequest request = new RestRequest();
        request.AddJsonBody(JsonSerializer.Serialize(new { userId = userId, withReplies = withReplies }));
        request.Resource = Endpoints.FOLLOW_CREATE;
        await this._client.PostAsync<User>(request);
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

        CreatedNote? response = await _client.PostAsync<CreatedNote>(request);
        
        return response!.Note;
    }
    
    internal async ValueTask<Note> GetNoteAsync(string noteId)
    {
        RestRequest request = new RestRequest() 
        {
            Interceptors = [new RawJsonInterceptor()]
        };
        request.AddBody(JsonSerializer.Serialize(new {noteId = noteId }));
        request.Resource = Endpoints.NOTE_SHOW;
        Note? response = await _client.PostAsync<Note>(request);
        return response!;
    }
    
    internal async ValueTask DeleteNoteAsync(string noteId)
    {
        RestRequest request = new RestRequest();
        request.AddBody(JsonSerializer.Serialize(new {noteId = noteId }));
        request.Resource = Endpoints.NOTE_DELETE;
        await _client.PostAsync(request);
    }
    
    internal async ValueTask CreateReactAsync(string noteId, string reaction)
    {
        RestRequest request = new RestRequest();
        request.AddBody(JsonSerializer.Serialize(new {noteId = noteId, reaction = reaction }));
        request.Resource = Endpoints.NOTE_REACTS_CREATE;
        await _client.PostAsync(request);
    }

    internal async ValueTask DeleteReactAsync(string noteId)
    {
        RestRequest request = new RestRequest();
        request.AddBody(JsonSerializer.Serialize(new {noteId = noteId }));
        request.Resource = Endpoints.NOTE_REACTS_DELETE;
        await _client.PostAsync(request);
    }
    
    #endregion
    
    #region CurrentInstance
    internal async ValueTask<int> GetOnlineUserCountAsync()
    {
        UserCount? response = await _client.GetAsync<UserCount>(Endpoints.INSTANCE_USERS_ONLINE);
        return response!.Count;
    }
    
    internal async ValueTask<Stats> GetStatsAsync()
    {
        RestRequest request = new RestRequest() 
        {
            Interceptors = [new RawJsonInterceptor()]
        };
        request.Resource = Endpoints.INSTANCE_STATS;

        Stats? response = await _client.PostAsync<Stats>(request);
        return response!;
    }
    
    #endregion

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}
