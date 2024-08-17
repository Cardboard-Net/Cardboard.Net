using Newtonsoft.Json;

namespace cardboard
{
    /// <summary>
    /// Represents a user role
    /// </summary>
    public class UserRole
    {
        /// <summary>
        /// Represents the misskey:id of the role
        /// </summary>
        [JsonProperty("id")]
#pragma warning disable CS8618
        public string Id { get; protected set; }
#pragma warning restore CS8618

        /// <summary>
        /// Represents the name of the role
        /// </summary>
        [JsonProperty("name")]
#pragma warning disable CS8618
        public string Name { get; protected set; }
#pragma warning restore CS8618

        /// <summary>
        /// Represents the color of a role
        /// </summary>
        [JsonProperty("color")]
        public string? Color { get; protected set; }

        /// <summary>
        /// Represents the optional icon of the role
        /// </summary>
        [JsonProperty("iconUrl")]
        public Uri? IconUrl { get; protected set; }

        /// <summary>
        /// Represents the description text of the role
        /// </summary>
        [JsonProperty("description")]
#pragma warning disable CS8618
        public string Description { get; protected set; }
#pragma warning restore CS8618

        /// <summary>
        /// Represents whether the role is moderator
        /// </summary>
        [JsonProperty("isModerator")]
        public bool IsModerator { get; protected set; }

        /// <summary>
        /// Represents whether the role is administrator
        /// </summary>
        [JsonProperty("isAdministrator")]
        public bool IsAdministrator { get; protected set; }

        /// <summary>
        /// Represents the hierarchy of the role
        /// </summary>
        [JsonProperty("displayOrder")]
        public int Hierarchy { get; protected set; }
    }
}