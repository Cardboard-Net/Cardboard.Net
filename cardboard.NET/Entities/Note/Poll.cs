namespace cardboard
{
    /// <summary>
    /// Class representing a poll
    /// </summary>
    public class Poll
    {
        /// <summary>
        /// Whether or not the poll has a set expiration date
        /// </summary>
        public DateTime? ExpiresAt { get; protected set; }

        /// <summary>
        /// Whether the poll allows multiple choices
        /// </summary>
        public bool MultipleChoice { get; protected set; }
    }
}