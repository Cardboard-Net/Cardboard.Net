using System.Text.Json;
using System.Text.Json.Serialization;
using Cardboard.Net.Entities;
using Cardboard.Net.Entities.Notes;
using Cardboard.Net.Rest.Entities;
using Cardboard.Net.Rest.Interceptors;
using RestSharp;
using RestSharp.Serializers.Json;

namespace Cardboard.Net.Rest;

public class MisskeyClient : IMisskeyClient, IDisposable
{
    readonly RestClient _client;
    readonly JsonSerializerOptions _jopts;

    public MisskeyClient(string token, Uri host)
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

    public async Task<User> GetUserAsync(string userId)
    {
        RestRequest request = new RestRequest();
        request.AddJsonBody(JsonSerializer.Serialize(new {userId = userId}));
        request.Resource = Endpoints.USERS_SHOW;
        User? response = await _client.PostAsync<User>(request); 
        return response!;
    }

    public async Task<User> GetUserAsync(string username, string? host = null)
    {
        RestRequest request = new RestRequest();
        request.AddJsonBody(JsonSerializer.Serialize(new {username = username, host = host}));
        request.Resource = Endpoints.USERS_SHOW;
        User? response = await _client.PostAsync<User>(request); 
        return response!;    
    }

    public async Task<int> GetOnlineUserCountAsync()
    {
        UserCount? response = await _client.GetAsync<UserCount>(Endpoints.INSTANCE_USERS_ONLINE);
        return response!.Count;
    }

    public async Task DeleteNoteAsync(string noteId)
    {
        RestRequest request = new RestRequest();
        request.AddBody(JsonSerializer.Serialize(new {noteId = noteId }));
        request.Resource = Endpoints.NOTE_DELETE;
        await _client.PostAsync(request);
    }

    public async Task<Note> CreateNoteAsync
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

    public async Task<Note> GetNoteAsync(string noteId)
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

    public Task<User> FollowUserAsync(string userId, bool withReplies = false)
    {
        throw new NotImplementedException();
    }

    public Task<User> UnfollowUserAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }

    public Task ReportUserAsync(string userId, string comment)
    {
        throw new NotImplementedException();
    }

    public async Task ReportUserAsync(User user, string comment) 
        => await ReportUserAsync(user.Id, comment);

    public async Task<Stats> GetStatsAsync()
    {
        RestRequest request = new RestRequest() 
        {
            Interceptors = [new RawJsonInterceptor()]
        };
        request.Resource = Endpoints.INSTANCE_STATS;

        Stats? response = await _client.PostAsync<Stats>(request);
        return response!;
    }
}
