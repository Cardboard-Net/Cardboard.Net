using System.Collections.Immutable;
using Cardboard.Instances;
using Cardboard.Net.Rest.API;
using Cardboard.Rest.Notes;

namespace Cardboard.Rest.Instances;

internal static class InstanceHelper
{
    public static async Task<RestFederatedInstance?> GetFederatedInstanceAsync(BaseMisskeyClient client, string host)
    {
        var model = await client.ApiClient.GetFederatedInstanceAsync(host).ConfigureAwait(false);

        return model != null ? RestFederatedInstance.Create(client, model) : null;
    }

    public static async Task<IReadOnlyList<RestFederatedInstanceRelation>> GetFollowingRelationAsync
    (
        BaseMisskeyClient client,
        string host,
        string? sinceId = null,
        string? untilId = null,
        int? limit = null
    )
    {
        GetFederatedInstanceRelationParams args = new GetFederatedInstanceRelationParams()
        {
            Host = host,
            SinceId = sinceId,
            UntilId = untilId,
            Limit = limit
        };

        FederatedInstanceRelation[]? models = await client.ApiClient.GetFederatedInstanceFollowingAsync(args).ConfigureAwait(false);
        
        if (models == null || models.Length == 0)
            return ImmutableArray<RestFederatedInstanceRelation>.Empty;

        var _models = ImmutableArray.CreateBuilder<RestFederatedInstanceRelation>(models.Length);

        foreach (var m in models)
            _models.Add(RestFederatedInstanceRelation.Create(client, m));

        return _models.ToImmutable();
    }
    
    public static async Task<IReadOnlyList<RestFederatedInstanceRelation>> GetFollowerRelationAsync
    (
        BaseMisskeyClient client,
        string host,
        string? sinceId = null,
        string? untilId = null,
        int? limit = null
    )
    {
        GetFederatedInstanceRelationParams args = new GetFederatedInstanceRelationParams()
        {
            Host = host,
            SinceId = sinceId,
            UntilId = untilId,
            Limit = limit
        };

        FederatedInstanceRelation[]? models = await client.ApiClient.GetFederatedInstanceFollowersAsync(args).ConfigureAwait(false);
        
        if (models == null || models.Length == 0)
            return ImmutableArray<RestFederatedInstanceRelation>.Empty;

        var _models = ImmutableArray.CreateBuilder<RestFederatedInstanceRelation>(models.Length);

        foreach (var m in models)
            _models.Add(RestFederatedInstanceRelation.Create(client, m));

        return _models.ToImmutable();
    }
    
    public static async Task<IReadOnlyList<RestFederatedInstance>> GetFederatedInstancesAsync
    (
        BaseMisskeyClient client,
        string? host = null,
        bool? blocked = null,
        bool? notResponding = null,
        bool? suspended = null,
        bool? silenced = null,
        bool? federating = null,
        bool? subscribing = null,
        bool? publishing = null,
        bool? nsfw = null,
        bool? bubble = null,
        int? limit = null,
        int? offset = null,
        InstanceSortType? sort = null
    )
    {
        GetFederatedInstancesParams instancesParams = new GetFederatedInstancesParams()
        {
            Host = host,
            Blocked = blocked,
            NotResponding = notResponding,
            Suspended = suspended,
            Silenced = silenced,
            Federating = federating,
            Subscribing = subscribing,
            Publishing = publishing,
            Nsfw = nsfw,
            Bubble = bubble,
            Limit = limit,
            Offset = offset,
            Sort = sort
        };
        
        FederatedInstance[]? models = await client.ApiClient.GetFederatedInstancesAsync(instancesParams).ConfigureAwait(false);

        if (models == null || models.Length == 0)
            return ImmutableArray<RestFederatedInstance>.Empty;

        var _models = ImmutableArray.CreateBuilder<RestFederatedInstance>(models.Length);

        foreach (var m in models)
            _models.Add(RestFederatedInstance.Create(client, m));

        return _models.ToImmutable();
    }
    
    public static async Task<bool> ModifyFederatedInstanceAsync(IFederatedInstance instance,
        BaseMisskeyClient client, FederatedInstanceProperties args)
        => await ModifyFederatedInstanceAsync(instance.Host.Host, client, args);
    
    public static async Task<bool> ModifyFederatedInstanceAsync(string host, BaseMisskeyClient client, FederatedInstanceProperties args)
    {
        ModifyFederatedInstanceParams modifyFederatedInstanceParams = new ModifyFederatedInstanceParams()
        {
            Host = host,
            IsNSFW = args.IsNSFW,
            IsSuspended = args.IsSuspended,
            ModerationNote = args.ModerationNote
        };

        return await client.ApiClient.ModifyFederatedInstanceAsync(modifyFederatedInstanceParams).ConfigureAwait(false);
    }

    public static async Task<bool> ModifyMetaAsync(BaseMisskeyClient client, Action<InstanceProperties> func)
    {
        InstanceProperties args = new InstanceProperties();
        func(args);

        ModifyMetaParams modifyMetaParams = new ModifyMetaParams()
        {
            DisableRegistration = args.DisableRegistration,
            PinnedUsers = args.PinnedUsers,
            HiddenTags = args.HiddenTags,
            BlockedHosts = args.BlockedHosts,
            SensitiveWords = args.SensitiveWords,
            ProhibitedWords = args.ProhibitedWords,
            ThemeColor = args.ThemeColor,
            MascotImageUrl = args.MascotImageUrl,
            BannerUrl = args.BannerUrl,
            ServerErrorImageUrl = args.ServerErrorImageUrl,
            InfoImageUrl = args.InfoImageUrl,
            NotFoundImageUrl = args.NotFoundImageUrl,
            IconUrl = args.IconUrl,
            App192IconUrl = args.App192IconUrl,
            App512IconUrl = args.App512IconUrl,
            LogoImageUrl = args.LogoImageUrl,
            Name = args.Name,
            Description = args.Description,
            DefaultLightTheme = args.DefaultLightTheme,
            DefaultDarkTheme = args.DefaultDarkTheme,
            DefaultLike = args.DefaultLike,
            CacheRemoteFiles = args.CacheRemoteFiles,
            CacheRemoteSensitiveFiles = args.CacheRemoteSensitiveFiles,
            SignupEmailRequired = args.SignupEmailRequired,
            SignupApprovalRequired = args.SignupApprovalRequired,
            EnableHCaptcha = args.EnableHCaptcha,
            HCaptchaSiteKey = args.HCaptchaSiteKey,
            HCaptchaSecretKey = args.HCaptchaSecretKey,
            EnableMCaptcha = args.EnableMCaptcha,
            MCaptchaSiteKey = args.MCaptchaSiteKey,
            MCaptchaSecretKey = args.MCaptchaSecretKey,
            MCaptchaInstanceUrl = args.MCaptchaInstanceUrl,
            EnableReCaptcha = args.EnableReCaptcha,
            ReCaptchaSiteKey = args.ReCaptchaSiteKey,
            ReCaptchaSecretKey = args.ReCaptchaSecretKey,
            EnableTurnstile = args.EnableTurnstile,
            TurnstileSiteKey = args.TurnstileSiteKey,
            TurnstileSecretKey = args.TurnstileSecretKey,
            SensitiveMediaDetection = args.SensitiveMediaDetection,
            SensitiveMediaSensitivity = args.SensitiveMediaSensitivity,
            SetSensitiveFlagAutomatically = args.SetSensitiveFlagAutomatically,
            EnableSensitiveVideoDetection = args.EnableSensitiveVideoDetection,
            EnableBotTrending = args.EnableBotTrending,
            ProxyAccountId = args.ProxyAccountId,
            MaintainerName = args.MaintainerName,
            MaintainerEmail = args.MaintainerEmail,
            Langs = args.Langs,
            DeeplAuthKey = args.DeeplAuthKey,
            DeeplIsPro = args.DeeplIsPro,
            DeeplFreeMode = args.DeeplFreeMode,
            DeeplFreeInstance = args.DeeplFreeInstance,
            EnableEmail = args.EmailProperties?.EnableEmail,
            Email = args.EmailProperties?.Email,
            SmtpSecure = args.EmailProperties?.SmtpSecure,
            SmtpHost = args.EmailProperties?.SmtpHost,
            SmtpPort = args.EmailProperties?.SmtpPort,
            SmtpUser = args.EmailProperties?.SmtpUser,
            SmtpPass = args.EmailProperties?.SmtpPass,
            EnableServiceWorker = args.EnableServiceWorker,
            SwPublicKey = args.SwPublicKey,
            SwPrivateKey = args.SwPrivateKey,
            TosUrl = args.TosUrl,
            RepositoryUrl = args.RepositoryUrl,
            FeedbackUrl = args.FeedbackUrl,
            ImpressumUrl = args.ImpressumUrl,
            DonationUrl = args.DonationUrl,
            PrivacyPolicyUrl = args.PrivacyPolicyUrl,
            InquiryUrl = args.InquiryUrl,
            UseObjectStorage = args.ObjectStorageProperties?.UseObjectStorage,
            ObjectStorageBaseUrl = args.ObjectStorageProperties?.BaseUrl,
            ObjectStorageBucket = args.ObjectStorageProperties?.Bucket,
            ObjectStoragePrefix = args.ObjectStorageProperties?.Prefix,
            ObjectStorageEndpoint = args.ObjectStorageProperties?.Endpoint,
            ObjectStorageRegion = args.ObjectStorageProperties?.Region,
            ObjectStoragePort = args.ObjectStorageProperties?.Port,
            ObjectStorageAccessKey = args.ObjectStorageProperties?.AccessKey,
            ObjectStorageSecretKey = args.ObjectStorageProperties?.SecretKey,
            ObjectStorageUseSsl = args.ObjectStorageProperties?.UseSsl,
            ObjectStorageUseProxy = args.ObjectStorageProperties?.UseProxy,
            ObjectStorageSetPublicRead = args.ObjectStorageProperties?.SetPublicRead,
            ObjectStorageS3ForcePathStyle = args.ObjectStorageProperties?.S3ForcePathStyle,
            EnableIpLogging = args.EnableIpLogging,
            EnableActiveEmailValidation = args.EmailProperties?.EnableActiveEmailValidation,
            EnableVerifyMailApi = args.EmailProperties?.EnableVerifyMailApi,
            VerifyMailAuthKey = args.EmailProperties?.VerifyMailAuthKey,
            EnableTrueMailApi = args.EmailProperties?.EnableTrueMailApi,
            TrueMailInstance = args.EmailProperties?.TrueMailInstance,
            TrueMailAuthKey = args.EmailProperties?.TrueMailAuthKey,
            EnableChartsForRemoteUser = args.EnableChartsForRemoteUser,
            EnableChartsForFederatedInstances = args.EnableChartsForFederatedInstances,
            EnableServerMachineStats = args.EnableServerMachineStats,
            EnableAchievements = args.EnableAchievements,
            EnableIdenticonGeneration = args.EnableIdenticonGeneration,
            ServerRules = args.ServerRules,
            BannedEmailDomains = args.BannedEmailDomains,
            PreservedUsernames = args.PreservedUsernames,
            BubbleInstances = args.BubbleInstances,
            ManifestJsonOverride = args.ManifestJsonOverride,
            EnableFanoutTimeline = args.EnableFanoutTimeline,
            EnableFanoutTimelineDb = args.EnableFanoutTimelineDb,
            LocalUserTimelineCacheMax = args.LocalUserTimelineCacheMax,
            RemoteUserTimelineCacheMax = args.RemoteUserTimelineCacheMax,
            PerUserHomeTimelineCacheMax = args.PerUserHomeTimelineCacheMax,
            PerUserListTimelineCacheMax = args.PerUserListTimelineCacheMax,
            NotesPerOneAd = args.NotesPerOneAd,
            SilencedHosts = args.SilencedHosts,
            UrlPreviewEnabled = args.UrlPreviewEnabled,
            UrlPreviewTimeout = args.UrlPreviewTimeout,
            UrlPreviewMaxContentLength = args.UrlPreviewMaxContentLength,
            UrlPreviewRequireMaxContentLength = args.UrlPreviewRequireMaxContentLength,
            UrlPreviewUserAgent = args.UrlPreviewUserAgent,
            UrlPreviewSummaryProxyUrl = args.UrlPreviewSummaryProxyUrl
        };

        return await client.ApiClient.ModifyMetaAsync(modifyMetaParams).ConfigureAwait(false);
    }
}