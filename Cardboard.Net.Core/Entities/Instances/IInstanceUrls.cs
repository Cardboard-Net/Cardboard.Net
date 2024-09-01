namespace Cardboard.Instances;

public interface IInstanceUrls
{
    /// <summary>
    ///     The terms of service url for the instance (if specified)
    /// </summary>
    Uri? TosUrl { get; }
    
    /// <summary>
    ///     The repository url of the instance (if specified)
    /// </summary>
    Uri? RepositoryUrl { get; }
    
    /// <summary>
    ///     The donation url of the instance (if specified)
    /// </summary>
    Uri? DonationUrl { get; }
    
    /// <summary>
    ///     The mascot url of the instance (if specified)
    /// </summary>
    Uri? MascotImageUrl { get; }
    
    /// <summary>
    ///     The banner url of the instance (if specified)
    /// </summary>
    Uri? BannerUrl { get; }
    
    /// <summary>
    ///     The server error image url (if specified)
    /// </summary>
    Uri? ServerErrorImageUrl { get; }
    
    /// <summary>
    ///     The info image url (if specified)
    /// </summary>
    Uri? InfoImageUrl { get; }
    
    /// <summary>
    ///     The not found image url (if specified)
    /// </summary>
    Uri? NotFoundImageUrl { get; }
    
    /// <summary>
    ///     The icon url (if specified)
    /// </summary>
    Uri? IconUrl { get; }
    
    /// <summary>
    ///     The background image url (if specified)
    /// </summary>
    Uri? BackgroundImageUrl { get; }
    
    /// <summary>
    ///     The impressum url (if specified)
    /// </summary>
    Uri? ImpressumUrl { get; }
    
    /// <summary>
    ///     The privacy policy url (if specified)
    /// </summary>
    Uri? PrivacyPolicyUrl { get; }
    
    /// <summary>
    ///     The inquiry url (if specified)
    /// </summary>
    Uri? InquiryUrl { get; }
}