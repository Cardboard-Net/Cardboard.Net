using System.Collections.Immutable;
using Cardboard.Antennas;
using Cardboard.Net.Rest.API;
using Cardboard.Rest.Notes;

namespace Cardboard.Rest.Antennas;

internal static class AntennaHelper
{
    public static async Task<RestAntenna?> GetAntennaAsync(BaseMisskeyClient client, string id)
    {
        var model = await client.ApiClient.GetAntennaAsync(id).ConfigureAwait(false);
        return model != null ? RestAntenna.Create(client, model) : null;
    }
    
    public static async Task<IReadOnlyList<RestNote>> GetNotesAsync
    (
        BaseMisskeyClient client,
        IAntenna antenna,
        int? limit = null,
        string? sinceId = null,
        string? untilId = null,
        DateTime? sinceDate = null,
        DateTime? untilDate = null
    ) => await GetNotesAsync(client, antenna.Id, limit, sinceId, untilId, sinceDate, untilDate);
    
    public static async Task<IReadOnlyList<RestNote>> GetNotesAsync
    (
        BaseMisskeyClient client,
        string antennaId,
        int? limit = null,
        string? sinceId = null,
        string? untilId = null,
        DateTime? sinceDate = null,
        DateTime? untilDate = null
    )
    {
        GetAntennaNotesParams notes = new GetAntennaNotesParams()
        {
            AntennaId = antennaId,
            Limit = limit,
            SinceId = sinceId,
            UntilId = untilId,
            // TODO: Test these, I think that it expects utc unix epoch in milliseconds
            SinceDate = sinceDate.HasValue 
                ? ((DateTimeOffset)sinceDate.Value.ToUniversalTime()).ToUnixTimeMilliseconds() 
                : null,
            UntilDate = untilDate.HasValue 
                ? ((DateTimeOffset)untilDate.Value.ToUniversalTime()).ToUnixTimeMilliseconds() 
                : null,
        };

        Note[]? models = await client.ApiClient.GetAntennaNotesAsync(notes).ConfigureAwait(false);
        
        if (models == null || models.Length == 0)
            return ImmutableArray<RestNote>.Empty;

        var _models = ImmutableArray.CreateBuilder<RestNote>(models.Length);

        foreach (var m in models)
            _models.Add(RestNote.Create(client, m));

        return _models.ToImmutable();
    }

    public static async Task<RestAntenna?> CreateAntennaAsync
    (
        BaseMisskeyClient client,
        string name,
        AntennaSourceType source,
        string[] keywords,
        string[]? userIds = null,
        bool withReplies = false,
        bool withFiles = false,
        string? userListId = null,
        string[]? excludeKeywords = null,
        bool caseSensitive = false,
        bool? localOnly = null,
        bool? excludeBots = null
    )
    {
        CreateAntennaParams antenna = new CreateAntennaParams()
        {
            Name = name,
            Source = source,
            Keywords = keywords,
            UserIds = userIds ?? [""],
            WithReplies = withReplies,
            WithFiles = withFiles,
            UserListId = userListId,
            ExcludeKeywords = excludeKeywords ?? [""],
            CaseSensitive = caseSensitive,
            LocalOnly = localOnly,
            ExcludeBots = excludeBots
        };

        var model = await client.ApiClient.CreateAntennaAsync(antenna).ConfigureAwait(false);

        return model != null ? RestAntenna.Create(client, model) : null;
    }

    public static async Task<Antenna?> ModifyAntennaAsync(IAntenna antenna, BaseMisskeyClient client,
        Action<AntennaProperties> func)
        => await ModifyAntennaAsync(antenna.Id, client, func);
    
    public static async Task<Antenna?> ModifyAntennaAsync(string antennaId, BaseMisskeyClient client,
        Action<AntennaProperties> func)
    {
        AntennaProperties args = new AntennaProperties();
        func(args);

        ModifyAntennaParams modifyAntennaParams = new ModifyAntennaParams()
        {
            Id = antennaId,
            Name = args.Name,
            Source = args.Source,
            UserListId = args.UserListId,
            Keywords = args.Keywords,
            ExcludeKeywords = args.ExcludeKeywords,
            UserIds = args.UserIds,
            CaseSensitive = args.CaseSensitive,
            LocalOnly = args.LocalOnly,
            ExcludeBots = args.ExcludeBots,
            WithReplies = args.WithReplies,
            WithFile = args.WithFile
        };
        
        return await client.ApiClient.ModifyAntennaAsync(modifyAntennaParams).ConfigureAwait(false);
    }
}