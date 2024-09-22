using Cardboard.Instances;
using Cardboard.Users;
using Microsoft.Extensions.Logging;

namespace Cardboard;

public abstract class BaseMisskeyClient : IMisskeyClient
{
    internal MisskeyRestApiClient ApiClient { get; init; }
    private readonly SemaphoreSlim _stateLock;
    private bool _IsDisposed;

    public ILogger Logger { get; internal init; }
    
    public ISelfUser CurrentUser { get; protected set; }
    public ISelfInstance CurrentInstance { get; protected set; }
    
    internal BaseMisskeyClient(MisskeyConfig config)
    {
        _stateLock = new SemaphoreSlim(1, 1);
    }

    public async Task LoginAsync(string token, Uri baseUrl)
    {
        await _stateLock.WaitAsync().ConfigureAwait(false);
        try
        {
            await LoginInternalAsync(token, baseUrl).ConfigureAwait(false);
        }
        finally { _stateLock.Release(); }
    }
    
    internal virtual async Task LoginInternalAsync(string token, Uri baseUrl)
    {
        await ApiClient.LoginAsync(token, baseUrl).ConfigureAwait(false);
        await OnLoginAsync(token, baseUrl).ConfigureAwait(false);
    }
    
    internal virtual Task OnLoginAsync(string token, Uri baseUrl)
        => Task.Delay(0);
    
    internal virtual void Dispose(bool disposing)
    {
        if (!_IsDisposed)
        {
            _stateLock?.Dispose();
            _IsDisposed = true;
        }
    }
    
    public void Dispose() => Dispose(true);
    
    Task IMisskeyClient.StartAsync()
        => Task.Delay(0);
    
    Task IMisskeyClient.StopAsync()
        => Task.Delay(0);
}