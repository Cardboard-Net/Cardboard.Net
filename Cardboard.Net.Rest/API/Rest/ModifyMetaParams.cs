using Cardboard.Instances;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class ModifyMetaParams
{
    [JsonProperty("disableRegistration")]
    public bool? DisableRegistration { get; set; }
    
    [JsonProperty("pinnedUsers")]
    public string[]? PinnedUsers { get; set; }
    
    [JsonProperty("hiddenTags")]
    public string[]? HiddenTags { get; set; }
    
    [JsonProperty("blockedHosts")]
    public string[]? BlockedHosts { get; set; }
    
    [JsonProperty("sensitiveWords")]
    public string[]? SensitiveWords { get; set; }
    
    [JsonProperty("prohibitedWords")]
    public string[]? ProhibitedWords { get; set; }
    
    [JsonProperty("themeColor")]
    public string? ThemeColor { get; set; }
    
    [JsonProperty("mascotImageUrl")]
    public Uri? MascotImageUrl { get; set; }
    
    [JsonProperty("bannerUrl")]
    public Uri? BannerUrl { get; set; }
    
    [JsonProperty("serverErrorImageUrl")]
    public Uri? ServerErrorImageUrl { get; set; }
    
    [JsonProperty("infoImageUrl")]
    public Uri? InfoImageUrl { get; set; }
    
    [JsonProperty("notFoundImageUrl")]
    public Uri? NotFoundImageUrl { get; set; }
    
    [JsonProperty("iconUrl")]
    public Uri? IconUrl { get; set; }
    
    [JsonProperty("app192IconUrl")]
    public Uri? App192IconUrl { get; set; }
    
    [JsonProperty("app512IconUrl")]
    public Uri? App512IconUrl { get; set; }
    
    [JsonProperty("logoImageUrl")]
    public Uri? LogoImageUrl { get; set; }
    
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("description")]
    public string? Description { get; set; }
    
    [JsonProperty("defaultLightTheme")]
    public string? DefaultLightTheme { get; set; }
    
    [JsonProperty("defaultDarkTheme")]
    public string? DefaultDarkTheme { get; set; }
    
    [JsonProperty("defaultLike")]
    public string? DefaultLike { get; set; }
    
    [JsonProperty("cacheRemoteFiles")]
    public bool? CacheRemoteFiles { get; set; }
    
    [JsonProperty("cacheRemoteSensitiveFiles")]
    public bool? CacheRemoteSensitiveFiles { get; set; }
    
    [JsonProperty("emailRequiredForSignup")]
    public bool? SignupEmailRequired { get; set; }
    
    [JsonProperty("approvalRequiredForSignup")]
    public bool? SignupApprovalRequired { get; set; }
    
    [JsonProperty("enableHcaptcha")]
    public bool? EnableHCaptcha { get; set; }
    
    [JsonProperty("hcaptchaSiteKey")]
    public string? HCaptchaSiteKey { get; set; }
    
    [JsonProperty("hcaptchaSecretKey")]
    public string? HCaptchaSecretKey { get; set; }
    
    [JsonProperty("enableMcaptcha")]
    public bool? EnableMCaptcha { get; set; }
    
    [JsonProperty("mcaptchaSiteKey")]
    public string? MCaptchaSiteKey { get; set; }
    
    [JsonProperty("mcaptchaSecretKey")]
    public string? MCaptchaSecretKey { get; set; }
    
    [JsonProperty("mcaptchaInstanceUrl")]
    public Uri? MCaptchaInstanceUrl { get; set; }
    
    [JsonProperty("enableRecaptcha")]
    public bool? EnableReCaptcha { get; set; }
    
    [JsonProperty("recaptchaSiteKey")]
    public string? ReCaptchaSiteKey { get; set; }
    
    [JsonProperty("recaptchaSecretKey")]
    public string? ReCaptchaSecretKey { get; set; }
    
    [JsonProperty("enableTurnstile")]
    public bool? EnableTurnstile { get; set; }
    
    [JsonProperty("turnstileSiteKey")]
    public string? TurnstileSiteKey { get; set; }
    
    [JsonProperty("turnstileSecretKey")]
    public string? TurnstileSecretKey { get; set; }
    
    [JsonProperty("sensitiveMediaDetection")]
    public SensitiveMediaType? SensitiveMediaDetection { get; set; }
    
    [JsonProperty("sensitiveMediaDetectionSensitivity")]
    public SensitiveMediaLevelType? SensitiveMediaSensitivity { get; set; }
    
    [JsonProperty("setSensitiveFlagAutomatically")]
    public bool? SetSensitiveFlagAutomatically { get; set; }
    
    [JsonProperty("enableSensitiveMediaDetectionForVideos")]
    public bool? EnableSensitiveVideoDetection { get; set; }
    
    [JsonProperty("enableBotTrending")]
    public bool? EnableBotTrending { get; set; }
    
    [JsonProperty("proxyAccountId")]
    public string? ProxyAccountId { get; set; }
    
    [JsonProperty("maintainerName")]
    public string? MaintainerName { get; set; }
    
    [JsonProperty("maintainerEmail")]
    public string? MaintainerEmail { get; set; }
    
    [JsonProperty("langs")]
    public string[]? Langs { get; set; }
    
    [JsonProperty("deeplAuthKey")]
    public string? DeeplAuthKey { get; set; }
    
    [JsonProperty("deeplIsPro")]
    public bool? DeeplIsPro { get; set; }
    
    [JsonProperty("deeplFreeMode")]
    public bool? DeeplFreeMode { get; set; }
    
    [JsonProperty("deeplFreeInstance")]
    public string? DeeplFreeInstance { get; set; }
    
    [JsonProperty("enableEmail")]
    public bool? EnableEmail { get; set; }
    
    [JsonProperty("email")]
    public string? Email { get; set; }
    
    [JsonProperty("smtpSecure")]
    public bool? SmtpSecure { get; set; }
    
    [JsonProperty("smptpHost")]
    public string? SmtpHost { get; set; }
    
    [JsonProperty("smtpPort")]
    public int? SmtpPort { get; set; }
    
    [JsonProperty("smtpUser")]
    public string? SmtpUser { get; set; }
    
    [JsonProperty("smtpPass")]
    public string? SmtpPass { get; set; }
    
    [JsonProperty("enableServiceWorker")]
    public bool? EnableServiceWorker { get; set; }
    
    [JsonProperty("swPublicKey")]
    public string? SwPublicKey { get; set; }
    
    [JsonProperty("swPrivateKey")]
    public string? SwPrivateKey { get; set; }
    
    [JsonProperty("tosUrl")]
    public Uri? TosUrl { get; set; }
    
    [JsonProperty("repositoryUrl")]
    public Uri? RepositoryUrl { get; set; }
    
    [JsonProperty("feedbackUrl")]
    public Uri? FeedbackUrl { get; set; }
    
    [JsonProperty("impressumUrl")]
    public Uri? ImpressumUrl { get; set; }
    
    [JsonProperty("donationUrl")]
    public Uri? DonationUrl { get; set; }
    
    [JsonProperty("privacyPolicyUrl")]
    public Uri? PrivacyPolicyUrl { get; set; }
    
    [JsonProperty("inquiryUrl")]
    public Uri? InquiryUrl { get; set; }
    
    [JsonProperty("useObjectStorage")]
    public bool? UseObjectStorage { get; set; }
    
    [JsonProperty("objectStorageBaseUrl")]
    public Uri? ObjectStorageBaseUrl { get; set; }
    
    [JsonProperty("objectStorageBucket")]
    public string? ObjectStorageBucket { get; set; }
    
    [JsonProperty("objecctStoragePrefix")]
    public string? ObjectStoragePrefix { get; set; }
    
    [JsonProperty("objectStorageEndpoint")]
    public string? ObjectStorageEndpoint { get; set; }
    
    [JsonProperty("objectStorageRegion")]
    public string? ObjectStorageRegion { get; set; }
    
    [JsonProperty("objectStoragePort")]
    public int? ObjectStoragePort { get; set; }
    
    [JsonProperty("objectStorageAccessKey")]
    public string? ObjectStorageAccessKey { get; set; }
    
    [JsonProperty("objectStorageSecretKey")]
    public string? ObjectStorageSecretKey { get; set; }
    
    [JsonProperty("objectStorageUseSSL")]
    public bool? ObjectStorageUseSsl { get; set; }
    
    [JsonProperty("objectStorageUseProxy")]
    public bool? ObjectStorageUseProxy { get; set; }
    
    [JsonProperty("objectStorageSetPublicRead")]
    public bool? ObjectStorageSetPublicRead { get; set; }
    
    [JsonProperty("objectStorageS3ForcePathStyle")]
    public bool? ObjectStorageS3ForcePathStyle { get; set; }
    
    [JsonProperty("enableIpLogging")]
    public bool? EnableIpLogging { get; set; }
    
    [JsonProperty("enableActiveEmailValidation")]
    public bool? EnableActiveEmailValidation { get; set; }
    
    [JsonProperty("enableVerifymailApi")]
    public bool? EnableVerifyMailApi { get; set; }
    
    [JsonProperty("verifymailAuthKey")]
    public string? VerifyMailAuthKey { get; set; }
    
    [JsonProperty("enableTruemailApi")]
    public bool? EnableTrueMailApi { get; set; }
    
    [JsonProperty("truemailInstance")]
    public string? TrueMailInstance { get; set; }
    
    [JsonProperty("truemailAuthKey")]
    public string? TrueMailAuthKey { get; set; }
    
    [JsonProperty("enableChartsForRemoteUser")]
    public bool? EnableChartsForRemoteUser { get; set; }
    
    [JsonProperty("enableChartsForFederatedInstances")]
    public bool? EnableChartsForFederatedInstances { get; set; }
    
    [JsonProperty("enableServerMachineStats")]
    public bool? EnableServerMachineStats { get; set; }
    
    [JsonProperty("enableAchievements")]
    public bool? EnableAchievements { get; set; }
    
    [JsonProperty("enableIdenticonGeneration")]
    public bool? EnableIdenticonGeneration { get; set; }
    
    [JsonProperty("serverRules")]
    public string[]? ServerRules { get; set; }
    
    [JsonProperty("bannedEmailDomains")]
    public string[]? BannedEmailDomains { get; set; }
    
    [JsonProperty("preservedUsernames")]
    public string[]? PreservedUsernames { get; set; }
    
    [JsonProperty("bubbleInstances")]
    public string[]? BubbleInstances { get; set; }
    
    [JsonProperty("manifestJsonOverride")]
    public string? ManifestJsonOverride { get; set; }
    
    [JsonProperty("enableFanoutTimeline")]
    public bool? EnableFanoutTimeline { get; set; }
    
    [JsonProperty("enableFanoutTimelineDbFallback")]
    public bool? EnableFanoutTimelineDb { get; set; }
    
    [JsonProperty("perLocalUserUserTimelineCacheMax")]
    public int? LocalUserTimelineCacheMax { get; set; }
    
    [JsonProperty("perRemoteUserUserTimelineCacheMax")]
    public int? RemoteUserTimelineCacheMax { get; set; }
    
    [JsonProperty("perUserHomeTimelineCacheMax")]
    public int? PerUserHomeTimelineCacheMax { get; set; }
    
    [JsonProperty("perUserListTimelineCacheMax")]
    public int? PerUserListTimelineCacheMax { get; set; }
    
    [JsonProperty("notesPerOneAd")]
    public int? NotesPerOneAd { get; set; }
    
    [JsonProperty("silencedHosts")]
    public string[]? SilencedHosts { get; set; }
    
    [JsonProperty("urlPreviewEnabled")]
    public bool? UrlPreviewEnabled { get; set; }
    
    [JsonProperty("urlPreviewTimeout")]
    public ulong? UrlPreviewTimeout { get; set; }
    
    [JsonProperty("urlPreviewMaximumContentLength")]
    public ulong? UrlPreviewMaxContentLength { get; set; }
    
    [JsonProperty("urlPreviewRequireContentLength")]
    public bool? UrlPreviewRequireMaxContentLength { get; set; }
    
    [JsonProperty("urlPreviewUserAgent")]
    public string? UrlPreviewUserAgent { get; set; }
    
    [JsonProperty("urlPreviewSummaryProxyUrl")]
    public Uri? UrlPreviewSummaryProxyUrl { get; set; }
}