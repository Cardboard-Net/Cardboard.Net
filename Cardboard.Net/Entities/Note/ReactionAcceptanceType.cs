namespace Cardboard
{
    /// <summary>
    /// Reaction acceptance
    /// </summary>
    public enum ReactionAcceptanceType
    {
        /// <summary>
        /// Disables custom reacts
        /// </summary>
        LikeOnly,
        /// <summary>
        /// Disables custom reacts for remote instances only
        /// </summary>
        LikeOnlyForRemote,
        /// <summary>
        /// Disables sensitive reacts
        /// </summary>
        NonSensitiveOnly,
        /// <summary>
        /// Disables sensitive reacts for local only, while disabling custom 
        /// reacts for remote
        /// </summary>
        NonSensitiveOnlyforLocalLikeOnlyForRemote
    }
}