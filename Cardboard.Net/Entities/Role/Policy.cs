namespace Cardboard
{
    /// <summary>
    /// Generic class for the policy, we have several types
    /// </summary>
    public class Policy
    {
        /// <summary>
        /// Id of the policy
        /// </summary>
        public string? Name { get; protected set; }
        /// <summary>
        /// The type the policy corresponds to
        /// </summary>
        public string? Type { get; protected set; } 
    }

    /*
     * TODO: figure out how the fuck to abstract the various policy types, Do 
     * we use an interface?
     */
}