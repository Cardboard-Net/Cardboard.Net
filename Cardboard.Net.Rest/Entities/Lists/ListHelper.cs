namespace Cardboard.Rest.Lists;

internal static class ListHelper
{
    public static async Task<RestList?> GetListAsync(BaseMisskeyClient client, string listId, bool forPublic = false)
    {
        var model = await client.ApiClient.GetListAsync(listId, forPublic).ConfigureAwait(false);

        return model != null ? RestList.Create(client, model) : null;
    }
}