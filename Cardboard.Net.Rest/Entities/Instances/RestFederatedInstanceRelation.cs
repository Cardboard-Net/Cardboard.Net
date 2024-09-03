using Cardboard.Instances;
using Cardboard.Users;

using Model = Cardboard.Net.Rest.API.FederatedInstanceRelation;

namespace Cardboard.Rest.Instances;

public class RestFederatedInstanceRelation : RestEntity<string>, IFederatedInstanceRelation
{
    /// <inheritdoc/>
    public DateTime CreatedAt { get; private set; }
    
    /// <summary>
    ///     Followee as a rest user
    /// </summary>
    public RestUser Followee { get; private set; }
    
    /// <summary>
    ///     Follower as a rest user
    /// </summary>
    public RestUser Follower { get; private set; }
    
    public RestFederatedInstanceRelation(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    internal static RestFederatedInstanceRelation Create(BaseMisskeyClient client, Model model)
    {
        RestFederatedInstanceRelation entity = new(client, model.Id);
        entity.Update(model);
        return entity;
    }

    internal void Update(Model model)
    {
        this.CreatedAt = model.CreatedAt;
        this.Followee = RestUser.Create(Misskey, model.Followee);
        this.Follower = RestUser.Create(Misskey, model.Follower);
    }
    
    IUser IFederatedInstanceRelation.Followee => Followee;
    IUser IFederatedInstanceRelation.Follower => Follower;
}