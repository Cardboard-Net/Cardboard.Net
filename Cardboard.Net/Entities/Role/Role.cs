using Newtonsoft.Json;

namespace Cardboard
{

    /// <summary>
    /// Role object returned from /api/roles/list - api-doc#tag/role/operation/roles___list
    /// </summary>
    public class Role
    {
        /// <summary>
        /// The misskey:id of the role
        /// </summary>
        [JsonProperty("id")]
#pragma warning disable CS8618
        public string Id { get; protected set; }
#pragma warning restore CS8618

        public string? Name { get; protected set; }
        public string? Color { get; protected set; }
        public Uri? IconUrl { get; protected set; }
        public string? Description { get; protected set; }
        public bool IsModerator { get; protected set; }
        public bool IsAdministrator { get; protected set; }
        public int Hierarchy { get; protected set; }
        public DateTime? CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }
    }
}