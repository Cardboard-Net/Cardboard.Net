using System;

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
        public string? Id { get; protected set; }
        /// <summary>
        /// Represents the name of the role
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; protected set; }
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
        public string? Description { get; protected set; }
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
        public UInt8 Hierarchy { get; protected set; }
    }
}