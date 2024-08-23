using System.Text.Json;
using System.Text.Json.Serialization;
using Cardboard.Net.Rest;

namespace Cardboard.Net.Entities.Drives;

/// <summary>
/// Class representing a drive folder
/// </summary>
public class DriveFolder : MisskeyObject
{
    /// <summary>
    /// DateTime representing when the folder was created
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; init; }
    
    /// <summary>
    /// Name of the folder
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    
    /// <summary>
    /// Id of this folder's parent if there is any
    /// </summary>
    [JsonPropertyName("parentId")]
    public string? ParentId { get; init; }
    
    /// <summary>
    /// Parent folder
    /// </summary>
    [JsonPropertyName("parent")]
    public DriveFolder? ParentFolder { get; init; }
    
    /// <summary>
    /// Amount of sub folders
    /// </summary>
    [JsonPropertyName("foldersCount")]
    public int FoldersCount { get; init; }
    
    /// <summary>
    /// Amount of files contained within
    /// </summary>
    [JsonPropertyName("filesCount")]
    public int FilesCount { get; init; }

    /// <summary>
    /// Deletes the folder
    /// </summary>
    public async Task DeleteAsync()
        => await this.Misskey.ApiClient.SendRequestAsync(Endpoints.DRIVE_FOLDER_DELETE,
            JsonSerializer.Serialize(new { folderId = this.Id }));
    
    /// <summary>
    /// Creates a folder within this folder
    /// </summary>
    /// <param name="name">Name of the child folder</param>
    /// <returns>DriveFolder representing the child</returns>
    public async Task<DriveFolder> CreateChildFolderAsync(string name)
        => await this.Misskey.ApiClient.CreateDriveFolderAsync(name, this.Id);

    /// <summary>
    /// Finds a child folder
    /// </summary>
    /// <param name="name">Name of the folder to find</param>
    /// <returns>DriveFolder representing the child</returns>
    public async Task<DriveFolder> FindChildFolderAsync(string name)
        => await this.Misskey.ApiClient.FindDriveFolderAsync(name, this.Id);
}