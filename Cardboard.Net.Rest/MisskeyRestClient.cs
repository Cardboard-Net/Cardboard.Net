using Cardboard.Rest;

namespace Cardboard.Net.Rest;

public class MisskeyRestClient : BaseMisskeyClient
{

    public MisskeyRestClient(MisskeyConfig config) : base(config, CreateApiClient(config))
    {
        
    }

    internal MisskeyRestClient(MisskeyConfig config, MisskeyRestApiClient client) : base(config, client)
    {
        
    }

    internal override async Task OnLoginAsync(string token, Uri baseUrl)
    {
        var user = await ApiClient.GetSelfUserAsync().ConfigureAwait(false);
        Console.WriteLine(user.Name);
    }
    
    private static MisskeyRestApiClient CreateApiClient(MisskeyConfig config)
        => new MisskeyRestApiClient(MisskeyConfig.UserAgent);
    
    public async Task<RestUser> GetUserAsync(string userId)
        => await ClientHelper.GetUserAsync(this, userId);

    public async Task ReportUserAsync(string userId, string comment)
        => await ApiClient.ReportUserAsync(userId, comment);
}