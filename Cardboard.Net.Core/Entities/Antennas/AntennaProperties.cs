namespace Cardboard.Antennas;

public class AntennaProperties
{
    /// <summary>
    ///     Gets or sets the name of the antenna
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    ///     Gets or sets the source of the antenna
    /// </summary>
    public AntennaSourceType? Source { get; set; }
    
    /// <summary>
    ///     Gets or sets the list id of the antenna
    /// </summary>
    public string? UserListId { get; set; }
    
    /// <summary>
    ///     Gets or sets the keywords of the antenna
    /// </summary>
    public string[]? Keywords { get; set; }
    
    /// <summary>
    ///     Gets or sets the exclude keywords of the antenna
    /// </summary>
    public string[]? ExcludeKeywords { get; set; }
    
    /// <summary>
    ///     Gets or sets the user id list of the antenna
    /// </summary>
    public string[]? UserIds { get; set; }
    
    /// <summary>
    ///     Gets or sets the case sensitivity of the antenna
    /// </summary>
    public bool? CaseSensitive { get; set; }
    
    /// <summary>
    ///     Gets or sets whether the antenna is local only
    /// </summary>
    public bool? LocalOnly { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to exclude bots from the antenna
    /// </summary>
    public bool? ExcludeBots { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to include replies in the antenna
    /// </summary>
    public bool? WithReplies { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to include notes with files in the antenna
    /// </summary>
    public bool? WithFile { get; set; }
}