using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class CreateNoteParams
{
    // TODO: Change to enum type
    [JsonProperty("visibility")]
    public string Visibility { get; set; }
    
    [JsonProperty("visibileUserIds")]
    public string[] VisibileUserIds { get; set; }

    [JsonProperty("cw")]
    public string ContentWarning { get; set; }
    
    [JsonProperty("localOnly")]
    public bool LocalOnly { get; set; }

    // TODO: Change to enum type
    [JsonProperty("reactionAcceptance")]
    public string ReactionAcceptance { get; set; }
    
    [JsonProperty("noExtractMentions")]
    public bool NoExtractMentions { get; set; }
    
    [JsonProperty("noExtractHashtags")]
    public string NoExtractHashtags { get; set; }
    
    [JsonProperty("noExtractEmojis")]
    public string NoExtractEmojis { get; set; }
    
    [JsonProperty("replyId")]
    public string? ReplyId { get; set; }
    
    [JsonProperty("renoteId")]
    public string? RenoteId { get; set; }
    
    [JsonProperty("channelId")]
    public string? ChannelId { get; set; }
    
    [JsonProperty("text")]
    public string Text { get; set; }
    
    [JsonProperty("fileIds")]
    public string[] FileIds { get; set; }
    
    [JsonProperty("mediaIds")]
    public string[] MediaIds { get; set; }
    
    // TODO: Poll
}