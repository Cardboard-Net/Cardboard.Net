namespace Cardboard.Rest;

public abstract class RestEntity : IMisskeyEntity
{
    internal BaseMisskeyClient Misskey { get; }
    public string Id { get; }

    internal RestEntity(BaseMisskeyClient misskey, string id)
    {
        Misskey = misskey;
        Id = id;
    }
    
    public bool Equals(string? other)
    {
        if (other is null) return false;
        return Id == other;
    }
}