using Cardboard.Instances;
using Cardboard.Net.Rest.API;

namespace Cardboard.Rest.Instances;

public class RestFederatedInstance : RestEntity<string>, IFederatedInstance, IUpdateable
{
    /// <inheritdoc/>
    public DateTime FirstRetrievedAt { get; private set; }
    
    /// <inheritdoc/>
    public Uri Host { get; private set; }
    
    /// <inheritdoc/>
    public int UsersCount { get; private set; }
    
    /// <inheritdoc/>
    public int NotesCount { get; private set; }
    
    /// <inheritdoc/>
    public int FollowingCount { get; private set; }
    
    /// <inheritdoc/>
    public int FollowersCount { get; private set; }
    
    /// <inheritdoc/>
    public bool IsNotResponding { get; private set; }
    
    /// <inheritdoc/>
    public bool IsSuspended { get; private set; }
    
    /// <inheritdoc/>
    public bool IsBlocked { get; private set; }
    
    /// <inheritdoc/>
    public bool IsSilenced { get; private set; }
    
    /// <inheritdoc/>
    public bool IsNSFW { get; private set; }
    
    /// <inheritdoc/>
    public SuspensionStateType SuspensionState { get; private set; }
    
    /// <inheritdoc/>
    public string? SoftwareName { get; private set; }
    
    /// <inheritdoc/>
    public string? SoftwareVersion { get; private set; }
    
    /// <inheritdoc/>
    public bool? OpenRegistrations { get; private set; }
    
    /// <inheritdoc/>
    public string? Name { get; private set; }
    
    /// <inheritdoc/>
    public string? Description { get; private set; }
    
    /// <inheritdoc/>
    public string? MaintainerName { get; private set; }
    
    /// <inheritdoc/>
    public string? MaintainerEmail { get; private set; }
    
    /// <inheritdoc/>
    public Uri? IconUrl { get; private set; }
    
    /// <inheritdoc/>
    public Uri? FaviconUrl { get; private set; }
    
    /// <inheritdoc/>
    public string? ThemeColor { get; private set; }
    
    /// <inheritdoc/>
    public DateTime? LastUpdatedAt { get; private set; }
    
    /// <inheritdoc/>
    public DateTime? LastRequestReceivedAt { get; private set; }
    
    /// <inheritdoc/>
    public string? ModerationNote { get; private set; }
 
    public RestFederatedInstance(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    internal static RestFederatedInstance Create(BaseMisskeyClient client, FederatedInstance model)
    {
        RestFederatedInstance entity = new(client, model.Id);
        entity.Update(model);
        return entity;
    }

    internal void Update(FederatedInstance model)
    {
        FirstRetrievedAt = model.FirstRetrievedAt;
        Host = model.Host;
        UsersCount = model.UsersCount;
        NotesCount = model.NotesCount;
        FollowingCount = model.FollowingCount;
        FollowersCount = model.FollowersCount;
        IsNotResponding = model.IsNotResponding;
        IsSuspended = model.IsSuspended;
        IsBlocked = model.IsBlocked;
        IsSilenced = model.IsSilenced;
        IsNSFW = model.IsNSFW;
        SuspensionState = model.SuspensionState;
        SoftwareName = model.SoftwareName;
        SoftwareVersion = model.SoftwareVersion;
        OpenRegistrations = model.OpenRegistrations;
        Name = model.Name;
        Description = model.Description;
        MaintainerName = model.MaintainerName;
        MaintainerEmail = model.MaintainerEmail;
        IconUrl = model.IconUrl;
        FaviconUrl = model.FaviconUrl;
        ThemeColor = model.ThemeColor;
        LastUpdatedAt = model.LastUpdatedAt;
        LastRequestReceivedAt = model.LastRequestReceivedAt;
        ModerationNote = model.ModerationNote;
    }
    
    public async Task UpdateAsync()
    {
        var model = await Misskey.ApiClient.GetFederatedInstanceAsync(Host.Host);

        if (model == null)
            return;
        
        Update(model);
    }

    public async Task ModifyAsync(Action<FederatedInstanceProperties> func)
    {
        FederatedInstanceProperties args = new FederatedInstanceProperties();
        func(args);

        bool success = await InstanceHelper.ModifyFederatedInstanceAsync(this, Misskey, args);

        if (!success)
            return;

        IsSuspended = args.IsSuspended ?? IsSuspended;
        IsNSFW = args.IsNSFW ?? IsNSFW;
        ModerationNote = args.ModerationNote ?? ModerationNote;
    }

    /// <inheritdoc/>
    public async Task RefreshMetadata()
    {
        await Misskey.ApiClient.RefreshFederatedInstanceAsync(Host.Host);
        await UpdateAsync();
    }

    public async Task<IReadOnlyList<RestFederatedInstanceRelation>> GetFollowingRelationAsync()
        => throw new NotImplementedException();

    public async Task<IReadOnlyList<RestFederatedInstanceRelation>> GetFollowerRelationAsync()
        => throw new NotImplementedException();

    /// <inheritdoc/>
    public async Task SilenceAsync()
        => await (Misskey.CurrentInstance as RestSelfInstance)!.SilenceInstanceAsync(this);

    /// <inheritdoc/>
    public async Task UnsilenceAsync()
        => await (Misskey.CurrentInstance as RestSelfInstance)!.UnsilenceInstanceAsync(this);

    /// <inheritdoc/>
    public async Task SuspendAsync()
    {
        if (IsSuspended)
            throw new InvalidOperationException("Cannot suspend a suspended instance");

        await ModifyAsync(x => x.IsSuspended = true);
    }

    /// <inheritdoc/>
    public async Task UnsuspendAsync()
    {
        if (!IsSuspended)
            throw new InvalidOperationException("Cannot unsuspend an unsuspended instance");

        await ModifyAsync(x => x.IsSuspended = true);
    }

    /// <inheritdoc/>
    public async Task MarkNSFW()
    {
        if (IsNSFW)
            throw new InvalidOperationException("Cannot mark an nsfw instance as nsfw");

        await ModifyAsync(x => x.IsNSFW = true);
    }

    /// <inheritdoc/>
    public async Task UnmarkNSFW()
    {
        if (!IsNSFW)
            throw new InvalidOperationException("Cannot unmark nsfw instance if it is not marked as nsfw");

        await ModifyAsync(x => x.IsNSFW = false);
    }

    /// <inheritdoc/>
    public async Task DeleteAllFiles()
        => await Misskey.ApiClient.DeleteFederatedInstanceFilesAsync(Host.Host);
    
    /// <inheritdoc/>
    public async Task RemoveAllFollowing()
        => await Misskey.ApiClient.RemoveFederatedInstanceFollowingAsync(Host.Host);
} 