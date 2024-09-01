using System.Collections.Immutable;
using Cardboard.Announcements;
using Cardboard.Net.Rest.API;
using Cardboard.Rest.Notes;

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

    public static async Task<RestAdminAnnouncement> CreateAnnouncementAsync
    (
        BaseMisskeyClient client,
        string title,
        string text,
        Uri? imageUrl = null,
        IconType? icon = null,
        DisplayType? display = null,
        bool? forExistingUsers = null,
        bool? silence = null,
        bool? readConfirmation = null,
        string? userId = null
    )
    {
        CreateAnnouncementParams announcement = new CreateAnnouncementParams()
        {
            Title = title,
            Text = text,
            ImageUrl = imageUrl,
            Icon = icon,
            Display = display,
            ForExistingUsers = forExistingUsers,
            Silence = silence,
            ReadConfirmation = readConfirmation,
            UserId = userId
        };

        var model = await client.ApiClient.CreateAnnouncementAsync(announcement);

        return RestAdminAnnouncement.Create(client, model);
    }
    
    public static async Task<bool> ModifyAdminAnnouncementAsync(IAdminAnnouncement announcement,
        BaseMisskeyClient client, AnnouncementProperties args)
        => await ModifyAdminAnnouncementAsync(announcement.Id, client, args);
    
    public static async Task<bool> ModifyAdminAnnouncementAsync(string announcementId, BaseMisskeyClient client, AnnouncementProperties args)
    {
        ModifyAnnouncementParams modifyAnnouncementParams = new ModifyAnnouncementParams()
        {
            Id = announcementId,
            Display = args.Display,
            ForExistingUsers = args.ForExistingUsers,
            Icon = args.Icon,
            ImageUrl = args.ImageUrl,
            IsActive = args.IsActive,
            ReadConfirmation = args.ReadConfirmation,
            Title = args.Title,
            Text = args.Text
        };

        return await client.ApiClient.ModifyAnnouncementAsync(modifyAnnouncementParams);
    }
}