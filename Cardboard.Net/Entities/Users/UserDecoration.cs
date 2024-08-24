using Newtonsoft.Json;

namespace Cardboard.Net.Entities.Users;

/// <summary>
/// Represents an AvatarDecoration applied to the User instead of standalone
/// </summary>
public class UserDecoration : MisskeyObject
{
    /// <summary>
    /// The angle this decoration is offset by
    /// </summary>
    [JsonProperty("angle")]
    public int Angle { get; internal set; }
    
    /// <summary>
    /// Whether the decoration is flipped horizontally
    /// </summary>
    [JsonProperty("flipH")]
    public bool IsFlippedHorizontal { get; internal set; }
    
    /// <summary>
    /// The url corresponding to the asset in the decoration
    /// </summary>
    [JsonProperty("url")]
    public Uri Url { get; internal set; }
    
    /// <summary>
    /// The X offset of the decoration
    /// </summary>
    [JsonProperty("offsetX")]
    public int XOffset { get; internal set; }
    
    /// <summary>
    /// The Y offset of the decoration
    /// </summary>
    [JsonProperty("offsetY")]
    public int YOffset { get; internal set; }
    
    /// <summary>
    /// Converts a user's avatar decoration into one of the instance
    /// </summary>
    /// <returns>AvatarDecoration</returns>
    public async Task<AvatarDecoration?> GetAvatarDecorationAsync()
    {
        /*
         * Yeah I hate this, but until we have an actual cache for things like
         * avatar decorations? We are going to make a request. Thank god for
         * Linq here.
         */
        var decorations = await this.Misskey.ApiClient.GetAvatarDecorationsAsync();
        return decorations.FirstOrDefault(x => x.Id == this.Id);
    }
}