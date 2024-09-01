using Cardboard.Net.Rest.API;
using Cardboard.Relays;

namespace Cardboard.Rest.Relays;

public class RestRelay : RestEntity<string>, IRelay
{
    /// <inheritdoc/>
    public Uri? Inbox { get; private set; }
    
    /// <inheritdoc/>
    public RelayStatusType Status { get; private set; }
    
    public RestRelay(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    internal static RestRelay Create(BaseMisskeyClient misskey, Relay model)
    {
        RestRelay entity = new(misskey, model.Id);
        entity.Update(model);
        return entity;
    }
    
    internal void Update(Relay model)
    {
        Inbox = model.Inbox;
        Status = model.Status;
    }

    public async Task DeleteAsync()
        => await Misskey.ApiClient.DeleteRelayAsync(Inbox!);
}