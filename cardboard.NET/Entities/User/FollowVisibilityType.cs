namespace cardboard
{
    /// <summary>
    /// Represents a following/follower visibility type
    /// </summary>
    public enum FollowVisibilityType
    {
        /// <summary>
        /// Public, anyone can access
        /// </summary>
        Public,
        /// <summary>
        /// Followers only, only followers can access
        /// </summary>
        Followers,
        /// <summary>
        /// Private, only the user can access.
        /// </summary>
        Private
    }
}