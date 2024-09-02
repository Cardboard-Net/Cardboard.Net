using Model = Cardboard.Net.Rest.API.User;

namespace Cardboard.Rest;

public class RestInstanceActor : RestUser
{
    public RestInstanceActor(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    internal static RestInstanceActor Create(BaseMisskeyClient misskey, Model model)
    {
        RestInstanceActor entity = new RestInstanceActor(misskey, model.Id);
        entity.Update(model);
        return entity;
    }
    
    public override Task AcceptFollowRequestAsync()
        => throw new InvalidOperationException("You cannot accept a follow request from the instance actor");

    public override Task RejectFollowRequestAsync()
        => throw new InvalidOperationException("You cannot reject a follow request from the instance actor");

    public override Task CancelFollowRequestAsync()
        => throw new InvalidOperationException("You cannot cancel a follow request to the instance actor");

    public override Task SilenceAsync()
        => throw new InvalidOperationException("You cannot silence the instance actor");
}