namespace Cardboard.Instances;

public class FederatedInstanceProperties
{
    /// <summary>
    ///     Whether the instance is suspended
    /// </summary>
    public bool? IsSuspended { get; set; }
    
    /// <summary>
    ///     Whether the instance is nsfw
    /// </summary>
    public bool? IsNSFW { get; set; }
    
    /// <summary>
    ///     The moderation note for the instance
    /// </summary>
    public string? ModerationNote { get; set; }
}