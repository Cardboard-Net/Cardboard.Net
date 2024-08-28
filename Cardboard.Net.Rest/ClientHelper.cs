using Cardboard.Rest.Drives;

namespace Cardboard.Rest;

internal static class ClientHelper
{
    public static async Task<RestUser> GetUserAsync(BaseMisskeyClient client, string id)
    {
        var model = await client.ApiClient.GetUserAsync(id).ConfigureAwait(false);
        if (model != null)
            return RestUser.Create(client, model);
        return null;
    }

    public static async Task<RestDriveFile> GetDriveFileAsync(BaseMisskeyClient client, string id)
    {
        var model = await client.ApiClient.GetFileAsync(id).ConfigureAwait(false);
        if (model != null)
            return RestDriveFile.Create(client, model);
        return null;
    }
    
    public static async Task<RestDriveFile> GetDriveFileAsync(BaseMisskeyClient client, Uri url)
    {
        var model = await client.ApiClient.GetFileAsync(url).ConfigureAwait(false);
        if (model != null)
            return RestDriveFile.Create(client, model);
        return null;
    }
}