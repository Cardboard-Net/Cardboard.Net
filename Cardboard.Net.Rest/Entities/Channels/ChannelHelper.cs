using Cardboard.Channels;

namespace Cardboard.Rest.Channels;

internal static class ChannelHelper
{
    
    public static async Task<RestChannel> ModifyChannelAsync(
        string channelId,
        BaseMisskeyClient client,
        Action<ChannelProperties> modifications
        ) {
            // API: channels/update
            ChannelProperties args = new();
            modifications(args);

            ModifyChannelParams builtChannel = new() {
                ChannelId = channelId,
                Name = args.Name,
                Description = args.Description,
                BannerId = args.BannerId,
                IsArchived = args.IsArchived,
                Color = args.Color,
                PinnedNoteIds = args.PinnedNoteIds,
                IsSensitive = args.IsSensitive,
                AllowRenoteToExternal = args.AllowRenoteToExternal
            };
            var channel = await client.ApiClient.ModifyChannelAsync(builtChannel);
            return RestChannel.Create(client, channel);
        }

    public static async Task<RestChannel> CreateChannelAsync(
        BaseMisskeyClient client,
        string name,
        string? description,
        string? bannerId,
        string? color,
        bool? isSensitive,
        bool? allowRenoteToExternal
        ) {
            // API: channels/create
            CreateChannelParams ChannelBuilder = new()
            {
                Name = name,
                Description = description,
                BannerId = bannerId,
                Color = color,
                IsSensitive = isSensitive,
                AllowRenoteToExternal = allowRenoteToExternal
            };

            var channel = await client.ApiClient.CreateChannelAsync(ChannelBuilder).ConfigureAwait(false);
            return RestChannel.Create(client, channel);

        }



    /*
        Tasks mommy wants kyla to write:
        - 
    */
}