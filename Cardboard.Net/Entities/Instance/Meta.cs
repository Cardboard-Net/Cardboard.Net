using Newtonsoft.Json;

namespace Cardboard.Net.Entities;

/// <summary>
/// Represents the instance metadata
/// </summary>
public class Meta
{
    /// <summary>
    /// The name of the instance maintainer/owner
    /// </summary>
    [JsonProperty("maintainerName")]
    public string? MaintainerName { get; init; }
    
    /// <summary>
    /// The email of the instance maintainer/owner
    /// </summary>
    [JsonProperty("maintainerEmail")]
    public string? MaintainerEmail { get; init; }
    
    /// <summary>
    /// The current version of the software the instance is running
    /// </summary>
    [JsonProperty("version")]
    public string Version { get; init; }
    
    /// <summary>
    /// Whether the instance provides a source tarball for the instance software
    /// </summary>
    [JsonProperty("providesTarball")]
    public bool ProvidesTarball { get; init; }
    
    /// <summary>
    /// The name of the instance
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; init; }
    
    /// <summary>
    /// The short name of the instance
    /// </summary>
    [JsonProperty("shortName")]
    public string? ShortName { get; init; }
    
    /// <summary>
    /// The url of the instance
    /// </summary>
    [JsonProperty("uri")]
    public Uri Uri { get; init; }
    
    /// <summary>
    /// The instance description
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; init; }
    
    /// <summary>
    /// The languages the instance supports
    /// </summary>
    [JsonIgnore]
    public IReadOnlyList<string> Languages
        => this.langs;

    [JsonProperty("langs")]
    internal List<string> langs = [];
    
    /// <summary>
    /// The url corresponding to Terms of Service
    /// </summary>
    [JsonProperty("tosUrl")]
    public Uri? TosUrl { get; init; }
    
    /// <summary>
    /// The VCS repository of the instance software
    /// </summary>
    [JsonProperty("repositoryUrl")]
    public Uri? RepositoryUrl { get; init; }
    
    /// <summary>
    /// The feedback url of the instance
    /// </summary>
    [JsonProperty("feedbackUrl")]
    public Uri? FeedbackUrl { get; init; }
    
    /// <summary>
    /// The donation url of the instance
    /// </summary>
    [JsonProperty("donationUrl")]
    public Uri? DonationUrl { get; init; }
    
    /// <summary>
    /// The default dark theme of the instance
    /// </summary>
    [JsonProperty("defaultDarkTheme")]
    public string? DefaultDarkTheme { get; init; }
    
    /// <summary>
    /// The default light theme of the instance
    /// </summary>
    [JsonProperty("defaultLightTheme")]
    public string? DefaultLightTheme { get; init; }
    
    /// <summary>
    /// The default emoji representing a like (usually unicode heart)
    /// </summary>
    [JsonProperty("defaultLike")]
    public string? DefaultLike { get; init; }
    
    /// <summary>
    /// Whether the instance has registration enabled
    /// </summary>
    [JsonProperty("disableRegistration")]
    public bool DisableRegistration { get; init; }
    
    /// <summary>
    /// Whether the instance requires an email for registration
    /// </summary>
    [JsonProperty("emailRequiredForSignup")]
    public bool EmailRequired { get; init; }
    
    /// <summary>
    /// Whether the instance has approval queue for registration
    /// </summary>
    [JsonProperty("approvalRequiredForSignup")]
    public bool ApprovalRequired { get; init; }
    
    /// <summary>
    /// Whether the instance has hCaptcha enabled
    /// </summary>
    [JsonProperty("enableHcaptcha")]
    public bool EnableHcaptcha { get; init; }
    
    /// <summary>
    /// The public key for hCaptcha
    /// </summary>
    [JsonProperty("hcaptchaSiteKey")]
    public string? HcaptchaKey { get; init; }
    
    /// <summary>
    /// Whether the instance has mCaptcha enabled
    /// </summary>
    [JsonProperty("enableMcaptcha")]
    public bool EnableMcaptcha { get; init; }
    
    /// <summary>
    /// The public key for mCaptcha
    /// </summary>
    [JsonProperty("mcaptchaSiteKey")]
    public string? McaptchaKey { get; init; }
    
    /// <summary>
    /// The url corresponding to the mCaptcha instance
    /// </summary>
    [JsonProperty("mcaptchaInstanceUrl")]
    public Uri? McaptchaInstanceUrl { get; init; }
    
    /// <summary>
    /// Whether the instance has reCaptcha enabled
    /// </summary>
    [JsonProperty("enableRecaptcha")]
    public bool EnableRecaptcha { get; init; }
    
    /// <summary>
    /// The public key for reCaptcha
    /// </summary>
    [JsonProperty("recaptchaSiteKey")]
    public string? RecaptchaKey { get; init; }
    
    /// <summary>
    /// Whether turnstile is enabled on the instance
    /// </summary>
    [JsonProperty("enableTurnstile")]
    public bool EnableTurnstile { get; init; }
    
    /// <summary>
    /// Turnstile public key
    /// </summary>
    [JsonProperty("turnstileSiteKey")]
    public string? TurnstileKey { get; init; }
    
    /// <summary>
    /// Whether achievements are enabled on the instance
    /// </summary>
    [JsonProperty("enableAchievements")]
    public bool? EnableAchievements { get; init; }
    
    /// <summary>
    /// sw public key (no idea what this is)
    /// </summary>
    [JsonProperty("swPublickey")]
    public string SwPublicKey { get; init; }
    
    /// <summary>
    /// The url for the mascot
    /// </summary>
    [JsonProperty("mascotImageUrl")]
    public Uri MascotImageUrl { get; init; }
    
    /// <summary>
    /// The url for the banner
    /// </summary>
    [JsonProperty("bannerUrl")]
    public Uri? BannerUrl { get; init; }
    
    /// <summary>
    /// The url for server error placeholder image
    /// </summary>
    [JsonProperty("serverErrorImageUrl")]
    public Uri? ServerErrorImageUrl { get; init; }
    
    /// <summary>
    /// The server's info image
    /// </summary>
    [JsonProperty("infoImageUrl")]
    public Uri? InfoImageUrl { get; init; }
    
    /// <summary>
    /// The server's not found image url
    /// </summary>
    [JsonProperty("notFoundImageUrl")]
    public Uri? NotFoundImageUrl { get; init; }
    
    /// <summary>
    /// The server's icon url
    /// </summary>
    [JsonProperty("iconUrl")]
    public Uri? IconUrl { get; init; }
    
    /// <summary>
    /// The max note length for the instance
    /// </summary>
    [JsonProperty("maxNoteTextLength")]
    public int MaxNoteLength { get; init; }
    
    /// <summary>
    /// List of ads on the instance
    /// </summary>
    [JsonIgnore]
    public IReadOnlyList<Ad> Ads
        => this.ads;

    [JsonProperty("ads")]
    internal List<Ad> ads = [];
    
    /// <summary>
    /// The amount of notes between ads
    /// </summary>
    [JsonProperty("notesPerOneAd")]
    public int NotesPerAd { get; init; }
    
    /// <summary>
    /// Whether the instance has email configured
    /// </summary>
    [JsonProperty("enableEmail")]
    public bool EnableEmail { get; init; }
    
    /// <summary>
    /// Whether the instance has service worker available
    /// </summary>
    [JsonProperty("enableServiceWorker")]
    public bool EnableServiceWorker { get; init; }

    /// <summary>
    /// Whether the instance has Deepl translator available
    /// </summary>
    [JsonProperty("translatorAvailable")]
    public bool TranslatorAvailable { get; init; }
    
    /// <summary>
    /// The url of the media proxy
    /// </summary>
    [JsonProperty("mediaProxy")]
    public Uri MediaProxy { get; init; }
    
    /// <summary>
    /// Whether the instance generates url previews 
    /// </summary>
    [JsonProperty("enableUrlPreview")]
    public bool EnableUrlPreview { get; init; }
    
    /// <summary>
    /// The background image url
    /// </summary>
    [JsonProperty("backgroundImageUrl")]
    public Uri? BackgroundImageUrl { get; init; }
    
    /// <summary>
    /// The impressum url of the instance
    /// </summary>
    [JsonProperty("impressumUrl")]
    public Uri? ImpressumUrl { get; init; }
    
    /// <summary>
    /// The url of the instance logo
    /// </summary>
    [JsonProperty("logoImageUrl")]
    public Uri? LogoImageUrl { get; init; }
    
    /// <summary>
    /// The privacy policy url
    /// </summary>
    [JsonProperty("privacyPolicyUrl")]
    public Uri? PrivacyPolicyUrl { get; init; }
    
    /// <summary>
    /// The url for general inquiry
    /// </summary>
    [JsonProperty("inquiryUrl")]
    public Uri? InquiryUrl { get; init; }
    
    /// <summary>
    /// A list of server rules
    /// </summary>
    [JsonIgnore]
    public IReadOnlyList<string> ServerRules
        => this.serverRules;

    [JsonProperty("serverRules")]
    internal List<string> serverRules = [];
    
    /// <summary>
    /// The default theme color
    /// </summary>
    [JsonProperty("themeColor")]
    public string? ThemeColor { get; init; }
    
    /// <summary>
    /// The default role of the instance applied to all members, the equiv of
    /// discord's @everyone
    /// </summary>
    [JsonProperty("policies")]
    public RolePolicy Policy { get; init; }
}