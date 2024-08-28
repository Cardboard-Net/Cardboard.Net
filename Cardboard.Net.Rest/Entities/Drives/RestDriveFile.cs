using Cardboard.Drives;
using Cardboard.Users;

using Model = Cardboard.Net.Rest.API.DriveFile;

namespace Cardboard.Rest.Drives;

public class RestDriveFile : RestEntity<string>, IDriveFile, IUpdateable
{
    public RestDriveFile(BaseMisskeyClient misskey, string id) : base(misskey, id) { }
    
    public DateTime CreatedAt { get; private set; }
    
    public string Name { get; private set; }
    
    public string Type { get; private set; }
    
    public string Md5 { get; private set; }
    
    public ulong Size { get; private set; }
    
    public Uri? Url { get; private set; }
    
    public string? Comment { get; private set; }
    
    public IDriveFolder? ParentFolder { get; private set; }
    
    public IUser? Uploader { get; private set; }

    internal static RestDriveFile Create(BaseMisskeyClient misskey, Model model)
    {
        RestDriveFile entity = new(misskey, model.Id);
        entity.Update(model);
        return entity;
    }
    
    public async Task UpdateAsync()
    {
        var model = await Misskey.ApiClient.GetFileAsync(Id);
        Update(model);
    }

    internal void Update(Model model)
    {
        this.CreatedAt = model.CreatedAt;
        this.Name = model.Name;
        this.Type = model.Type;
        this.Md5 = model.Md5;
        this.Size = model.Size;
        this.Url = model.Url;
        this.Comment = model.Comment;
        // TODO: parent folder, uploader
    }

    public async Task ModifyAsync(Action<DriveFileProperties> args)
    {
        var model = await DriveHelper.ModifyFileAsync(this, Misskey, args).ConfigureAwait(false);
        Update(model);
    }

    public async Task DeleteAsync()
        => await Misskey.ApiClient.DeleteFileAsync(Id);
}