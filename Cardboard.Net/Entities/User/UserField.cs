using Newtonsoft.Json;

namespace Cardboard
{
    /// <summary>
    /// User configurable profile field
    /// </summary>
    public class UserField
    {
        /// <summary>
        /// The name of the field
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
#pragma warning disable CS8618
        public string Name { get; protected set; }
#pragma warning restore CS8618

        /// <summary>
        /// The description/value
        /// </summary>
        [JsonProperty("value", Required = Required.Always)]
#pragma warning disable CS8618
        public string Value { get; protected set; }
#pragma warning restore CS8618
    }
}