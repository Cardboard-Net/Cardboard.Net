namespace Cardboard.Users;

public interface ISelfUser : IUser
{
    int UnreadNotificationsCount { get; }
    int LoggedInDays { get; }
}