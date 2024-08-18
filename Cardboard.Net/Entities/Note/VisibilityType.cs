namespace Cardboard
{
    /// <summary>
    /// Represents visibility type
    /// </summary>
    public enum VisibilityType
    {
        /// <summary>
        /// Public, no restriction
        /// </summary>
        Public,
        /// <summary>
        /// Home timeline, unlisted on *oma
        /// </summary>
        Home,
        /// <summary>
        /// Followers only
        /// </summary>
        Followers,
        /// <summary>
        /// Direct message
        /// </summary>
        Specified
    }
}