using System.Dynamic;
using Newtonsoft.Json;

namespace Cardboard
{
    /// <summary>
    /// Class representing a misskey note
    /// </summary>
    public class Note
    {
        /// <summary>
        /// The visibility setting for the current note 
        /// </summary>
        [JsonProperty("visibility")]
        public VisibilityType Visibility { get; protected set; }

        /// <summary>
        /// An array of misskey:id
        /// </summary>
        [JsonProperty("visibleUserIds")]
        public List<string> VisibleUserIds { get; protected set; }

        /// <summary>
        /// Content warning for the given note
        /// </summary>
        [JsonProperty("cw")]
        public string? ContentWarning { get; protected set; }

        /// <summary>
        /// Determines if the note is visible only to the instance.
        /// </summary>
        [JsonProperty("localOnly")]
        public bool LocalOnly { get; protected set; }

        /// <summary>
        /// The reaction acceptance setting for the current note
        /// </summary>
        [JsonProperty("reactionAcceptance")]
        public ReactionAcceptanceType ReactionAcceptance { get; protected set; }

        /// <summary>
        /// Determines whether to extract mentions
        /// </summary>
        [JsonProperty("noExtractMentions")]
        public bool NoExtractMentions { get; protected set; }

        /// <summary>
        /// Determines whether to extract hashtags
        /// </summary>
        [JsonProperty("noExtractHashtags")]
        public bool NoExtractHashtags { get; protected set; }

        /// <summary>
        /// Determines whether to extract emojis
        /// </summary>
        [JsonProperty("noExtractEmojis")]
        public bool NoExtractEmojis { get; protected set; }

        /// <summary>
        /// ReplyId
        /// </summary>
        [JsonProperty("replyId")]
        public string? ReplyId { get; protected set; }

        /// <summary>
        /// RenoteId
        /// </summary>
        [JsonProperty("renoteId")]
        public string? RenoteId { get; protected set; }

        /// <summary>
        /// The id of the channel this note was posted in
        /// </summary>
        [JsonProperty("channelId")]
        public string? ChannelId { get; protected set; }

        /// <summary>
        /// The contents of the note
        /// </summary>
        [JsonProperty("text")]
        public string? Text { get; protected set; }

        /*
         * I genuinely wonder, should we recursively get the representation of
         * each file from drive? Returning to the user IReadOnlyList<DriveFile>?
         * 
         * Pros: ease of use, I don't have to iterate through FileIds to
         * fetch each one individually... 
         * 
         * Cons: Probably generates a lot of requests the user may not want to
         * have.
         */
         
        /// <summary>
        /// List of file ids
        /// </summary>
        [JsonProperty("fileIds")]
        public List<string>? FileIds { get; protected set; }

        /// <summary>
        /// List of mediaIds
        /// </summary>
        [JsonProperty("mediaIds")]
        public List<string>? MediaIds { get; protected set; }
        
        /// <summary>
        /// Poll object, if there is one
        /// </summary>
        [JsonProperty("poll")]
        public Poll? Poll { get; protected set; }
    }
}