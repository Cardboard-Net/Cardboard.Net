using System.Dynamic;
using Cardboard.Net.Entities;
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
        /// Fetches each user using the visible user id array
        /// </summary>
        /// <returns>IReadOnlyList<User>></returns>
        /// <exception cref="NotImplementedException"></exception>
#pragma warning disable CS1998
        public async Task<IReadOnlyList<User>> GetVisibleUsersAsync()
            => throw new NotImplementedException();
#pragma warning restore CS1998

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

        /// <summary>
        /// List of file ids
        /// </summary>
        [JsonProperty("fileIds")]
        public List<string>? FileIds { get; protected set; }

        /// <summary>
        /// Fetches each file using the fileId array
        /// </summary>
        /// <returns>IReadOnlyList<DriveFile>></returns>
        /// <exception cref="NotImplementedException"></exception>
#pragma warning disable CS1998
        public async Task<IReadOnlyList<DriveFile>> GetFilesAsync()
            => throw new NotImplementedException();
#pragma warning restore CS1998

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