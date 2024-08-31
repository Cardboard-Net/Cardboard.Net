using System.Collections.Immutable;
using Cardboard.Net.Rest.API;

namespace Cardboard.Rest.Announcements;

internal static class AnnouncementHelper
{
    public static async Task<RestUserAnnouncement?> GetAnnouncementAsync(BaseMisskeyClient client, string id)
    {
        var model = await client.ApiClient.GetAnnouncementAsync(id).ConfigureAwait(false);
        
        return model != null ? RestUserAnnouncement.Create(client, model) : null;
    }

    public static async Task<ImmutableArray<RestUserAnnouncement>> GetAnnouncementsAsync
    (
        BaseMisskeyClient client,
        int? limit = null,
        string? sinceId = null,
        string? untilId = null,
        bool? isActive = null
    )
    {
        GetAnnouncementsParam arg = new GetAnnouncementsParam()
        {
            Limit = limit,
            SinceId = sinceId,
            UntilId = untilId,
            IsActive = isActive
        };

        var models = await client.ApiClient.GetAnnouncementsAsync(arg).ConfigureAwait(false);

        if (models == null || models.Length == 0)
            return ImmutableArray<RestUserAnnouncement>.Empty;

        var announcements = ImmutableArray.CreateBuilder<RestUserAnnouncement>(models.Length);
        
        foreach (var m in models)
            announcements.Add(RestUserAnnouncement.Create(client, m));

        return announcements.ToImmutable();
    }
}