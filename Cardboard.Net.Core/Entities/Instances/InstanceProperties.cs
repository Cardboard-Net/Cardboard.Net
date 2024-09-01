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
    ///     Gets or sets the turnstile site key
    /// </summary>
    public string? TurnstileSiteKey { get; set; }
    
    /// <summary>
    ///     Gets or sets the turnstile secret key on the instance
    /// </summary>
    public string? TurnstileSecretKey { get; set; }
    
    /// <summary>
    ///     Gets or sets the media for sensitive media detection on the instance
    /// </summary>
    public SensitiveMediaType? SensitiveMediaDetection { get; set; }
    
    /// <summary>
    ///     Gets or sets the media detection sensitivity for media detection on the instance 
    /// </summary>
    public SensitiveMediaLevelType? SensitiveMediaSensitivity { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to flag sensitive media automatically
    /// </summary>
    public bool? SetSensitiveFlagAutomatically { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to flag videos as well
    /// </summary>
    public bool? EnableSensitiveVideoDetection { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to allow bots on the trending tab
    /// </summary>
    public bool? EnableBotTrending { get; set; }
    
    /// <summary>
    ///     Gets or sets the proxy account id on the instance
    /// </summary>
    public string? ProxyAccountId { get; set; }
    
    /// <summary>
    ///     Gets or sets the name of the maintainer
    /// </summary>
    public string? MaintainerName { get; set; }
    
    /// <summary>
    ///     Gets or sets the maintainer email
    /// </summary>
    public string? MaintainerEmail { get; set; }
    
    /// <summary>
    ///     Gets or sets the list of available languages
    /// </summary>
    public string[]? Langs { get; set; }
    
    /// <summary>
    ///     Gets or sets the deepl auth key
    /// </summary>
    public string? DeeplAuthKey { get; set; }
    
    /// <summary>
    ///     Gets or sets whether deepl is pro
    /// </summary>
    public bool? DeeplIsPro { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to use deepl free mode
    /// </summary>
    public bool? DeeplFreeMode { get; set; }
    
    /// <summary>
    ///     Gets or sets the free instance of deepl
    /// </summary>
    public string? DeeplFreeInstance { get; set; }
    
    public EmailProperties? EmailProperties { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to use the service worker
    /// </summary>
    public bool? EnableServiceWorker { get; set; }
    
    /// <summary>
    ///     Gets or sets the service worker's public key
    /// </summary>
    public string? SwPublicKey { get; set; }
    
    /// <summary>
    ///     Gets or sets the service worker's private key
    /// </summary>
    public string? SwPrivateKey { get; set; }
    
    /// <summary>
    ///     Gets or sets the terms of service url for the instance
    /// </summary>
    public Uri? TosUrl { get; set; }
    
    /// <summary>
    ///     Gets or sets the repository url for the instance
    /// </summary>
    public Uri? RepositoryUrl { get; set; }
    
    /// <summary>
    ///     Gets or sets the feedback url for the instance
    /// </summary>
    public Uri? FeedbackUrl { get; set; }
    
    /// <summary>
    ///     Gets or sets the impressum url for the instance
    /// </summary>
    public Uri? ImpressumUrl { get; set; }
    
    /// <summary>
    ///     Gets or sets the donation url for the instance
    /// </summary>
    public Uri? DonationUrl { get; set; }
    
    /// <summary>
    ///     Gets or sets the privacy policy url for the instance
    /// </summary>
    public Uri? PrivacyPolicyUrl { get; set; }
    
    /// <summary>
    ///     Gets or sets the inquiry url for the instance
    /// </summary>
    public Uri? InquiryUrl { get; set; }
    
    public ObjectStorageProperties? ObjectStorageProperties { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to enable ip logging for the instance
    /// </summary>
    public bool? EnableIpLogging { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to enable charts for remote users
    /// </summary>
    public bool? EnableChartsForRemoteUser { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to enable charts for remote instances
    /// </summary>
    public bool? EnableChartsForFederatedInstances { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to publish server machine stats
    /// </summary>
    public bool? EnableServerMachineStats { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to enable achievements
    /// </summary>
    public bool? EnableAchievements { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to enable identicon generation
    /// </summary>
    public bool? EnableIdenticonGeneration { get; set; }
    
    /// <summary>
    ///     Gets or sets the instance rules
    /// </summary>
    public string[]? ServerRules { get; set; }
    
    /// <summary>
    ///     Gets or sets the banned email domains
    /// </summary>
    public string[]? BannedEmailDomains { get; set; }
    
    /// <summary>
    ///     Gets or sets the preserved usernames for the instance (admin, staff, etc)
    /// </summary>
    public string[]? PreservedUsernames { get; set; }
    
    /// <summary>
    ///     Gets or sets the bubble instances for this instance
    /// </summary>
    public string[]? BubbleInstances { get; set; }
    
    /// <summary>
    ///     Gets or sets the manifest json override for this instance
    /// </summary>
    public string? ManifestJsonOverride { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to enable misskey fanout timeline
    /// </summary>
    public bool? EnableFanoutTimeline { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to enable timeline fallback to database
    /// </summary>
    public bool? EnableFanoutTimelineDb { get; set; }
    
    /// <summary>
    ///     Gets or sets the local user timeline cache maximum
    /// </summary>
    public int? LocalUserTimelineCacheMax { get; set; }
    
    /// <summary>
    ///     Gets or sets the remote user timeline cache maximum
    /// </summary>
    public int? RemoteUserTimelineCacheMax { get; set; }
    
    /// <summary>
    ///     Gets or sets the per user home timeline cache maximum
    /// </summary>
    public int? PerUserHomeTimelineCacheMax { get; set; }
    
    /// <summary>
    ///     Gets or sets the per list home timeline cache maximum
    /// </summary>
    public int? PerUserListTimelineCacheMax { get; set; }
    
    /// <summary>
    ///     Gets or sets the amount of notes per ad
    /// </summary>
    public int? NotesPerOneAd { get; set; }
    
    /// <summary>
    ///     Gets or sets the hosts to silence
    /// </summary>
    public string[]? SilencedHosts { get; set; }
    
    /// <summary>
    ///     Gets or sets whether url preview is enabled
    /// </summary>
    public bool? UrlPreviewEnabled { get; set; }
    
    /// <summary>
    ///     Gets or sets the url preview timeout
    /// </summary>
    public ulong? UrlPreviewTimeout { get; set; }
    
    /// <summary>
    ///     Gets or sets the url preview max content length
    /// </summary>
    public ulong? UrlPreviewMaxContentLength { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to require url preview max content length
    /// </summary>
    public bool? UrlPreviewRequireMaxContentLength { get; set; }
    
    /// <summary>
    ///     gets or sets the url preview user agent
    /// </summary>
    public string? UrlPreviewUserAgent { get; set; }
    
    /// <summary>
    ///     Gets or sets the url preview summary proxy url
    /// </summary>
    public Uri? UrlPreviewSummaryProxyUrl { get; set; }
}

public class EmailProperties
{
    /// <summary>
    ///     Gets or sets whether to enable email on the instance
    /// </summary>
    public bool? EnableEmail { get; set; }
    
    /// <summary>
    ///     Gets or sets the email to use (such as noreply)
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to use SMTP Secure
    /// </summary>
    public bool? SmtpSecure { get; set; }
    
    /// <summary>
    ///     Gets or sets the SMTP host
    /// </summary>
    public string? SmtpHost { get; set; }
    
    /// <summary>
    ///     Gets or sets the SMTP port
    /// </summary>
    public int? SmtpPort { get; set; }
    
    /// <summary>
    ///     Gets or sets the SMTP User
    /// </summary>
    public string? SmtpUser { get; set; }
    
    /// <summary>
    ///     Gets or sets the SMTP Password
    /// </summary>
    public string? SmtpPass { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to enable active email validation for the instance
    /// </summary>
    public bool? EnableActiveEmailValidation { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to enable verify mail api 
    /// </summary>
    public bool? EnableVerifyMailApi { get; set; }
    
    /// <summary>
    ///     Gets or sets the auth eky for verify mail
    /// </summary>
    public string? VerifyMailAuthKey { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to use true mail api
    /// </summary>
    public bool? EnableTrueMailApi { get; set; }
    
    /// <summary>
    ///     Gets or sets the true mail instance
    /// </summary>
    public string? TrueMailInstance { get; set; }
    
    /// <summary>
    ///     Gets or sets the true mail auth key
    /// </summary>
    public string? TrueMailAuthKey { get; set; }
}

public class ObjectStorageProperties
{
    
    /// <summary>
    ///     Gets or sets whether to use object storage on the instance
    /// </summary>
    public bool? UseObjectStorage { get; set; }
    
    /// <summary>
    ///     Gets or sets the object storage base url
    /// </summary>
    public Uri? BaseUrl { get; set; }
    
    /// <summary>
    ///     Gets or sets the object storage bucket
    /// </summary>
    public string? Bucket { get; set; }
    
    /// <summary>
    ///     Gets or sets the object storage prefix
    /// </summary>
    public string? Prefix { get; set; }
    
    /// <summary>
    ///     Gets or sets the object storage endpoint
    /// </summary>
    public string? Endpoint { get; set; }
    
    /// <summary>
    ///     Gets or sets the object storage region
    /// </summary>
    public string? Region { get; set; }
    
    /// <summary>
    ///     Gets or sets the object storage port
    /// </summary>
    public int? Port { get; set; }
    
    /// <summary>
    ///     Gets or sets the object storage access key
    /// </summary>
    public string? AccessKey { get; set; }
    
    /// <summary>
    ///     Gets or sets the object storage secret key
    /// </summary>
    public string? SecretKey { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to use ssl for object storage
    /// </summary>
    public bool? UseSsl { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to use a proxy for object storage
    /// </summary>
    public bool? UseProxy { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to set object storage to public read
    /// </summary>
    public bool? SetPublicRead { get; set; }
    
    /// <summary>
    ///     Gets or sets whether to force the path style
    /// </summary>
    public bool? S3ForcePathStyle { get; set; }
}