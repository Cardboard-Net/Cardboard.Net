namespace Cardboard.Notes;

/// <summary>
/// Properties that are used to modify an INote with the specified changes
/// </summary>
/// <remarks>
///     I am not going to support changing media ids, fileIds, visibleUserIds
///     here. This is because I want to make a NoteBuilder to handle the more
///     complex notes. 
/// </remarks>
public class NoteProperties
{
    /// <summary>
    ///     Visibility of the note
    /// </summary>
    /// <remarks>
    ///     I am not sure why it is allowed within the api, because every time
    ///     I've tried it does not actually change the visibility. Whatever.
    /// </remarks>
    public VisibilityType? Visibility { get; set; }
    
    /// <summary>
    ///     Content warning of the note
    /// </summary>
    /// <remarks>
    ///     The content warning of the note
    /// </remarks>
    public string? ContentWarning { get; set; }
    
    /// <summary>
    ///     Whether the note is local
    /// </summary>
    /// <remarks>
    ///     I am not sure why it is allowed within the api, because every time
    ///     I've tried it does not actually change the federation. Whatever.
    /// </remarks>
    public bool? LocalOnly { get; set; }
    
    /// <summary>
    ///     Acceptance type of the note
    /// </summary>
    /// <remarks>
    ///     I am not sure why it is allowed within the api, because every time
    ///     I've tried it does not actually change the acceptance. Whatever.
    /// </remarks>
    public AcceptanceType? ReactionAcceptance { get; set; }
    
    /// <summary>
    ///     Whether to invalidate mentions (they don't get a notification)
    /// </summary>
    public bool? NoExtractMentions { get; set; }
    
    /// <summary>
    ///     Whether to extract emojis
    /// </summary>
    public bool? NoExtractEmojis { get; set; }
    
    /// <summary>
    ///     Whether to extract hashtags
    /// </summary>
    public bool? NoExtractHashtags { get; set; }
    
    /// <summary>
    ///     The post this is a reply to (I assume?)
    /// </summary>
    /// <exception cref="ArgumentException">Throws an exception if you try to set both replyId & reply</exception>
    public string? ReplyId
    {
        get => replyId;
        set
        {
            if (value != null && this.renote != null)
            {
                throw new ArgumentException("Cannot set replyId & reply");
            }

            replyId = value;
        }
    }
    private string? replyId;

    /// <summary>
    ///     The post this is a reply to (I assume?)
    /// </summary>
    /// <exception cref="ArgumentException">Throws an exception if you try to set both replyId & reply</exception>
    public INote? Reply
    {
        get => reply; 
        set
        {
            if (value != null && this.replyId != null)
            {
                throw new ArgumentException("Cannot set replyId & reply");
            }

            reply = value;
        }
    }
    private INote? reply;
    
    /// <summary>
    ///     The post this is a quote/renote of (I assume?)
    /// </summary>
    /// <exception cref="ArgumentException">Throws an exception if you try to set both renoteId & renote</exception>
    public string? RenoteId
    {
        get => renoteId;
        set
        {
            if (value != null && this.renote != null)
            {
                throw new ArgumentException("Cannot set renoteId & renote");
            }

            renoteId = value;
        }
    }
    private string? renoteId;

    
    /// <summary>
    ///     The post this is a quote/renote of (I assume?)
    /// </summary>
    /// <exception cref="ArgumentException">Throws an exception if you try to set both renoteId & renote</exception>
    public INote? Renote
    {
        get => renote; 
        set
        {
            if (value != null && this.renoteId != null)
            {
                throw new ArgumentException("Cannot set renoteId & renote");
            }

            renote = value;
        }
    }
    private INote? renote;
    
    /// <summary>
    ///     The channelid of the channel
    /// </summary>
    public string? ChannelId { get; set; }
    
    /// <summary>
    ///     The text
    /// </summary>
    public string? Text { get; set; }
    
    /// <summary>
    ///     The poll.
    /// </summary>
    public Poll? Poll { get; set; }
}