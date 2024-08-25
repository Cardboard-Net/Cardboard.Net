using Cardboard.Net.Entities;
using Cardboard.Net.Entities.Users;
using Cardboard.Net.Rest;

namespace Cardboard.Net.Clients;

public abstract class BaseMisskeyClient : IDisposable
{
    protected internal MisskeyApiClient ApiClient { get; internal init; }
    
    public Account? CurrentUser { get; internal set; }
    public HomeInstance? CurrentInstance { get; internal set; }
    
    internal BaseMisskeyClient() { }

    public virtual async Task InitializeAsync()
    {
        this.CurrentUser ??= await this.ApiClient.GetCurrentUserAsync();
        this.CurrentInstance ??= new HomeInstance() { Misskey = this };
        await this.CurrentInstance.RefreshMetaAsync();
        await this.CurrentInstance.RefreshStatsAsync();
    }
    
    /// <summary>
    /// Disposes this client.
    /// </summary>
    public abstract void Dispose();
}
