using Cardboard.Instances;
using Cardboard.Net.Rest.API;

namespace Cardboard.Rest.Instances;

internal static class InstanceHelper
{
    public static async Task<RestFederatedInstance?> GetFederatedInstanceAsync(BaseMisskeyClient client, string host)
    {
        var model = await client.ApiClient.GetFederatedInstanceAsync(host).ConfigureAwait(false);

        return model != null ? RestFederatedInstance.Create(client, model) : null;
    }
    
    public static async Task<bool> ModifyFederatedInstanceAsync(IFederatedInstance instance,
        BaseMisskeyClient client, FederatedInstanceProperties args)
        => await ModifyFederatedInstanceAsync(instance.Host.Host, client, args);
    
    public static async Task<bool> ModifyFederatedInstanceAsync(string host, BaseMisskeyClient client, FederatedInstanceProperties args)
    {
        ModifyFederatedInstanceParams modifyFederatedInstanceParams = new ModifyFederatedInstanceParams()
        {
            Host = host,
            IsNSFW = args.IsNSFW,
            IsSuspended = args.IsSuspended,
            ModerationNote = args.ModerationNote
        };

        return await client.ApiClient.ModifyFederatedInstanceAsync(modifyFederatedInstanceParams);
    }
}