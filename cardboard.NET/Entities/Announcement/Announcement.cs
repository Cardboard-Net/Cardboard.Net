using Newtonsoft.Json;

namespace cardboard
{
    /// <summary>
    /// Class representing an existing announcement
    /// </summary>
    public class Announcement
    {
        /// <summary>
        /// Id of the announcement
        /// </summary>
        [JsonProperty("id", Required = Required.Always)]
#pragma warning disable CS8618
        public string Id { get; protected set; }
#pragma warning restore CS8618

        /// <summary>
        /// The date the announcement was created at
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; protected set; }

        /// <summary>
        /// The date of the last modification to the announcement
        /// </summary>
        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; protected set; }

        /// <summary>
        /// The title of the announcement
        /// </summary>
        [JsonProperty("title", Required = Required.Always)]
#pragma warning disable CS8618
        public string Title { get; protected set; }
#pragma warning restore CS8618

        /// <summary>
        /// The text/description of the title
        /// </summary>
        [JsonProperty("text")]
#pragma warning disable CS8618
        public string Description { get; protected set; }
#pragma warning restore CS8618

        /// <summary>
        /// The URL of the image on the announcement
        /// </summary>
        [JsonProperty("imageUrl")]
        public Uri? ImageUrl { get; protected set; }
    }
}