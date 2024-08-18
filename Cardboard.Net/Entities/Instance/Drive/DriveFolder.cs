using System;
using Newtonsoft.Json;

namespace Cardboard.Net.Entities;

/// <summary>
/// Represents a drive folder returned by 
///     api-doc#tag/drive/operation/drive___folders___create
///     api-doc#tag/drive/operation/drive___folders___show
/// </summary>
public class DriveFolder
{
    /// <summary>
    /// misskey:id of the current folder
    /// </summary>
    [JsonProperty("id")]
#pragma warning disable CS8618
    public string Id { get; protected set; }
#pragma warning restore CS8618

    /// <summary>
    /// DateTime of when the folder was created
    /// </summary>
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; protected set; }

    /// <summary>
    /// Name of the drive folder
    /// </summary>
    [JsonProperty("name")]
#pragma warning disable CS8618
    public string Name { get; protected set; }
#pragma warning restore CS8618

    /// <summary>
    /// misskey:id of the parent if there is any
    /// </summary>
    [JsonProperty("parentId")]
    public string? ParentId { get; protected set; }

    /// <summary>
    /// Int representing subfolders
    /// </summary>
    [JsonProperty("foldersCount")]
    public int FoldersCount { get; protected set; }

    /// <summary>
    /// Int represnting how many files are in the folder
    /// </summary>
    [JsonProperty("filesCount")]
    public int FilesCount { get; protected set; }

    /// <summary>
    /// DriveFolder of the parent, if there is any
    /// </summary>
    [JsonProperty("parent")]
    public DriveFolder? Parent { get; protected set; } 
}
