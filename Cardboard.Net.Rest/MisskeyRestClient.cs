using Cardboard.Rest;
using Cardboard.Rest.Drives;

namespace Cardboard.Net.Rest;

public class MisskeyRestClient : BaseMisskeyClient
{
    public new RestSelfUser CurrentUser { get => base.CurrentUser as RestSelfUser; internal set => base.CurrentUser = value; }
    
    public MisskeyRestClient() : this(new MisskeyConfig()) { }
    
    public MisskeyRestClient(MisskeyConfig config) : base(config, CreateApiClient(config))
    {
        
    }

    internal MisskeyRestClient(MisskeyConfig config, MisskeyRestApiClient client) : base(config, client) { }

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
    
    public async Task UploadFileAsync(Uri url, string? folderId = null, string? comment = null, string? marker = null,
        bool? isSensitive = false, bool force = false)
        => await ApiClient.UploadFileUriAsync(url, folderId, comment, marker, isSensitive, force);
    
    public async Task<RestDriveFile> GetFileAsync(string fileId)
        => await ClientHelper.GetDriveFileAsync(this, fileId);

    public async Task<RestDriveFile> GetFileAsync(Uri url)
        => await ClientHelper.GetDriveFileAsync(this, url);
}