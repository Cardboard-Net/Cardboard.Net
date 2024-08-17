using Newtonsoft.Json;

namespace cardboard
{
    /// <summary>
    /// User object returned from /api/users/show
    /// </summary>
    public class User
    {
        /// <summary>
        /// misskey:id of the user
        /// </summary>
        [JsonProperty("id", Required = Required.Always)]
#pragma warning disable CS8618
        public string Id { get; protected set; }
#pragma warning restore CS8618

        /// <summary>
        /// Display name of the user
        /// </summary>
        [JsonProperty("name", Required = Required.AllowNull)]
        public string? Name { get; protected set; }

        /// <summary>
        /// Username of the user
        /// </summary>
        [JsonProperty("username", Required = Required.Always)]
#pragma warning disable CS8618
        public string Username { get; set; }
#pragma warning restore CS8618

        /// <summary>
        /// Host of the user, is null if local user
        /// </summary>
        [JsonProperty("host", Required = Required.AllowNull)]
        public string? Host { get; protected set; }

        /// <summary>
        /// The drive URL corresponding to the user's avatar 
        /// </summary>
        [JsonProperty("avatarUrl", Required = Required.AllowNull)]
        public Uri? AvatarURL { get; protected set; }

        /// <summary>
        /// Hash of the avatar
        /// </summary>
        [JsonProperty("avatarBlurhash", Required = Required.AllowNull)]
        public string? AvatarBlurHash { get; protected set; }

        /// <summary>
        /// List of avatar decorations.
        /// </summary>
        [JsonProperty("avatarDecorations")]
        public List<AvatarDecoration>? AvatarDecorations { get; protected set; }

        /// <summary>
        /// Whether the user is marked administrator on the instance
        /// </summary>
        [JsonProperty("isAdministrator")]
        public bool IsAdministrator { get; protected set; }

        /// <summary>
        /// Whether the user is marked as moderator on the instance
        /// </summary>
        [JsonProperty("isModerator")]
        public bool IsModerator { get; protected set; }

        /// <summary>
        /// Whether the user is silenced on the instance
        /// </summary>
        [JsonProperty("isSilenced")]
        public bool IsSilenced { get; protected set; }

        /// <summary>
        /// Whether indexing is enabled for the user
        /// </summary>
        public bool NoIndex { get; protected set; }

        /// <summary>
        /// Whether the user is a bot
        /// </summary>
        public bool IsBot { get; protected set; }

        /// <summary>
        /// Whether the user is a cat
        /// </summary>
        public bool IsCat { get; protected set; }

        /// <summary>
        /// Whether the user speaks like a cat
        /// </summary>
        public bool SpeakAsCat { get; protected set; }

        /// <summary>
        /// UserInstance
        /// </summary>
        /*
         * I genuinely have no fucking idea what to do here because the docs
         * are ambiguous. I want to say set the instance to nullable right,
         * but does it return Instance containing local instance information?
         * Why are all the fields in Instance nullable according to
         * 
         * /api-doc#tag/users/operation/users___show
         */
        [JsonProperty("instance")]
#pragma warning disable CS8618
        public UserInstance Instance { get; protected set; }
#pragma warning restore CS8618

        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }
        public DateTime? LastFetchedAt { get; protected set; }
        public Uri? BannerUrl { get; protected set; }
        public string? BannerBlurHash { get; protected set; }
        public Uri? BackgroundUrl { get; protected set; }
        public string? BackgroundBlurHash { get; protected set; }

        public bool IsLocked { get; protected set; }
        public bool IsSuspended { get; protected set; }

    }
}