using Cardboard.Notes;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class Note
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
    
    [JsonProperty("deletedAt")]
    public DateTime? DeletedAt { get; set; }
    
    [JsonProperty("text")]
    public string? Text { get; set; }
    
    [JsonProperty("cw")]
    public string? ContentWarning { get; set; }
    
    [JsonProperty("userId")]
    public string UserId { get; set; }
    
    [JsonProperty("user")]
    public UserLite? User { get; set; }
    
    [JsonProperty("replyId")]
    public string? ReplyId { get; set; }
    
    [JsonProperty("reply")]
    public Note? Reply { get; set; }
    
    [JsonProperty("renoteId")]
    public string? RenoteId { get; set; }
    
    [JsonProperty("renote")]
    public Note? Renote { get; set; }
    
    [JsonProperty("isHidden")]
    public bool IsHidden { get; set; }
    
    [JsonProperty("visibility")]
    public VisibilityType Visibility { get; set; }
    
    [JsonProperty("mentions")]
    public string[]? Mentions { get; set; }
    
    [JsonProperty("visibleUserIds")]
    public string[]? VisibleUserIds { get; set; }
    
    [JsonProperty("fileIds")]
    public string[]? FileIds { get; set; }
    
    [JsonProperty("files")]
    public DriveFile[]? Files { get; set; }
    
    [JsonProperty("tags")]
    public string[]? Tags { get; set; }
    
    // TODO: emojis
 
    // TODO: poll
    
    [JsonProperty("channelId")]
    public string ChannelId { get; set; }
    
    [JsonProperty("channel")]
    public Channel Channel { get; set; }
    
    [JsonProperty("localOnly")]
    public bool LocalOnly { get; set; }
    
    [JsonProperty("reactionAcceptance")]
    public AcceptanceType? ReactionAcceptance { get; set; }
    
    // TODO: Reaction emojis
    
    // TODO: reactions
    
    [JsonProperty("reactionCount")]
    public int ReactionCount { get; set; }
    
    [JsonProperty("renoteCount")]
    public int RenoteCount { get; set; }
    
    [JsonProperty("repliesCount")]
    public int RepliesCount { get; set; }
    
    [JsonProperty("url")]
    public Uri Url { get; set; }
    
    [JsonProperty("uri")]
    public Uri Uri { get; set; }
    
    // TODO: reactionAndUserPairCache
    
    [JsonProperty("clippedCount")]
    public int ClippedCount { get; set; }
    
    [JsonProperty("myReaction")]
    public string? MyReaction { get; set; }
}

internal class Poll
{
    [JsonProperty("choices")]
    public string[] Choices { get; set; }
    
    [JsonProperty("multiple")]
    public bool MultipleChoice { get; set; }
    
    [JsonProperty("expiresAt")]
    public ulong ExpiresAt { get; set; }
    
    [JsonProperty("expiredAfter")]
    public ulong ExpiresAfter { get; set; }
}