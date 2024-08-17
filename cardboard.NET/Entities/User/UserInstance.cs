using System;

namespace cardboard
{
    /// <summary>
    /// Represents the instance object in a user
    /// </summary>
    public class UserInstance
    {
        /// <summary>
        /// Name of the instance
        /// </summary>
        public string? Name { get; protected set; }
        /// <summary>
        /// Name of the software the instance is running
        /// </summary>
        public string? SoftwareName { get; protected set; }
        /// <summary>
        /// Version of the software the instance is running
        /// </summary>
        public string? SoftwareVersion { get; protected set; }
        /// <summary>
        /// Url corresponding to the icon of the instance
        /// </summary>
        public Uri? IconUrl { get; protected set; }
        /// <summary>
        /// Url corresponding to the favicon of the instance
        /// </summary>
        public Uri? FaviconUrl { get; protected set; }
        /// <summary>
        /// String corresponding to the color of the instance
        /// </summary>
        public string? ThemeColor { get; protected set; }
    }
}