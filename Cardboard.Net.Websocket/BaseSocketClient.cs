namespace Cardboard.Net.Websocket;

public abstract partial class BaseSocketClient : BaseMisskeyClient, IMisskeyClient
{
    /// <summary>
    ///     Provides access to a REST-only client with a shared state from this client.
    /// </summary>
    public abstract MisskeySocketRestClient Rest { get; }
    
    internal BaseSocketClient(MisskeyConfig config, MisskeyRestApiClient client) : base(config) { }

    /// <inheritdoc />
    public abstract Task StartAsync();
    /// <inheritdoc />
    public abstract Task StopAsync();
}