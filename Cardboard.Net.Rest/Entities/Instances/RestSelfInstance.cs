using System.Collections.Immutable;
using Cardboard.Instances;
using Cardboard.Users;

using ModelMeta = Cardboard.Net.Rest.API.Meta;
using ModelAdminMeta = Cardboard.Net.Rest.API.AdminMeta;

namespace Cardboard.Rest.Instances;

public class RestSelfInstance : RestEntity<string>, ISelfInstance, IUpdateable
{
    public RestInstanceActor InstanceActor { get; private set; }
    public Meta Meta { get; private set; }
    public AdminMeta? AdminMeta { get; private set; }
    
    public RestSelfInstance(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    internal static RestSelfInstance Create(BaseMisskeyClient client, ModelMeta model, RestInstanceActor actor)
    {
        RestSelfInstance entity = new(client, actor.Id);
        entity.InstanceActor = actor;
        entity.Update(model);
        return entity;
    }

    internal void Update(ModelMeta model)
    {
        Meta meta = new Meta()
        {
            MaintainerName = model.MaintainerName,
            MaintainerEmail = model.MaintainerEmail,
            Version = model.Version,
            ProvidesTarball = model.ProvidesTarball,
            Name = model.Name,
            ShortName = model.ShortName,
            Url = model.Url,
            Description = model.Description,
            langs = (model.Langs != null && model.Langs.Length != 0) 
                ? ImmutableArray.Create<string>(model.Langs) 
                : ImmutableArray<string>.Empty,
            DefaultDarkTheme = model.DefaultDarkTheme,
            DefaultLightTheme = model.DefaultLightTheme,
            DefaultLike = model.DefaultLike,
            RegistrationDisabled = model.RegistrationDisabled,
            SignupEmailRequired = model.SignupEmailRequired,
            SignupApprovalRequired = model.SignupApprovalRequired,
            CaptchaProviders = new CaptchaProviders()
            {
                EnableHCaptcha = model.EnableHCaptcha,
                HCaptchaSiteKey = model.HCaptchaSiteKey,
                EnableMCaptcha = model.EnableMCaptcha,
                MCaptchaSiteKey = model.MCaptchaSiteKey,
                MCaptchaInstanceUrl = model.MCaptchaInstanceUrl,
                EnableReCaptcha = model.EnableReCaptcha,
                ReCaptchaSiteKey = model.ReCaptchaSiteKey,
                EnableTurnstile = model.EnableTurnstile,
                TurnstileSiteKey = model.TurnstileSiteKey
            },
            InstanceUrls = new InstanceUrls()
            {
                TosUrl = model.TosUrl,
                RepositoryUrl = model.RepositoryUrl,
                FeedbackUrl = model.FeedbackUrl,
                DonationUrl = model.DonationUrl,
                MascotImageUrl = model.MascotImageUrl,
                BannerUrl = model.BannerUrl,
                ServerErrorImageUrl = model.ServerErrorImageUrl,
                InfoImageUrl = model.InfoImageUrl,
                NotFoundImageUrl = model.NotFoundImageUrl,
                IconUrl = model.IconUrl,
                BackgroundImageUrl = model.BackgroundImageUrl,
                ImpressumUrl = model.ImpressumUrl,
                LogoImageUrl = model.LogoImageUrl,
                PrivacyPolicyUrl = model.PrivacyPolicyUrl,
                InquiryUrl = model.InquiryUrl
            },
            EnableAchievements = model.EnableAchievements,
            SwPublicKey = model.SwPublicKey,
            MaxNoteLength = model.MaxNoteLength,
            NotesPerAd = model.NotesPerAd,
            EnableEmail = model.EnableEmail,
            EnableServiceWorker = model.EnableServiceWorker,
            TranslatorAvailable = model.TranslatorAvailable,
            MediaProxy = model.MediaProxy,
            rules = (model.Rules != null && model.Rules.Length != 0) 
                ? ImmutableArray.Create<string>(model.Rules) 
                : ImmutableArray<string>.Empty,
            ThemeColor = model.ThemeColor
        };
        
        Meta = meta;
    }

    internal void Update(ModelAdminMeta model)
    {
        AdminMeta meta = new AdminMeta()
        {
            MaintainerName = model.MaintainerName,
            MaintainerEmail = model.MaintainerEmail,
            Version = model.Version,
            Name = model.Name,
            ShortName = model.ShortName,
            Description = model.Description,
            DefaultDarkTheme = model.DefaultDarkTheme,
            DefaultLightTheme = model.DefaultLightTheme,
            SignupEmailRequired = model.SignupEmailRequired,
            SignupApprovalRequired = model.SignupApprovalRequired,
            CaptchaProviders = new AdminCaptchaProviders()
            {
                EnableHCaptcha = model.EnableHCaptcha,
                HCaptchaSiteKey = model.HCaptchaSiteKey,
                HCaptchaSecretKey = model.HCaptchaSecretKey,
                EnableMCaptcha = model.EnableMCaptcha,
                MCaptchaSiteKey = model.MCaptchaSiteKey,
                MCaptchaInstanceUrl = model.MCaptchaInstanceUrl,
                MCaptchaSecretKey = model.MCaptchaSecretKey,
                EnableReCaptcha = model.EnableReCaptcha,
                ReCaptchaSiteKey = model.ReCaptchaSiteKey,
                ReCaptchaSecretKey = model.ReCaptchaSecretKey,
                EnableTurnstile = model.EnableTurnstile,
                TurnstileSiteKey = model.TurnstileSiteKey,
                TurnstileSecretKey = model.TurnstileSecretKey
            },
            InstanceUrls = new AdminInstanceUrls()
            {
                TosUrl = model.TosUrl,
                RepositoryUrl = model.RepositoryUrl,
                DonationUrl = model.DonationUrl,
                MascotImageUrl = model.MascotImageUrl,
                BannerUrl = model.BannerUrl,
                ServerErrorImageUrl = model.ServerErrorImageUrl,
                InfoImageUrl = model.InfoImageUrl,
                NotFoundImageUrl = model.NotFoundImageUrl,
                IconUrl = model.IconUrl,
                BackgroundImageUrl = model.BackgroundImageUrl,
                ImpressumUrl = model.ImpressumUrl,
                PrivacyPolicyUrl = model.PrivacyPolicyUrl,
                InquiryUrl = model.InquiryUrl
            },
            EnableAchievements = model.EnableAchievements,
            EnableEmail = model.EnableEmail,
            EnableServiceWorker = model.EnableServiceWorker,
            TranslatorAvailable = model.TranslatorAvailable,
            ThemeColor = model.ThemeColor
        };
        
        AdminMeta = meta;
    }
    
    public async Task UpdateAsync()
    {
        var model = await Misskey.ApiClient.GetMetaAsync();

        if (model == null)
            return;
        
        Update(model);
    }

    public async Task ModifyAsync(Action<InstanceProperties> func)
    {
        bool success = await InstanceHelper.ModifyMetaAsync(Misskey, func);

        if (!success)
            return;

        await UpdateAsync();
        await GetAdminMetaAsync();
    }

    public async Task<AdminMeta> GetAdminMetaAsync()
    {
        var model = await Misskey.ApiClient.GetAdminMetaAsync();

        if (model == null)
            throw new InvalidOperationException("You are not authorized to fetch admin meta");
        
        Update(model);
        return AdminMeta!;
    }
    
    public Task GetOnlineUsersCountAsync()
    {
        throw new NotImplementedException();
    }

    public Task GetServerInfoAsync()
    {
        throw new NotImplementedException();
    }

    public Task GetStatsAsync()
    {
        throw new NotImplementedException();
    }

    public Task PingAsync()
    {
        throw new NotImplementedException();
    }

    IUser ISelfInstance.InstanceActor => InstanceActor;
    IMeta ISelfInstance.Meta => Meta;
}