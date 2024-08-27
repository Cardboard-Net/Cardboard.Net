using System.Net;
using Cardboard.Net.Rest.API;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Cardboard;

internal class MisskeyRestApiClient : IDisposable
{
    protected readonly JsonSerializerSettings _serializerSettings;
    protected readonly SemaphoreSlim _stateLock;
    
    protected bool _isDisposed;
    
    internal string AuthToken { get; private set; }
    internal RestClient RestClient { get; private set; }

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
            RestResponse response = await RestClient.ExecutePostAsync(request);

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new InvalidOperationException("token is invalid");
            }
        }
        finally { _stateLock.Release(); }
    }
    
    #region Users
    
    public async Task<SelfUser> GetSelfUserAsync()
    {
        return await SendRequestAsync<SelfUser>("/api/i");
    }

    public async Task<User?> GetUserAsync(string id)
    {
        return await SendRequestAsync<User>($"/api/users/show", JsonConvert.SerializeObject(new { userId = id}));
    }
    
    public async Task ReportUserAsync(string id, string comment)
        => await SendRequestAsync("/api/users/report-abuse", JsonConvert.SerializeObject(new { userId = id, comment = comment}));
    
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