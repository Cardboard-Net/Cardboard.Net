using System.Diagnostics.CodeAnalysis;
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
    
    /// <summary>
    /// Retrieve child folders if any
    /// </summary>
    /// <param name="limit">Limit (default 10, max 100)</param>
    /// <param name="searchQuery"></param>
    /// <returns></returns>
    [Experimental("FoldersExperiment")]
    public async Task<IReadOnlyList<DriveFolder>> GetDriveFoldersAsync(int limit = 10, string searchQuery = "")
        => await this.Misskey.ApiClient.GetDriveFoldersAsync(limit, this.Id, searchQuery);
    
    /// <summary>
    /// Retrieve child folders if any
    /// </summary>
    /// <param name="beforeId">folder id for folders before</param>
    /// <param name="limit">Limit (default 10, max 100)</param>
    /// <param name="searchQuery"></param>
    /// <returns></returns>
    [Experimental("FoldersExperiment")]
    public async Task<IReadOnlyList<DriveFolder>> GetDriveFoldersAsync(string beforeId, int limit = 10, string searchQuery = "")
        => await this.Misskey.ApiClient.GetDriveFoldersAsync(beforeId, limit, this.Id, searchQuery);
    
    /// <summary>
    /// Retrieve child folders if any
    /// </summary>
    /// <param name="beforeId">folder id for folders before</param>
    /// <param name="untilId">folder id for folders until</param>
    /// <param name="limit">Limit (default 10, max 100)</param>
    /// <param name="searchQuery"></param>
    /// <returns></returns>
    [Experimental("FoldersExperiment")]
    public async Task<IReadOnlyList<DriveFolder>> GetDriveFilesAsync(string beforeId, string untilId, int limit = 10, string searchQuery = "")
        => await this.Misskey.ApiClient.GetDriveFoldersAsync(beforeId, untilId, limit, this.Id, searchQuery);
}