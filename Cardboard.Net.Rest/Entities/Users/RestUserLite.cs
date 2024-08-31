using Cardboard.Net.Core.Entities.Roles;
using Cardboard.Users;

using Model = Cardboard.Net.Rest.API.UserLite;

namespace Cardboard.Rest;

public class RestUserLite : RestEntity<string>, IUserLite
{
    /// <inheritdoc/>
    public string? Name { get; private set; }
    
    /// <inheritdoc/>
    public string Username { get; private set; }
    
    /// <inheritdoc/>
    public string? Host { get; private set; }
    
    /// <inheritdoc/>
    public Uri? AvatarUrl { get; private set; }
    
    /// <inheritdoc/>
    public string? AvatarBlurhash { get; private set; }
    
    public IReadOnlyCollection<BadgeRole> BadgeRoles { get; }
    
    /// <inheritdoc/>
    public bool IsAdmin { get; private set; }
    
    /// <inheritdoc/>
    public bool IsModerator { get; private set; }
    
    /// <inheritdoc/>
    public bool IsSilenced { get; private set; }
    
    /// <inheritdoc/>
    public bool NoIndex { get; private set; }
    
    /// <inheritdoc/>
    public bool IsBot { get; private set; }
    
    /// <inheritdoc/>
    public bool IsCat { get; private set; }
    
    /// <inheritdoc/>
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
        IsAdmin = model.IsAdmin;
        IsSilenced = model.IsSilenced;
        NoIndex = model.NoIndex;
        IsBot = model.IsBot;
        IsCat = model.IsCat;
        SpeakAsCat = model.SpeakAsCat;
        
    }
    
    public Task DeleteAsync()
    {
        throw new NotImplementedException();
    }
}