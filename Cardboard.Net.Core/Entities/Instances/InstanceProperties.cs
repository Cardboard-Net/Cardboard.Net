namespace Cardboard.Instances;

/// <summary>
///     Properties that are used to modify an ISelfInstance with the specified changes
/// </summary>
public class InstanceProperties
{
    /// <summary>
    ///     Gets or sets whether registration is disabled
    /// </summary>
    public bool? DisableRegistration { get; set; }
    
    /// <summary>
    ///     Gets or sets the pinned users of the instance
    /// </summary>
    public string[]? PinnedUsers { get; set; }
    
    /// <summary>
    ///     Gets or sets the hidden tags of the instance
    /// (hashtags that won't populate)
    /// </summary>
    public string[]? HiddenTags { get; set; }
    
    /// <summary>
    ///     Gets or sets the blocked hosts of the instance
    /// </summary>
    public string[]? BlockedHosts { get; set; }
    
    /// <summary>
    ///     Gets or sets the sensitive words of the instance
    /// </summary>
    public string[]? SensitiveWords { get; set; }
    
    /// <summary>
    ///     Gets or sets the prohibited words of the instance
    /// </summary>
    public string[]? ProhibitedWords { get; set; }
    
    /// <summary>
    ///     Gets or sets the theme color of the instance
    /// </summary>
    public string? ThemeColor { get; set; }
    
    /// <summary>
    ///     Gets or sets the mascot image url of the instance
    /// </summary>
    public Uri? MascotImageUrl { get; set; }
    
    /// <summary>
    ///     Gets or sets the banner url of the instance
    /// </summary>
    public Uri? BannerUrl { get; set; }
    
    /// <summary>
    ///     Gets or sets the server error image url of the instance
    /// </summary>
    public Uri? ServerErrorImageUrl { get; set; }
    
    /// <summary>
    ///     Gets or sets the server info image url of the instance
    /// </summary>
    public Uri? InfoImageUrl { get; set; }
    
    /// <summary>
    ///     Gets or sets the not found image url of the instance
    /// </summary>
    public Uri? NotFoundImageUrl { get; set; }
    
    /// <summary>
    ///     Gets or sets the icon url of the instance
    /// </summary>
    public Uri? IconUrl { get; set; }
    
    /// <summary>
    ///     Gets or sets the app's 192 icon (for web) of the instance
    /// </summary>
    public Uri? App192IconUrl { get; set; }
    
    /// <summary>
    ///     Gets or sets the app's 512 icon (for web) of the instance
    /// </summary>
    public Uri? App512IconUrl { get; set; }
    
    /// <summary>
    ///     Gets or sets the logo image url of the instance
    /// </summary>
    public Uri? LogoImageUrl { get; set; }
    
    /// <summary>
    ///     Gets or sets the name of the instance
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    ///     Gets or sets the description of the instance
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    ///     Gets or sets the default light theme of the instance
    /// </summary>
    public string? DefaultLightTheme { get; set; }
    
    /// <summary>
    ///     Gets or sets the default dark theme of the instance
    /// </summary>
    public string? DefaultDarkTheme { get; set; }
    
    /// <summary>
    ///     Gets or sets the default like of the instance
    /// </summary>
    public string? DefaultLike { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to cache remote files on the instance
    /// </summary>
    public bool? CacheRemoteFiles { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to cache sensitive remote files on the instance  
    /// </summary>
    public bool? CacheRemoteSensitiveFiles { get; set; }
    
    /// <summary>
    ///     Gets or sets whether a signup email is required on the instance
    /// </summary>
    public bool? SignupEmailRequired { get; set; }
    
    /// <summary>
    ///     Gets or sets whether signup requires approval on the instance
    /// </summary>
    public bool? SignupApprovalRequired { get; set; }
    
    /// <summary>
    ///     Gets or sets whether hcaptcha is enabled on the instance
    /// </summary>
    public bool? EnableHCaptcha { get; set; }
    
    /// <summary>
    ///     Gets or sets the hcaptcha site key
    /// </summary>
    public string? HCaptchaSiteKey { get; set; }
    
    /// <summary>
    ///     Gets or sets the hcaptcha secret key
    /// </summary>
    public string? HCaptchaSecretKey { get; set; }
    
    /// <summary>
    ///     Gets or sets whether mcaptcha is enabled on the instance
    /// </summary>
    public bool? EnableMCaptcha { get; set; }
    
    /// <summary>
    ///     Gets or sets the mcaptcha site key on the instance
    /// </summary>
    public string? MCaptchaSiteKey { get; set; }
    
    /// <summary>
    ///     Gets or sets the mcaptcha secret key on the instance
    /// </summary>
    public string? MCaptchaSecretKey { get; set; }
    
    /// <summary>
    ///     Gets or sets the mcaptcha instance url on the instance
    /// </summary>
    public Uri? MCaptchaInstanceUrl { get; set; }
    
    /// <summary>
    ///     Gets or sets whether recaptcha is enabled on the instance
    /// </summary>
    public bool? EnableReCaptcha { get; set; }
    
    /// <summary>
    ///     Gets or sets the recaptcha site key on the instance
    /// </summary>
    public string? ReCaptchaSiteKey { get; set; }
    
    /// <summary>
    ///     Gets or sets the recaptcha secret key on the instance
    /// </summary>
    public string? ReCaptchaSecretKey { get; set; }
    
    /// <summary>
    ///     Gets or sets whether turnstile is enabled on the instance
    /// </summary>
    public bool? EnableTurnstile { get; set; }
    
    /// <summary>
    ///     Gets or sets the turnstile secret key on the instance
    /// </summary>
    public bool? TurnstileSecretKey { get; set; }
    
    public SensitiveMediaType? SensitiveMediaDetection { get; set; }
    
    public SensitiveMediaLevelType? SensitiveMediaSensitivity { get; set; }
    
    public bool? SetSensitiveFlagAutomatically { get; set; }
    
    public bool? EnableSensitiveVideoDetection { get; set; }
    
    public bool? EnableBotTrending { get; set; }
    
    public string? ProxyAccountId { get; set; }
    
    public string? MaintainerName { get; set; }
    
    public string? MaintainerEmail { get; set; }
    
    public string[]? Langs { get; set; }
    
    public string? DeeplAuthKey { get; set; }
    
    public bool? DeeplIsPro { get; set; }
    
    public bool? DeeplFreeMode { get; set; }
    
    public string? DeeplFreeInstance { get; set; }
    
    public bool? EnableEmail { get; set; }
    
    public string? Email { get; set; }
    
    public bool? SmtpSecure { get; set; }
    
    public string? SmtpHost { get; set; }
    
    public int? SmtpPort { get; set; }
    
    public string? SmtpUser { get; set; }
    
    public string? SmtpPass { get; set; }
    
    public bool? EnableServiceWorker { get; set; }
    
    public string? SwPublicKey { get; set; }
    
    public string? SwPrivateKey { get; set; }
    
    public Uri? TosUrl { get; set; }
    
    public Uri? RepositoryUrl { get; set; }
    
    public Uri? FeedbackUrl { get; set; }
    
    public Uri? ImpressumUrl { get; set; }
    
    public Uri? DonationUrl { get; set; }
    
    public Uri? PrivacyPolicyUrl { get; set; }
    
    public Uri? InquiryUrl { get; set; }
    
    public bool? UseObjectStorage { get; set; }
    
    public Uri? ObjectStorageBaseUrl { get; set; }
    
    public string? ObjectStorageBucket { get; set; }
    
    public string? ObjectStoragePrefix { get; set; }
    
    public string? ObjectStorageEndpoint { get; set; }
    
    public string? ObjectStorageRegion { get; set; }
    
    public int? ObjectStoragePort { get; set; }
    
    public string? ObjectStorageAccessKey { get; set; }
    
    public string? ObjectStorageSecretKey { get; set; }
    
    public bool? ObjectStorageUseSsl { get; set; }
    
    public bool? ObjectStorageUseProxy { get; set; }
    
    public bool? ObjectStorageSetPublicRead { get; set; }
    
    public bool? ObjectStorageS3ForcePathStyle { get; set; }
    
    public bool? EnableIpLogging { get; set; }
    
    public bool? EnableActiveEmailValidation { get; set; }
    
    public bool? EnableVerifyMailApi { get; set; }
    
    public string? VerifyMailAuthKey { get; set; }
    
    public bool? EnableTrueMailApi { get; set; }
    
    public string? TrueMailInstance { get; set; }
    
    public string? TrueMailAuthKey { get; set; }
    
    public bool? EnableChartsForRemoteUser { get; set; }
    
    public bool? EnableChartsForFederatedInstances { get; set; }
    
    public bool? EnableServerMachineStats { get; set; }
    
    public bool? EnableAchievements { get; set; }
    
    public bool? EnableIdenticonGeneration { get; set; }
    
    public string[]? ServerRules { get; set; }
    
    public string[]? BannedEmailDomains { get; set; }
    
    public string[]? PreservedUsernames { get; set; }
    
    public string[]? BubbleInstances { get; set; }
    
    public string? ManifestJsonOverride { get; set; }
    
    public bool? EnableFanoutTimeline { get; set; }
    
    public bool? EnableFanoutTimelineDb { get; set; }
    
    public int? LocalUserTimelineCacheMax { get; set; }
    
    public int? RemoteUserTimelineCacheMax { get; set; }
    
    public int? PerUserHomeTimelineCacheMax { get; set; }
    
    public int? NotesPerOnead { get; set; }
    
    public string[]? SilencedHosts { get; set; }
    
    public bool? UrlPreviewEnabled { get; set; }
    
    public ulong? UrlPreviewTimeout { get; set; }
    
    public ulong? UrlPreviewMaxContentLength { get; set; }
    
    public bool? UrlPreviewRequireMaxContentLength { get; set; }
    
    public string? UrlPreviewUserAgent { get; set; }
    
    public Uri? UrlPreviewSummaryProxyUrl { get; set; }
}