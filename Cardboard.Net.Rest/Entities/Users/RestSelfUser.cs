using Cardboard.Announcements;
using Cardboard.Net.Core.Entities.Roles;
using Cardboard.Notes;
using Cardboard.Users;

using Model = Cardboard.Net.Rest.API.SelfUser;

namespace Cardboard.Rest;

public class RestSelfUser : RestUser, ISelfUser
{
    /// <inheritdoc/>
    public bool HasUnreadDms { get; private set; }

    /// <inheritdoc/>
    public bool HasUnreadMentions { get; private set; }

    /// <inheritdoc/>
    public bool HasUnreadAnnouncement { get; private set; }

    /// <inheritdoc/>
    public IReadOnlyCollection<IUserAnnouncement> UnreadAnnouncements { get; }

    /// <inheritdoc/>
    public int UnreadNotificationsCount { get; private set; }

    /// <inheritdoc/>
    public int LoggedInDays { get; private set; }

    public RestSelfUser(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    internal static RestSelfUser Create(BaseMisskeyClient misskey, Model model)
    {
        RestSelfUser entity = new RestSelfUser(misskey, model.Id);
        entity.Update(model);
        return entity;
    }
    
    internal void Update(Model model) { }

    public override Task AcceptFollowRequestAsync()
        => throw new InvalidOperationException("You cannot accept a follow request from yourself");

    public override Task RejectFollowRequestAsync()
        => throw new InvalidOperationException("You cannot reject a follow request from yourself");

    public override Task CancelFollowRequestAsync()
        => throw new InvalidOperationException("You cannot cancel a follow request to yourself");
    
    public override Task SilenceAsync()
        => throw new InvalidOperationException("You cannot silence yourself");
    
    public Task DeleteAsync()
        => throw new NotImplementedException();
}