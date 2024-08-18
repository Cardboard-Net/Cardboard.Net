using Newtonsoft.Json;

namespace Cardboard
{
    /// <summary>
    /// Misskey's EmojiSimple class
    /// </summary>
    public class Emoji
    {
        /// <summary>
        /// A list of alternative names for the emoji
        /// </summary>
        [JsonProperty("aliases")]
        public List<string>? Aliases { get; protected set; }

        /// <summary>
        /// Name of the emoji
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
#pragma warning disable CS8618
        public string Name { get; protected set; }
#pragma warning restore CS8618

        /// <summary>
        /// The category the emoji is under if there is any
        /// </summary>
        [JsonProperty("category")]
        public string? Category { get; protected set; }

        /// <summary>
        /// The url of the file the emoji corresponds to
        /// </summary>
        [JsonProperty("url", Required = Required.Always)]
#pragma warning disable CS8618
        public Uri Url { get; protected set; }
#pragma warning restore CS8618

        /// <summary>
        /// Whether the emoji is only able to be used locally
        /// </summary>
        [JsonProperty("localOnly")]
        public bool LocalOnly { get; protected set; }

        /// <summary>
        /// Whether the emoji is marked as sensitive
        /// </summary>
        [JsonProperty("isSensitive")]
        public bool IsSensitive { get; protected set; }

        /// <summary>
        /// An array of role Ids that can use the emoji as a reaction
        /// </summary>
        [JsonProperty("roleIdsThatCanBeUsedThisEmojiAsReaction")]
        public List<string>? AllowedRoleIds { get; protected set; }
    }
}