using System.Collections.Immutable;

namespace Cardboard.Instances;

// TODO: Force kio to finish this.
public class AdminMeta : IMeta
{
    /// <inheritdoc/>
    public string? MaintainerName { get; internal set; }
    
    /// <inheritdoc/>
    public string? MaintainerEmail { get; internal set; }
    
    /// <inheritdoc/>
    public string Version { get; internal set; }
    
    /// <inheritdoc/>
    public string? Name { get; internal set; }
    
    /// <inheritdoc/>
    public string? ShortName { get; internal set; }
    
    /// <inheritdoc/>
    public string? Description { get; internal set; }
    
    /// <inheritdoc/>
    public string? DefaultDarkTheme { get; internal set; }
    
    /// <inheritdoc/>
    public string? DefaultLightTheme { get; internal set; }
    
    /// <inheritdoc/>
    public bool SignupEmailRequired { get; internal set; }
    
    /// <inheritdoc/>
    public bool SignupApprovalRequired { get; internal set; }
    
    public AdminCaptchaProviders CaptchaProviders { get; internal set; }
    
    public AdminInstanceUrls InstanceUrls { get; internal set; }
    
    /// <inheritdoc/>
    public bool? EnableAchievements { get; internal set; }

    /// <inheritdoc/>
    public bool EnableEmail { get; internal set; }
    
    /// <inheritdoc/>
    public bool EnableServiceWorker { get; internal set; }
    
    /// <inheritdoc/>
    public bool TranslatorAvailable { get; internal set; }
    
    /// <inheritdoc/>
    public bool EnableUrlPreview { get; internal set; }
    
    /// <inheritdoc/>
    public string? ThemeColor { get; internal set; }

    ICaptchaProviders IMeta.CaptchaProviders => CaptchaProviders;
    IInstanceUrls IMeta.InstanceUrls => InstanceUrls;
}

public class AdminCaptchaProviders : ICaptchaProviders
{
    /// <inheritdoc/>
    public bool EnableHCaptcha { get; internal set; }
    
    /// <inheritdoc/>
    public string? HCaptchaSiteKey { get; internal set; }
    
    /// <summary>
    ///     The secret key of the hcaptcha provider
    /// </summary>
    public string? HCaptchaSecretKey { get; internal set; }
    
    /// <inheritdoc/>
    public bool EnableMCaptcha { get; internal set; }
    
    /// <inheritdoc/>
    public string? MCaptchaSiteKey { get; internal set; }
    
    /// <inheritdoc/>
    public Uri? MCaptchaInstanceUrl { get; internal set; }
    
    /// <summary>
    ///     The secret key of the mcaptcha provider
    /// </summary>
    public string? MCaptchaSecretKey { get; internal set; }
    
    /// <inheritdoc/>
    public bool EnableReCaptcha { get; internal set; }
    
    /// <inheritdoc/>
    public string? ReCaptchaSiteKey { get; internal set; }
    
    /// <summary>
    ///     The secret key of the recaptcha provider
    /// </summary>
    public string? ReCaptchaSecretKey { get; internal set; }
    
    /// <inheritdoc/>
    public bool EnableTurnstile { get; internal set; }
    
    /// <inheritdoc/>
    public string? TurnstileSiteKey { get; internal set; }
    
    /// <summary>
    ///     The secret key of the turnstile provider
    /// </summary>
    public string? TurnstileSecretKey { get; internal set; }
}

/// <summary>
///     Subclass containing the various instance urls
/// </summary>
public class AdminInstanceUrls : IInstanceUrls
{
    /// <inheritdoc/>
    public Uri? TosUrl { get; internal set; }
    
    /// <inheritdoc/>
    public Uri? RepositoryUrl { get; internal set; }
    
    /// <inheritdoc/>
    public Uri? DonationUrl { get; internal set; }
    
    /// <inheritdoc/>
    public Uri? MascotImageUrl { get; internal set; }
    
    /// <inheritdoc/>
    public Uri? BannerUrl { get; internal set; }
    
    /// <inheritdoc/>
    public Uri? ServerErrorImageUrl { get; internal set; }
    
    /// <inheritdoc/>
    public Uri? InfoImageUrl { get; internal set; }
    
    /// <inheritdoc/>
    public Uri? NotFoundImageUrl { get; internal set; }
    
    /// <inheritdoc/>
    public Uri? IconUrl { get; internal set; }
    
    /// <inheritdoc/>
    public Uri? BackgroundImageUrl { get; internal set; }
    
    /// <inheritdoc/>
    public Uri? ImpressumUrl { get; internal set; }
    
    /// <inheritdoc/>
    public Uri? PrivacyPolicyUrl { get; internal set; }
    
    /// <inheritdoc/>
    public Uri? InquiryUrl { get; internal set; }
}