using System;

namespace cardboard
{

    /// <summary>
    /// Role object returned from /api/roles/list - api-doc#tag/role/operation/roles___list
    /// </summary>
    public class Role
    {
        public string? Id { get; protected set; }
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