using Cardboard.Antennas;
using Cardboard.Charts;
using Cardboard.Logging;
using Cardboard.Net.Rest.Interceptors;
using Cardboard.Notes;
using Cardboard.Rest;
using Cardboard.Rest.Announcements;
using Cardboard.Rest.Antennas;
using Cardboard.Rest.Drives;
using Cardboard.Rest.Instances;
using Cardboard.Rest.Notes;
using Cardboard.Users;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cardboard.Net.Rest;

public class MisskeyRestClient : BaseMisskeyClient
{
    public new RestSelfUser CurrentUser { get => base.CurrentUser as RestSelfUser; internal set => base.CurrentUser = value; }
    public new RestSelfInstance CurrentInstance{ get => base.CurrentInstance as RestSelfInstance; internal set => base.CurrentInstance = value; }
    public IServiceProvider ServiceProvider { get; internal set; }
    
    public MisskeyRestClient() : this(new MisskeyConfig()) { }

    public MisskeyRestClient(MisskeyConfig config) : base(config)
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<MisskeyRestApiClient>().AddOptions<MisskeyConfig>();
        serviceCollection.AddSingleton<RequestInterceptor>();
        serviceCollection.AddLogging(builder => builder.AddProvider(new DefaultLoggerProvider()).SetMinimumLevel(LogLevel.Debug));
        ServiceProvider = serviceCollection.BuildServiceProvider();
        this.Logger = ServiceProvider.GetRequiredService<ILogger<MisskeyRestClient>>();
        this.ApiClient = ServiceProvider.GetRequiredService<MisskeyRestApiClient>();
    }

    internal MisskeyRestClient(MisskeyConfig config, MisskeyRestApiClient client) : base(config)
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<MisskeyRestApiClient>(client);
        serviceCollection.AddSingleton<RequestInterceptor>();
        serviceCollection.AddLogging(builder => builder.AddProvider(new DefaultLoggerProvider()).SetMinimumLevel(LogLevel.Debug));
        ServiceProvider = serviceCollection.BuildServiceProvider();
        this.Logger = ServiceProvider.GetRequiredService<ILogger<MisskeyRestClient>>();
        this.ApiClient = ServiceProvider.GetRequiredService<MisskeyRestApiClient>();
    }

    internal override async Task OnLoginAsync(string token, Uri baseUrl)
    {
        CurrentUser = RestSelfUser.Create(this, ApiClient.FirstLoginUser);
        
        Logger.LogInformation($"Logged in as @{CurrentUser.Username} ({CurrentUser.Id})");
        
        var meta = await ApiClient.GetMetaAsync();
        var model = await ApiClient.GetUserAsync("instance.actor", null);

        if (model == null || meta == null)
            return;
        
        CurrentInstance = RestSelfInstance.Create(this, meta, RestInstanceActor.Create(this, model));
        
        Logger.LogInformation($"Current instance is {CurrentInstance.Meta.Url}");
        Logger.LogInformation($"Found @{CurrentInstance.InstanceActor.Username} ({CurrentInstance.Id})");
    }
    
    #region Announcements

    public async Task<RestUserAnnouncement?> GetAnnouncementAsync(string announcementId)
        => await AnnouncementHelper.GetAnnouncementAsync(this, announcementId);

    public async Task<IReadOnlyCollection<RestUserAnnouncement>> GetAnnouncementsAsync()
        => await AnnouncementHelper.GetAnnouncementsAsync(this);
    
    #endregion
    
    #region Antennas

    public async Task<RestAntenna?> GetAntennaAsync(string antennaId)
        => await AntennaHelper.GetAntennaAsync(this, antennaId);

    public async Task<RestAntenna> CreateAntennaAsync
    (
        string name,
        AntennaSourceType source,
        string[] keywords,
        string[]? userIds = null,
        bool withReplies = false,
        bool withFiles = false,
        string? userListId = null,
        string[]? excludeKeywords = null,
        bool caseSensitive = false,
        bool? localOnly = null,
        bool? excludeBots = null
    )
    {
        RestAntenna? antenna = await AntennaHelper.CreateAntennaAsync
        (
            this,
            name,
            source,
            keywords, 
            userIds, 
            withReplies, 
            withFiles, 
            userListId, 
            excludeKeywords, 
            caseSensitive, 
            localOnly, 
            excludeBots
        );
        
        if (antenna == null)
            throw new InvalidOperationException("unable to create antenna");

        return antenna;
    }
    
    #endregion
    
    #region Charts

    public async Task<ActiveUserChart> GetUserChartAsync(ChartType span, int? limit = null, int? offset = null)
        => await ClientHelper.GetActiveUserChartAsync(this, span, limit, offset);

    public async Task<ApRequestChart> GetApRequestChartAsync(ChartType span, int? limit = null, int? offset = null)
        => await ClientHelper.GetApRequestChartAsync(this, span, limit, offset);

    public async Task<DriveChart> GetDriveChartAsync(ChartType span, int? limit = null, int? offset = null)
        => await ClientHelper.GetDriveChartAsync(this, span, limit, offset);

    public async Task<UsersChart> GetUsersChart(ChartType span, int? limit = null, int? offset = null)
        => await ClientHelper.GetUsersChartAsync(this, span, limit, offset);
    
    #endregion
    
    #region Notes

    public async Task<RestNote?> GetNoteAsync(string noteId)
        => await NoteHelper.GetNoteAsync(this, noteId);

    public async Task<RestNote> CreateNoteAsync
    (
        string text,
        string? contentWarning = null,
        bool? localOnly = null,
        AcceptanceType? acceptanceType = null,
        bool? noExtractMentions = null,
        bool? noExtractHashtags = null,
        bool? noExtractEmojis = null,
        VisibilityType? visibilityType = null,
        Poll? poll = null
    )
    {
        RestNote? note = await NoteHelper.CreateNoteAsync
        (
            this, 
            text: text, 
            contentWarning: contentWarning, 
            localOnly: localOnly,
            acceptanceType: acceptanceType,
            noExtractMentions: noExtractMentions,
            noExtractHashtags: noExtractHashtags,
            noExtractEmojis: noExtractEmojis,
            visibilityType: visibilityType,
            poll: poll
        );

        if (note == null)
            throw new InvalidOperationException("unable to create note");

        return note;
    }

    public async Task<RestNote> CreateDmNoteAsync
    (
        string text,
        IUser[] dmRecipients,
        string? contentWarning = null,
        bool? localOnly = null,
        AcceptanceType? acceptanceType = null,
        bool? noExtractMentions = null,
        bool? noExtractHashtags = null,
        bool? noExtractEmojis = null,
        Poll? poll = null
    )
        => await CreateDmNoteAsync
            (
                text, 
                dmRecipients.Select(x => x.Id).ToArray(), 
                contentWarning, 
                localOnly, 
                acceptanceType, 
                noExtractMentions, 
                noExtractHashtags,
                noExtractEmojis, 
                poll
            );
    
    public async Task<RestNote> CreateDmNoteAsync
    (
        string text,
        string[] dmRecipients,
        string? contentWarning = null,
        bool? localOnly = null,
        AcceptanceType? acceptanceType = null,
        bool? noExtractMentions = null,
        bool? noExtractHashtags = null,
        bool? noExtractEmojis = null,
        Poll? poll = null
    )
    {
        RestNote? note = await NoteHelper.CreateDmNoteAsync
        (
            this,
            text: text,
            dmRecipients: dmRecipients,
            contentWarning: contentWarning, 
            localOnly: localOnly,
            acceptanceType: acceptanceType,
            noExtractMentions: noExtractMentions,
            noExtractHashtags: noExtractHashtags,
            noExtractEmojis: noExtractEmojis,
            poll: poll
        );

        if (note == null)
            throw new InvalidOperationException("unable to create note");

        return note;
    }
    
    #endregion
    
    #region Users
    
    public async Task<RestUser?> GetUserAsync(string userId)
        => await ClientHelper.GetUserAsync(this, userId);

    public async Task<RestUser?> GetUserAsync(string username, Uri? host)
        => await ClientHelper.GetUserAsync(this, username, host);
    
    public async Task ReportUserAsync(string userId, string comment)
        => await ApiClient.ReportUserAsync(userId, comment);
    
    #endregion
    
    #region Files
    
    public async Task UploadFileAsync(Uri url, string? folderId = null, string? comment = null, string? marker = null,
        bool? isSensitive = false, bool force = false)
        => await ApiClient.UploadFileUriAsync(url, folderId, comment, marker, isSensitive, force);
    
    public async Task<RestDriveFile> GetFileAsync(string fileId)
        => await ClientHelper.GetDriveFileAsync(this, fileId);

    public async Task<RestDriveFile> GetFileAsync(Uri url)
        => await ClientHelper.GetDriveFileAsync(this, url);
    
    #endregion
}