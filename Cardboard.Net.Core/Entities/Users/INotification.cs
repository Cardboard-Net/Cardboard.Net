namespace Cardboard.Users;

public interface INotification : IMisskeyEntity
{
    DateTime CreatedAt { get; }
    NotificationType Type { get; }
}