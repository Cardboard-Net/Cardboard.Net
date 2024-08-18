using Newtonsoft.Json;

namespace Cardboard.Net.Entities;

/// <summary>
/// Class representing properties from misskey
/// </summary>
public class DriveFileProperties
{
    /// <summary>
    /// Width of the image
    /// </summary>
    [JsonProperty("width")]
    public int Width { get; protected set; }

    /// <summary>
    /// Height of the image
    /// </summary>
    [JsonProperty("height")]
    public int Height { get; protected set; }

    /// <summary>
    /// Orientation of the image
    /// </summary>
    [JsonProperty("orientation")]
    public int Orientation { get; protected set; }

    /// <summary>
    /// Average color of the image
    /// </summary>
    [JsonProperty("avgColor")]
#pragma warning disable CS8618
    public string AvgColor { get; protected set; }
#pragma warning restore CS8618
}