using Cardboard.Users;

namespace Cardboard.Notes;

public interface INote : IMisskeyEntity
{
    DateTime CreatedAt { get; }
    DateTime? DeletedAt { get; }
    string? Text { get; }
    string? ContentWarning { get; }
    IUser User { get; }
    INote? Reply { get; }
    INote? Renote { get; }
    bool IsHidden { get; }
    VisibilityType Visibility { get; }
    // TODO: Mentions, visible user ids
}