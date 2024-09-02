using System.Collections.Immutable;

namespace Cardboard.Instances;

public class Meta : IMeta
{
    internal ImmutableArray<string> langs;
    internal ImmutableArray<string> rules;
    
    /// <inheritdoc/>
    public string? MaintainerName { get; internal set; }
    
    /// <inheritdoc/>
    public string? MaintainerEmail { get; internal set; }
    
    /// <inheritdoc/>
    public string Version { get; internal set; }
    
    /// <summary>
    ///     Whether the instance provides a tarball
    /// </summary>
    public bool ProvidesTarball { get; internal set; }
    
    /// <inheritdoc/>
    public string? Name { get; internal set; }
    
    /// <inheritdoc/>
    public string? ShortName { get; internal set; }
    
    /// <summary>
    ///     The url to the instance
    /// </summary>
    public Uri Url { get; internal set; }
    
    /// <inheritdoc/>
    public string? Description { get; internal set; }

    /// <summary>
    ///     A list of languages supported by the instance
    /// </summary>
    public IReadOnlyCollection<string> Langs => langs;
    
    /// <inheritdoc/>
    public string? DefaultDarkTheme { get; internal set; }
    
    /// <inheritdoc/>
    public string? DefaultLightTheme { get; internal set; }
    
    /// <summary>
    ///     The default like of the instance (if specified)
    /// </summary>
    public string? DefaultLike { get; internal set; }
    
    /// <summary>
    ///     Whether the instance has registration disabled
    /// </summary>
    public bool RegistrationDisabled { get; internal set; }
    
    /// <inheritdoc/>
    public bool SignupEmailRequired { get; internal set; }
    
    /// <inheritdoc/>
    public bool SignupApprovalRequired { get; internal set; }
    
    public CaptchaProviders CaptchaProviders { get; internal set; }
    
    /// <inheritdoc/>
    public InstanceUrls InstanceUrls { get; internal set; }
    
    /// <inheritdoc/>
    public bool? EnableAchievements { get; internal set; }
    
    /// <summary>
    ///     The swpublickey
    /// </summary>
    public string? SwPublicKey { get; internal set; }
    
    /// <summary>
    ///     The max character length for notes
    /// </summary>
    public ulong MaxNoteLength { get; internal set; }
    
    /// <summary>
    ///     The amount of notes before displaying an ad
    /// </summary>
    public int NotesPerAd { get; internal set; }
    
    /// <inheritdoc/>
    public bool EnableEmail { get; internal set; }
    
    /// <inheritdoc/>
    public bool EnableServiceWorker { get; internal set; }
    
    /// <inheritdoc/>
    public bool TranslatorAvailable { get; internal set; }
    
    /// <summary>
    ///     The media proxy
    /// </summary>
    public string MediaProxy { get; internal set; }
    
    /// <inheritdoc/>
    public bool EnableUrlPreview { get; internal set; }

    /// <summary>
    ///     A list of the rules
    /// </summary>
    public IReadOnlyList<string> Rules => rules;
    
    /// <inheritdoc/>
    public string? ThemeColor { get; internal set; }

    ICaptchaProviders IMeta.CaptchaProviders => CaptchaProviders;
    IInstanceUrls IMeta.InstanceUrls => InstanceUrls;
}

public class CaptchaProviders : ICaptchaProviders
{
    /// <inheritdoc/>
    public bool EnableHCaptcha { get; internal set; }
    
    /// <inheritdoc/>
    public string? HCaptchaSiteKey { get; internal set; }
    
    /// <inheritdoc/>
    public bool EnableMCaptcha { get; internal set; }
    
    /// <inheritdoc/>
    public string? MCaptchaSiteKey { get; internal set; }
    
    /// <inheritdoc/>
    public Uri? MCaptchaInstanceUrl { get; internal set; }
    
    /// <inheritdoc/>
    public bool EnableReCaptcha { get; internal set; }
    
    /// <inheritdoc/>
    public string? ReCaptchaSiteKey { get; internal set; }
    
    /// <inheritdoc/>
    public bool EnableTurnstile { get; internal set; }
    
    /// <inheritdoc/>
    public string? TurnstileSiteKey { get; internal set; }
}

/// <summary>
///     Subclass containing the various instance urls
/// </summary>
public class InstanceUrls : IInstanceUrls
{
    /// <inheritdoc/>
    public Uri? TosUrl { get; internal set; }
    
    /// <inheritdoc/>
    public Uri? RepositoryUrl { get; internal set; }
    
    /// <summary>
    ///     The feedback url of the instance (if specified)
    /// </summary>
    public Uri? FeedbackUrl { get; internal set; }
    
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
    
    /// <summary>
    ///     The logo image url (if specified)
    /// </summary>
    public Uri? LogoImageUrl { get; internal set; }
    
    /// <inheritdoc/>
    public Uri? PrivacyPolicyUrl { get; internal set; }
    
    /// <inheritdoc/>
    public Uri? InquiryUrl { get; internal set; }
}