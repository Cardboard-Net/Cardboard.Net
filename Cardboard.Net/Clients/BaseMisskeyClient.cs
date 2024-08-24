using Cardboard.Net.Entities;
using Cardboard.Net.Entities.Users;
using Cardboard.Net.Rest;

namespace Cardboard.Net.Clients;

public abstract class BaseMisskeyClient : IDisposable
{
    protected internal MisskeyApiClient ApiClient { get; internal init; }
    
    public Account CurrentUser { get; internal set; }
    
    internal BaseMisskeyClient() { }

    public virtual async Task InitializeAsync()
    {
        if (this.CurrentUser is null)
        {
            this.CurrentUser = await this.ApiClient.GetCurrentUserAsync();
        }
    }
    
    /// <summary>
    /// Disposes this client.
    /// </summary>
    public abstract void Dispose();
}
