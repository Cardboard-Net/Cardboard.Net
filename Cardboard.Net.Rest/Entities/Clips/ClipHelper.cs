using System.Collections.Immutable;
using Cardboard.Clips;
using Cardboard.Net.Rest.API;

namespace Cardboard.Rest.Clips;

internal static class ClipHelper
{
    public static async Task<RestClip?> GetClipAsync(BaseMisskeyClient client, string id)
    {
        var model = await client.ApiClient.GetClipAsync(id).ConfigureAwait(false);
        
        return model != null ? RestClip.Create(client, model) : null;
    }

    public static async Task<ImmutableArray<RestClip>> GetClipsAsync(BaseMisskeyClient client)
    {
        Clip[]? models = await client.ApiClient.GetClipsAsync().ConfigureAwait(false);

        if (models == null || models.Length == 0)
            return ImmutableArray<RestClip>.Empty;

        var _models = ImmutableArray.CreateBuilder<RestClip>(models.Length);

        foreach (var m in models)
            _models.Add(RestClip.Create(client, m));

        return _models.ToImmutable();
    }

    public static async Task<RestClip> CreateClipAsync(BaseMisskeyClient client, string name, bool? isPublic, string? description = null)
    {
        if (name.Length > 100)
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be greater than 100 characters.");

        if (description?.Length > 2048)
            throw new ArgumentOutOfRangeException(nameof(description), "Description cannot be greater than 2048 characters.");
        
        CreateClipParams clip = new CreateClipParams()
        {
            Name = name,
            Description = description,
            IsPublic = isPublic
        };

        var model = await client.ApiClient.CreateClipAsync(clip).ConfigureAwait(false);

        return RestClip.Create(client, model);
    }

    public static async Task<Clip?> ModifyClipAsync(IClip clip, BaseMisskeyClient client, Action<ClipProperties> func)
        => await ModifyClipAsync(clip.Id, clip.Name, client, func);

    public static async Task<Clip?> ModifyClipAsync(string clipId, string clipName, BaseMisskeyClient client,
        Action<ClipProperties> func)
    {
        ClipProperties args = new ClipProperties();
        func(args);

        ModifyClipParams modifyClipParams = new ModifyClipParams()
        {
            Id = clipId,
            Description = args.Description,
            IsPublic = args.IsPublic,
            Name = args.Name ?? clipName
        };

        return await client.ApiClient.ModifyClipAsync(modifyClipParams);
    }
}