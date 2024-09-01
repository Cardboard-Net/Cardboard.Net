namespace Cardboard.Instances;

public interface IMeta
{
    /// <summary>
    ///     The name of the owner/maintainer (if specified)    
    /// </summary>
    string? MaintainerName { get; }
    
    /// <summary>
    ///     The email address of the owner/maintainer (if specified)
    /// </summary>
    string? MaintainerEmail { get; }
    
    /// <summary>
    ///     The version of the instance software
    /// </summary>
    string Version { get; }
    
    /// <summary>
    ///     The name of the instance (if specified)
    /// </summary>
    string? Name { get; }
    
    /// <summary>
    ///     The shortname of the instance (if specified)
    /// </summary>
    string? ShortName { get; }
    
    /// <summary>
    ///     The description of the instance (if specified)
    /// </summary>
    string? Description { get; }
    
    /// <summary>
    ///     The default dark theme of the instance (if specified)
    /// </summary>
    string? DefaultDarkTheme { get; }
    
    /// <summary>
    ///     The default light theme of the instance (if specified)
    /// </summary>
    string? DefaultLightTheme { get; }
    
    /// <summary>
    ///     Whether the instance requires an email to sign up
    /// </summary>
    bool SignupEmailRequired { get; }
    
    /// <summary>
    ///     Whether the instance requires approval for signup
    /// </summary>
    bool SignupApprovalRequired { get; }
    
    /// <summary>
    ///     A subclass containing information about various captcha providers.
    /// </summary>
    ICaptchaProviders CaptchaProviders { get; }
    
    /// <summary>
    ///     A subclass containing various urls for the instance.
    /// </summary>
    IInstanceUrls InstanceUrls { get; }
    
    /// <summary>
    ///     Whether the instance has achievements enabled (if specified)
    /// </summary>
    bool? EnableAchievements { get; }
    
    //public Ad[] Ads { get; set; }
    
    /// <summary>
    ///     Whether email is enabled
    /// </summary>
    bool EnableEmail { get; }
    
    /// <summary>
    ///     Whether the service worker is enabled
    /// </summary>
    bool EnableServiceWorker { get; }
    
    /// <summary>
    ///     Whether the Deepl translator is available
    /// </summary>
    bool TranslatorAvailable { get; }
    
    /// <summary>
    ///     Whether url preview generation is enabled
    /// </summary>
    bool EnableUrlPreview { get; }
    
    /// <summary>
    ///     The theme color of the instance
    /// </summary>
    string? ThemeColor { get; }
    
    //public RolePolicy Policies { get; set; }
}