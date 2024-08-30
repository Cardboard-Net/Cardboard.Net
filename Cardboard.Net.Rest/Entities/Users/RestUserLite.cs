using Cardboard.Users;

using Model = Cardboard.Net.Rest.API.UserLite;

namespace Cardboard.Rest;

public class RestUserLite : RestEntity<string>, IUserLite, IUpdateable
{
    public string? Name { get; private set; }
    public string Username { get; private set; }
    public string? Host { get; private set; }
    public Uri? AvatarUrl { get; private set; }
    public string? AvatarBlurhash { get; private set; }
    public bool IsAdmin { get; private set; }
    public bool IsModerator { get; private set; }
    public bool IsSilenced { get; private set; }
    public bool NoIndex { get; private set; }
    public bool IsBot { get; private set; }
    public bool IsCat { get; private set; }
    public bool SpeakAsCat { get; private set; }
    public IUserInstance Instance { get; private set; }
    public StatusType OnlineStatus { get; private set; }
    
    public RestUserLite(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    internal static RestUserLite Create(BaseMisskeyClient misskey, Model model)
    {
        RestUserLite entity = new RestUserLite(misskey, model.Id);
        entity.Update(model);
        return entity;
    }

    internal void Update(Model model)
    {
        Name = model.Name;
        Username = model.Username;
        Host = model.Host;
        AvatarUrl = model.AvatarUrl;
    }
    
    public Task UpdateAsync()
    {
        throw new NotImplementedException();
    }
    
    public Task DeleteAsync()
    {
        throw new NotImplementedException();
    }
    
    
}