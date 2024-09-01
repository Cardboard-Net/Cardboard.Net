namespace Cardboard.Rest;

public class RestInstanceActor : RestUser
{
    public RestInstanceActor(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    public override Task AcceptFollowRequestAsync()
        => throw new InvalidOperationException("You cannot accept a follow request from the instance actor");

    public override Task RejectFollowRequestAsync()
        => throw new InvalidOperationException("You cannot reject a follow request from the instance actor");

    public override Task CancelFollowRequestAsync()
        => throw new InvalidOperationException("You cannot cancel a follow request to the instance actor");

    public override Task SilenceAsync()
        => throw new InvalidOperationException("You cannot silence the instance actor");
}