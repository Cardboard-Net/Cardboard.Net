using System;

namespace cardboard
{
    /// <summary>
    /// User object returned from /api/users/show
    /// </summary>
    public class User
    {
        public string? Id { get; protected set; }
        public string? Name { get; protected set; }
        public string? Username { get; set; }
        public string? Host { get; protected set; }
        public Uri? AvatarURL { get; protected set; }
    }
}