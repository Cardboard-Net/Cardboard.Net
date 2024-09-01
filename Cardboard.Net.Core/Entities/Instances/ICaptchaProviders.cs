namespace Cardboard.Instances;

public interface ICaptchaProviders
{
    /// <summary>
    ///     Whether hcaptcha is enabled
    /// </summary>
    bool EnableHCaptcha { get; }
    
    /// <summary>
    ///     The hcaptcha site key
    /// </summary>
    string? HCaptchaSiteKey { get; }
    
    /// <summary>
    ///     Whether mcaptcha is enabled
    /// </summary>
    bool EnableMCaptcha { get; }
    
    /// <summary>
    ///     The mcaptcha site key
    /// </summary>
    string? MCaptchaSiteKey { get; }
    
    /// <summary>
    ///     The mcaptcha instance url
    /// </summary>
    Uri? MCaptchaInstanceUrl { get; }
    
    /// <summary>
    ///     Whether recaptcha is enabled
    /// </summary>
    bool EnableReCaptcha { get; }
    
    /// <summary>
    ///     The recaptcha site key 
    /// </summary>
    string? ReCaptchaSiteKey { get; }
    
    /// <summary>
    ///     Whether turnstile is enabled
    /// </summary>
    bool EnableTurnstile { get; }
    
    /// <summary>
    ///     The turnstile site key
    /// </summary>
    string? TurnstileSiteKey { get; }
}