

using Cardboard;
using Cardboard.Net.Rest.API;
using Cardboard.Rest;
using Cardboard.Roles;

using Model = Cardboard.Net.Rest.API.Role;

public class RestRole : RestEntity<string>, IRole, IUpdateable
{
    public string Name { get; private set; }
    public Uri? IconUrl { get; private set; }
    public int DisplayOrder { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    // TODO: target
    // TODO: condFormula
    public bool IsPublic { get; private set; }
    public bool IsExplorable { get; private set; }
    public bool AsBadge { get; private set; }
    public bool ModEditUsers { get; private set; }
    // TODO: policies
    public int UsersCount { get; private set; }

    public string? Color { get; private set; }
    public string Description { get; private set; }
    public bool IsModerator { get; private set; }
    public bool IsAdministrator { get; private set; }

    public RestRole(BaseMisskeyClient misskey, string id) : base(misskey, id) {}

    internal static RestRole Create(BaseMisskeyClient client, Model model)
    {
        RestRole entity = new RestRole(client, model.Id);
        entity.Update(model);
        return entity;
    }

    internal void Update(Model model)
    {
        Name = model.Name;
        IconUrl = model.IconUrl;
        DisplayOrder = model.DisplayOrder;
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedeAt;
        IsPublic = model.IsPublic;
        IsExplorable = model.IsExplorable;
        AsBadge = model.AsBadge;
        ModEditUsers = model.ModEditUsers;
        UsersCount = model.UsersCount;
        Color = model.Color;
        Description = model.Description;
        IsModerator = model.IsModerator;
        IsAdministrator = model.IsAdministrator;
    }

    /*
     * I have no idea how you want to get the users...
     * I won't touch that.
     */

    public async Task AssignUserAsync()
    {
        
    }

    public async Task UnassignUserAsync()
    {

    }

    public async Task GetNotesAsync()
    {

    }

    public async Task UpdateAsync()
    {
        var model = await Misskey.ApiClient.GetRoleAsync(Id);
        Update(model);   
    }

    public async Task DeleteAsync()
    {
        
    }
}