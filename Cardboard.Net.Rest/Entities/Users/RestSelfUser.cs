using Cardboard.Users;

namespace Cardboard.Rest;

public class RestSelfUser : RestUser
{
    public RestSelfUser(BaseMisskeyClient misskey, string id) : base(misskey, id) { }
}