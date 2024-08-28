using Cardboard.Net.Rest;

namespace Cardboard.Net.Websocket;

public class MisskeySocketRestClient : MisskeyRestClient
{
    internal MisskeySocketRestClient(MisskeyConfig config, MisskeyRestApiClient client) : base(config, client) { }

    public new Task LoginAsync(string token, Uri baseUrl)
        => throw new NotSupportedException("The Socket REST wrapper cannot be used to log in or out.");
    internal override Task LoginInternalAsync(string token, Uri baseUrl)
        => throw new NotSupportedException("The Socket REST wrapper cannot be used to log in or out.");
    public new Task LogoutAsync()
        => throw new NotSupportedException("The Socket REST wrapper cannot be used to log in or out.");
    internal Task LogoutInternalAsync()
        => throw new NotSupportedException("The Socket REST wrapper cannot be used to log in or out.");
}