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
}