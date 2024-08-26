namespace Cardboard.Users;


public interface IUserDecoration : IMisskeyEntity
{
    int Angle { get; }
    bool FlipH { get; }
    Uri Url { get; }
    int XOffset { get; }
    int YOffset { get; }
}