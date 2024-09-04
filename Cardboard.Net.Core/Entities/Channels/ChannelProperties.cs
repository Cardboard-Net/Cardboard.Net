namespace Cardboard.Channels;

public class ChannelProperties {

    /// <summary>
    /// The name of the channel, as readable by the user.
    /// </summary>
    public string? Name {get; set;}
    /// <summary>
    /// A longer, human-readable description, that may entice the user to join the channel, or information about it in general.
    /// </summary>
    public string? Description {get; set;}
    /// <summary>
    /// An optional FileID for a Banner image.
    /// </summary>
    public string? BannerId {get; set;}
    /// <summary>
    /// Whether or not the Channel is archived, preventing it from appearing in the channel list, or showing in search results.
    /// </summary>
    public bool? IsArchived {get; set;}
    /// <summary>
    /// Whether or not the Channel is set as sensitive, showing a prominent "sticker" that highlights its sensitivity.
    /// </summary>
    public bool? IsSensitive {get; set;}
    /// <summary>
    /// Whether or not to allow a user to pull notes out of the channel via renotes.
    /// </summary>
    public bool? AllowRenoteToExternal {get; set;}

    public string? Color {get; set;}
    
    public string[]? PinnedNoteIds {get; set;}
}