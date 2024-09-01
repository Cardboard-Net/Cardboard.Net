using Cardboard.Instances;
using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class UpdateMetaParams
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
    
    public string? DefaultLike { get; set; }
    
    public bool? CacheRemoteFiles { get; set; }
    
    public bool? CacheRemoteSensitiveFiles { get; set; }
    
    public bool? SignupEmailRequired { get; set; }
    
    public bool? SignupApprovalRequired { get; set; }
    
    public bool? EnableHCaptcha { get; set; }
    
    public string? HCaptchaSiteKey { get; set; }
    
    public string? HCaptchaSecretKey { get; set; }
    
    public bool? EnableMCaptcha { get; set; }
    
    public string? MCaptchaSiteKey { get; set; }
    
    public string? MCaptchaSecretKey { get; set; }
    
    public Uri? MCaptchaInstanceUrl { get; set; }
    
    public bool? EnableReCaptcha { get; set; }
    
    public string? ReCaptchaSiteKey { get; set; }
    
    public string? ReCaptchaSecretKey { get; set; }
    
    public bool? EnableTurnstile { get; set; }
    
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