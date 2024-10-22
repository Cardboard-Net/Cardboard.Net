namespace Cardboard.Users;


public interface IUserDecoration : IMisskeyEntity
{
    int Angle { get; }
    bool FlipH { get; }
    Uri Url { get; }
    float XOffset { get; }
    float YOffset { get; }
}