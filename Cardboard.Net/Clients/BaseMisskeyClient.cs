using Cardboard.Net.Entities;
using Cardboard.Net.Rest;

namespace Cardboard.Net.Clients;

public abstract class BaseMisskeyClient : IDisposable
{
    protected internal MisskeyApiClient ApiClient { get; internal init; }
    
    internal BaseMisskeyClient(string token, Uri host)
    {
        this.ApiClient = new MisskeyApiClient(token, host);
    }
    
    /// <summary>
    /// Disposes this client.
    /// </summary>
    public abstract void Dispose();
}
