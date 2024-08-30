using Cardboard.Drives;
using Cardboard.Net.Rest.API;
using DriveFileProperties = Cardboard.Drives.DriveFileProperties;

namespace Cardboard.Rest.Drives;

internal static class DriveHelper
{
    public static async Task<RestDriveFile> GetDriveFileAsync(BaseMisskeyClient client, string id)
    {
        var model = await client.ApiClient.GetFileAsync(id).ConfigureAwait(false);
        if (model != null)
            return RestDriveFile.Create(client, model);
        return null;
    }

    // TODO: GetFolderAsync()
    
    // TODO: CreateFolderAsync();
    
    public static async Task<DriveFile> ModifyFileAsync(IDriveFile file, BaseMisskeyClient client,
        Action<Cardboard.Drives.DriveFileProperties> func)
        => await ModifyFileAsync(file.Id, client, func);

    public static async Task<DriveFile> ModifyFileAsync(string fileId, BaseMisskeyClient client,
        Action<Cardboard.Drives.DriveFileProperties> func)
    {
        DriveFileProperties args = new DriveFileProperties();
        func(args);

        ModifyFileParams modifyFileParams = new ModifyFileParams()
        {
            Id = fileId,
            FolderId = args.ParentId,
            Name = args.Name,
            Comment = args.Comment,
            IsSensitive = args.IsSensitive
        };

        return await client.ApiClient.ModifyDriveFileAsync(fileId, modifyFileParams);
    }
    
    public static async Task<DriveFolder> ModifyFolderAsync(IDriveFolder folder, BaseMisskeyClient client,
        Action<Cardboard.Drives.DriveFolderProperties> func)
        => await ModifyFolderAsync(folder.Id, client, func);

    public static async Task<DriveFolder> ModifyFolderAsync(string folderId, BaseMisskeyClient client,
        Action<Cardboard.Drives.DriveFolderProperties> func)
    {
        DriveFolderProperties args = new DriveFolderProperties();
        func(args);
        
        ModifyFolderParams modifyParams = new ModifyFolderParams()
        {
            Id = folderId,
            ParentId = args.ParentId ?? args.Parent?.Id,
            Name = args.Name,
        };

        return await client.ApiClient.ModifyDriveFolderAsync(folderId, modifyParams);
    }
}