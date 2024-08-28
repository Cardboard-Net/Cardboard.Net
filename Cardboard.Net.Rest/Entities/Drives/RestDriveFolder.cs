using Cardboard.Drives;
using Model = Cardboard.Net.Rest.API.DriveFolder;

namespace Cardboard.Rest.Drives;

public class RestDriveFolder : RestEntity<string>, IDriveFolder, IUpdateable
{
    public RestDriveFolder(BaseMisskeyClient misskey, string id) : base(misskey, id) { }
    
    public DateTime CreatedAt { get; private set; }
    public RestDriveFolder? Parent { get; private set; }
    public string Name { get; private set; }
    public int FoldersCount { get; private set; }
    public int FilesCount { get; private set; }
    
    internal static RestDriveFolder Create(BaseMisskeyClient misskey, Model model)
    {
        RestDriveFolder entity = new(misskey, model.Id);
        entity.Update(model);
        return entity;
    }
    
    public async Task UpdateAsync()
    {
        var model = await Misskey.ApiClient.GetFolderAsync(Id);
        Update(model);
    }

    internal void Update(Model model)
    {
        this.CreatedAt = model.CreatedAt;
        this.Name = model.Name;
        this.Parent = model.ParentId != null ? RestDriveFolder.Create(Misskey, Misskey.ApiClient.GetFolderAsync(model.ParentId).Result) : null;
        this.FoldersCount = model.FoldersCount;
        this.FilesCount = model.FilesCount;
    }

    public async Task ModifyAsync(Action<DriveFolderProperties> args)
    {
        var model = await DriveHelper.ModifyFolderAsync(this, Misskey, args);
        Update(model);
    }

    public async Task DeleteAsync()
        => await Misskey.ApiClient.DeleteFolderAsync(Id);
    
    IDriveFolder? IDriveFolder.Parent => Parent;
}