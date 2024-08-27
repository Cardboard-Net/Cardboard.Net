using Cardboard.Drives;
using Cardboard.Users;

namespace Cardboard.Rest.Drives;

public class RestDriveFile : RestEntity<string>, IDriveFile, IUpdateable
{
    public RestDriveFile(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    public string Id { get; }
    public DateTime CreatedAt { get; }
    public string Name { get; }
    public string Type { get; }
    public string Md5 { get; }
    public ulong Size { get; }
    public Uri? Url { get; }
    public string? Comment { get; }
    public IDriveFolder? ParentFolder { get; }
    public IUser? Uploader { get; }

    public Task UpdateAsync()
    {
        throw new NotImplementedException();
    }
}