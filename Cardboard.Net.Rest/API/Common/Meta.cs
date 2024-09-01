using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class Meta
{
    [JsonProperty("maintainerName")] 
    public string? MaintainerName { get; set; }

    [JsonProperty("maintainerEmail")] 
    public string? MaintainerEmail { get; set; }

    [JsonProperty("version")] 
    public string Version { get; set; }

    [JsonProperty("providesTarball")] 
    public bool ProvidesTarball { get; set; }

    [JsonProperty("name")] 
    public string? Name { get; set; }

    [JsonProperty("shortName")] 
    public string? ShortName { get; set; }

    [JsonProperty("uri")] 
    public Uri Url { get; set; }

    [JsonProperty("description")] 
    public string? Description { get; set; }

    [JsonProperty("langs")] 
    public string[]? Langs { get; set; }

    [JsonProperty("tosUrl")] 
    public Uri? TosUrl { get; set; }

    [JsonProperty("repositoryUrl")] 
    public Uri? RepositoryUrl { get; set; }

    [JsonProperty("feedbackUrl")] 
    public Uri? FeedbackUrl { get; set; }

    [JsonProperty("donationUrl")] 
    public Uri? DonationUrl { get; set; }

    [JsonProperty("defaultDarkTheme")] 
    public string? DefaultDarkTheme { get; set; }

    [JsonProperty("defaultLightTheme")] 
    public string? DefaultLightTheme { get; set; }

    [JsonProperty("defaultLike")] 
    public string? DefaultLike { get; set; }

    [JsonProperty("disableRegistration")] 
    public bool RegistrationDisabled { get; set; }

    [JsonProperty("emailRequiredForSignup")]
    public bool SignupEmailRequired { get; set; }

    [JsonProperty("approvalRequiredForSignup")]
    public bool SignupApprovalRequired { get; set; }

    [JsonProperty("enableHcaptcha")] 
    public bool EnableHCaptcha { get; set; }

    [JsonProperty("hcaptchaSiteKey")] 
    public string? HCaptchaSiteKey { get; set; }

    [JsonProperty("enableMcaptcha")] 
    public bool EnableMCaptcha { get; set; }

    [JsonProperty("mcaptchaSiteKey")] 
    public string? MCaptchaSiteKey { get; set; }

    [JsonProperty("mcaptchaInstanceUrl")] 
    public Uri? MCaptchaInstanceUrl { get; set; }

    [JsonProperty("enableRecaptcha")] 
    public bool EnableReCaptcha { get; set; }

    [JsonProperty("recaptchaSiteKey")] 
    public string? ReCaptchaSiteKey { get; set; }
    
    [JsonProperty("enableTurnstile")]
    public bool EnableTurnstile { get; set; }
    
    [JsonProperty("turnstileSiteKey")]
    public string? TurnstileSiteKey { get; set; }
    
    [JsonProperty("enableAchievements")]
    public bool? EnableAchievements { get; set; }
    
    [JsonProperty("swPublickey")]
    public string? SwPublicKey { get; set; }
    
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
    
    [JsonProperty("maxNoteTextLength")]
    public ulong MaxNoteLength { get; set; }
    
    [JsonProperty("ads")]
    public Ad[] Ads { get; set; }
    
    [JsonProperty("notesPerOneAd")]
    public int NotesPerAd { get; set; }
    
    [JsonProperty("enableEmail")]
    public bool EnableEmail { get; set; }
    
    [JsonProperty("enableServiceWorker")]
    public bool EnableServiceWorker { get; set; }
    
    [JsonProperty("translatorAvailable")]
    public bool TranslatorAvailable { get; set; }
    
    [JsonProperty("mediaProxy")]
    public string MediaProxy { get; set; }
    
    [JsonProperty("enableUrlPreview")]
    public bool EnableUrlPreview { get; set; }
    
    [JsonProperty("backgroundImageUrl")]
    public Uri? BackgroundImageUrl { get; set; }
    
    [JsonProperty("impressumUrl")]
    public Uri? ImpressumUrl { get; set; }
    
    [JsonProperty("logoImageUrl")]
    public Uri? LogoImageUrl { get; set; }
    
    [JsonProperty("privacyPolicyUrl")]
    public Uri? PrivacyPolicyUrl { get; set; }
    
    [JsonProperty("inquiryUrl")]
    public Uri? InquiryUrl { get; set; }
    
    [JsonProperty("serverRules")]
    public string[]? Rules { get; set; }
    
    [JsonProperty("themeColor")]
    public string? ThemeColor { get; set; }
    
    [JsonProperty("policies")]
    public RolePolicy Policies { get; set; }
}