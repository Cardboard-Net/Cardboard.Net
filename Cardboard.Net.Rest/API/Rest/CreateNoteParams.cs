
using Cardboard.Notes;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class CreateNoteParams
{
    [JsonProperty("visibility")]
    public VisibilityType? Visibility { get; set; }
    
    [JsonProperty("visibleUserIds")]
    public string[]? VisibleUserIds { get; set; }

    [JsonProperty("cw")]
    public string? ContentWarning { get; set; }
    
    [JsonProperty("localOnly")]
    public bool? LocalOnly { get; set; }
    
    [JsonProperty("reactionAcceptance")]
    public AcceptanceType? ReactionAcceptance { get; set; }
    
    [JsonProperty("noExtractMentions")]
    public bool? NoExtractMentions { get; set; }
    
    [JsonProperty("noExtractHashtags")]
    public bool? NoExtractHashtags { get; set; }
    
    [JsonProperty("noExtractEmojis")]
    public bool? NoExtractEmojis { get; set; }
    
    [JsonProperty("replyId")]
    public string? ReplyId { get; set; }
    
    [JsonProperty("renoteId")]
    public string? RenoteId { get; set; }
    
    [JsonProperty("channelId")]
    public string? ChannelId { get; set; }
    
    [JsonProperty("text")]
    public string? Text { get; set; }
    
    [JsonProperty("fileIds")]
    public string[]? FileIds { get; set; }
    
    [JsonProperty("mediaIds")]
    public string[]? MediaIds { get; set; }
    
    [JsonProperty("poll")]
    public PollParams? Poll { get; set; }
}

internal class PollParams
{
    [JsonProperty("choices")]
    public string[] Choices { get; set; }
    
    [JsonProperty("multiple")]
    public bool MultipleChoice { get; set; }
    
    [JsonProperty("expiresAt")]
    public long? ExpiresAt { get; set; }
    
    [JsonProperty("expiredAfter")]
    public long? ExpiresAfter { get; set; }
}