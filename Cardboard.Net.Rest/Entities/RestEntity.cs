namespace Cardboard.Rest;

public abstract class RestEntity<T> : IEntity<T>
    where T : IEquatable<T>
{
    internal BaseMisskeyClient Misskey { get; }
    public T Id { get; }

    internal RestEntity(BaseMisskeyClient misskey, T id)
    {
        Misskey = misskey;
        Id = id;
    }
}