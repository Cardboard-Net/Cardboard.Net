using System.Collections.Immutable;
using Cardboard.Lists;
using Cardboard.Users;

using Model = Cardboard.Net.Rest.API.List;

namespace Cardboard.Rest.Lists;

public class RestList : RestEntity<string>, IList, IUpdateable
{
    private ImmutableArray<string> userIds;
    
    ///<inheritdoc/>
    public DateTime CreatedAt { get; private set; }
    
    ///<inheritdoc/>
    public string Name { get; private set; }
    
    ///<inheritdoc/>
    public bool IsPublic { get; private set; }
    
    public RestList(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    internal static RestList Create(BaseMisskeyClient client, Model model)
    {
        RestList entity = new RestList(client, model.Id);
        entity.Update(model);
        return entity;
    }

    internal void Update(Model model)
    {
        this.CreatedAt = model.CreatedAt;
        this.Name = model.Name;
        this.IsPublic = model.IsPublic;
        this.userIds = (model.UserIds == null || model.UserIds.Length == 0)
            ? ImmutableArray<string>.Empty
            : ImmutableArray.Create<string>(model.UserIds);
    }
    
    public async Task UpdateAsync()
    {
        var model = await Misskey.ApiClient.GetListAsync(Id).ConfigureAwait(false);
        
        if (model == null)
            return;
        
        Update(model);
    }
    
    public Task DeleteAsync()
    {
        throw new NotImplementedException();
    }
    
    public Task AddUserAsync(IUser user)
    {
        throw new NotImplementedException();
    }

    public Task RemoveUserAsync(IUser user)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<IUser>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }
}