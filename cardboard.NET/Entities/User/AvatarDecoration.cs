using Newtonsoft.Json;

namespace cardboard
{
    /// <summary>
    /// Represents an avatar decoration
    /// </summary>
    public class AvatarDecoration
    {
        /// <summary>
        /// Id of the decoration
        /// </summary>
        [JsonProperty("id", Required = Required.Always)]
#pragma warning disable CS8618 
        public string Id { get; protected set; }
#pragma warning restore CS8618

        /// <summary>
        /// Angle of the decoration
        /// </summary>
        [JsonProperty("angle")]
        public int Angle { get; protected set; }

        /// <summary>
        /// Whether the decoration is flipped horizontally
        /// </summary>
        [JsonProperty("flipH")]
        public bool FlipH { get; protected set; }

        /// <summary>
        /// The URL the decoration corresponds to
        /// </summary>
        [JsonProperty("url", Required = Required.Always)]
#pragma warning disable CS8618
        public Uri Url { get; protected set; }
#pragma warning restore CS8618

        /// <summary>
        /// The X offset of the decoration
        /// </summary>
        [JsonProperty("offsetX")]
        public int XOffset { get; protected set; }
        
        /// <summary>
        /// The Y offset of the decoration
        /// </summary>
        [JsonProperty("offsetY")]
        public int YOffset { get; protected set; }
    }
}