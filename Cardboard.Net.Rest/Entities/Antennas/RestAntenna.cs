using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using Cardboard.Antennas;
using Cardboard.Lists;
using Cardboard.Notes;
using Cardboard.Rest.Lists;
using Cardboard.Rest.Notes;
using Cardboard.Users;

using Model = Cardboard.Net.Rest.API.Antenna;

namespace Cardboard.Rest.Antennas;

public class RestAntenna : RestEntity<string>, IAntenna, IUpdateable
{
    private ImmutableArray<string> keywords;
    private ImmutableArray<string> excludeKeywords;
    private ImmutableArray<string> userIdList;
    private string? userListId;
    
    /// <inheritdoc/>
    public DateTime CreatedAt { get; private set; }
    
    /// <inheritdoc/>
    public string Name { get; private set; }

    /// <inheritdoc/>
    public IReadOnlyList<string> Keywords => keywords;

    /// <inheritdoc/>
    public IReadOnlyList<string> ExcludeKeywords => excludeKeywords;
    
    /// <inheritdoc/>
    public AntennaSourceType Source { get; private set; }
    
    /// <inheritdoc/>
    public bool CaseSensitive { get; private set; }
    
    /// <inheritdoc/>
    public bool LocalOnly { get; private set; }
    
    /// <inheritdoc/>
    public bool ExcludeBots { get; private set; }
    
    /// <inheritdoc/>
    public bool WithReplies { get; private set; }
    
    /// <inheritdoc/>
    public bool WithFile { get; private set; }
    
    /// <inheritdoc/>
    public bool IsActive { get; private set; }
    
    /// <inheritdoc/>
    public bool HasUnreadNote { get; private set; }
    
    /// <inheritdoc/>
    public bool Notify { get; private set; }
    
    public RestAntenna(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    internal static RestAntenna Create(BaseMisskeyClient misskey, Model model)
    {
        RestAntenna entity = new(misskey, model.Id);
        entity.Update(model);
        return entity;
    }

    internal void Update(Model model)
    {
        this.CreatedAt = model.CreatedAt;
        this.Name = model.Name;
        this.keywords = (model.Keywords.Length != 0)
            ? ImmutableArray.Create<string>(model.Keywords.Where(x => x != "").ToArray())
            : ImmutableArray<string>.Empty;
        this.excludeKeywords = (model.ExcludeKeywords.Length != 0)
            ? ImmutableArray.Create<string>(model.ExcludeKeywords.Where(x => x != "").ToArray())
            : ImmutableArray<string>.Empty;
        this.userIdList = (model.Users.Length != 0)
            ? ImmutableArray.Create<string>(model.Users.Where(x => x != "").ToArray())
            : ImmutableArray<string>.Empty;
        this.Source = model.Source;
        this.CaseSensitive = model.CaseSensitive;
        this.LocalOnly = model.LocalOnly;
        this.ExcludeBots = model.ExcludeBots;
        this.WithReplies = model.WithReplies;
        this.IsActive = model.IsActive;
        this.HasUnreadNote = model.HasUnreadNote;
        this.Notify = model.Notify;
        this.userListId = model.UserListId;
    }
    
    public async Task UpdateAsync()
    {
        var model = await Misskey.ApiClient.GetAntennaAsync(Id);

        if (model == null)
            return;
        
        Update(model);
    }
    
    public async Task ModifyAsync(Action<AntennaProperties> args)
    {
        var model = await AntennaHelper.ModifyAntennaAsync(this, Misskey, args);

        if (model == null)
            return;
        
        Update(model);
    }

    public async Task DeleteAsync()
        => await Misskey.ApiClient.DeleteAntennaAsync(Id);

    public async Task<IReadOnlyList<RestNote>> GetNotesAsync
    (
        int? limit = null,
        string? sinceId = null,
        string? untilId = null,
        DateTime? sinceDate = null,
        DateTime? untilDate = null
    )
        => await AntennaHelper.GetNotesAsync(Misskey, Id, limit, sinceId, untilId, sinceDate, untilDate);

    public async Task<RestList?> GetListAsync()
        => userListId != null ? await ListHelper.GetListAsync(Misskey, this.Id).ConfigureAwait(false) : null;

    public async Task<IReadOnlyList<RestUser>> GetUsersAsync()
    {
        if (userIdList.IsEmpty)
            return ImmutableArray<RestUser>.Empty;
        
        return await UserHelper.GetUsersAsync(Misskey, userIdList.ToArray());
    }

    async Task<IList?> IAntenna.GetListAsync()
        => await this.GetListAsync().ConfigureAwait(false);
    
    async Task<IReadOnlyList<IUser>> IAntenna.GetUsersAsync() 
        => await this.GetUsersAsync().ConfigureAwait(false);
}