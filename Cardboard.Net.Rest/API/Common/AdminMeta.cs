using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class AdminMeta
{
    [JsonProperty("cacheRemoteFiles")]
    public bool CacheRemoteFiles { get; set; }
    
    [JsonProperty("cacheRemoteSensitiveFiles")]
    public bool CacheRemoteSensitiveFiles { get; set; }
    
    [JsonProperty("emailRequiredForSignup")]
    public bool SignupEmailRequired { get; set; }
    
    [JsonProperty("approvalRequiredForSignup")]
    public bool SignupApprovalRequired { get; set; }
    
    [JsonProperty("enableHcaptcha")]
    public bool EnableHCaptcha { get; set; }
    
    [JsonProperty("hcaptchaSiteKey")]
    public string HCaptchaSiteKey { get; set; }
    
    [JsonProperty("enableMcaptcha")]
    public bool EnableMCaptcha { get; set; }

    [JsonProperty("mcaptchaSiteKey")]
    public string MCaptchaSiteKey { get; set; }
    
    [JsonProperty("mcaptchaInstanceUrl")]
    public Uri? MCaptchaInstanceUrl { get; set; }
    
    [JsonProperty("enableRecaptcha")]
    public bool EnableReCaptcha { get; set; }
    
    [JsonProperty("recaptchaSiteKey")]
    public string ReCaptchaSiteKey { get; set; }
    
    // TODO: Finish
}