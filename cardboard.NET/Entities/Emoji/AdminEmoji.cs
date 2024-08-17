using Newtonsoft.Json;

namespace cardboard
{
    public class AdminEmoji : Emoji
    {
        /// <summary>
        /// Host of the emoji, returns null if local
        /// </summary>
        [JsonProperty("host")]
        public string? Host { get; protected set; }

        /// <summary>
        /// The license the emoji is set to use
        /// </summary>
        [JsonProperty("license")]
        public string? License { get; protected set; }
    }
}