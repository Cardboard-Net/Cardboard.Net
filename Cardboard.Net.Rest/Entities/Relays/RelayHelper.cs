using System.Collections.Immutable;
using Cardboard.Net.Rest.API;

namespace Cardboard.Rest.Relays;

internal static class RelayHelper
{
    public static async Task<ImmutableArray<RestRelay>> GetRelaysAsync(BaseMisskeyClient client)
    {
        Relay[]? models = await client.ApiClient.GetRelaysAsync();

        if (models == null || models.Length == 0)
            return ImmutableArray<RestRelay>.Empty;

        var _models = ImmutableArray.CreateBuilder<RestRelay>(models.Length);
        
        foreach (var m in models)
            _models.Add(RestRelay.Create(client, m));

        return _models.ToImmutable();
    }
}