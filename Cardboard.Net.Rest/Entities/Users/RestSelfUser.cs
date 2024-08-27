using Cardboard.Users;

namespace Cardboard.Rest;

public class RestSelfUser : RestUser, ISelfUser
{
    public RestSelfUser(BaseMisskeyClient misskey, string id) : base(misskey, id) { }
    public int UnreadNotificationsCount { get; }
    public int LoggedInDays { get; }
}