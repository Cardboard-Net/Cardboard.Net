using System.Collections.Immutable;
using Cardboard.Net.Rest.API;

namespace Cardboard.Rest;

internal static class UserHelper
{
    public static async Task<IReadOnlyList<RestUser>> GetUsersAsync(BaseMisskeyClient client, string[] userIds)
    {
        User[]? models = await client.ApiClient.GetUsersAsync(userIds).ConfigureAwait(false);
        
        if (models == null || models.Length == 0)
            return ImmutableArray<RestUser>.Empty;

        var _models = ImmutableArray.CreateBuilder<RestUser>(models.Length);
        
        foreach (var m in models)
            _models.Add(RestUser.Create(client, m));

        return _models.ToImmutable();
    }

    public static async Task<RestUserRelation?> GetRelationAsync(BaseMisskeyClient client, string userId)
    {
        UserRelation? model = await client.ApiClient.GetUserRelation(userId);

        return model != null ? RestUserRelation.Create(client, model) : null;
    }
}