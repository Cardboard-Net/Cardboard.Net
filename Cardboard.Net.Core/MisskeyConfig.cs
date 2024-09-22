using Newtonsoft.Json;

namespace Cardboard;

public class MisskeyConfig
{
    /// <summary>
    ///     Gets the user agent Cardboard.Net utilizes for clients
    /// </summary>
    /// <returns>
    ///     The user agent used in each request
    /// </returns>
    public string UserAgent { get; } = "MisskeyBot (https://github.com/Cardboard-Net/Cardboard.Net)";

    /// <summary>
    ///     The settings for json serialization
    /// </summary>
    public JsonSerializerSettings SerializerSettings { get; } = new JsonSerializerSettings();
    
    /// <summary>
    ///     Returns the maximum amount of poll choices
    /// </summary>
    /// <returns>
    ///     The maximum amount of poll choices
    /// </returns>
    public const int MaxPollChoices = 10;
    
    /// <summary>
    ///     Returns the maximum amount of files per note
    /// </summary>
    /// <returns>
    ///     The maximum amount of files per note 
    /// </returns>
    public const int MaxFilesPerNote = 16;

    /// <summary>
    ///     Returns the maximum limit of announcements per announcement query 
    /// </summary>
    /// <returns>
    ///     The maximum amount of announcements per query
    /// </returns>
    public const int MaxAnnouncementsPerBatch = 100;

    public const int MaxInvitesPerBatch = 100;

    public const int MaxAbuseReportsPerBatch = 100;
    
    public const int MaxAdsPerBatch = 100;

    public const int MaxAvatarDecorationsPerBatch = 100;
}