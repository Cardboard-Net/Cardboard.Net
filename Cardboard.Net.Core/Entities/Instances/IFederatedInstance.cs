namespace Cardboard.Instances;

/// <summary>
///     Represents a federated instance
/// </summary>
public interface IFederatedInstance : IMisskeyEntity
{
    /// <summary>
    ///     The date at which this instance was first retrieved at
    /// </summary>
    DateTime FirstRetrievedAt { get; }
    
    /// <summary>
    ///     The host of the instance
    /// </summary>
    Uri Host { get; }
    
    /// <summary>
    ///     The reported user count of the remote instance
    /// </summary>
    int UsersCount { get; }
    
    /// <summary>
    ///     The reported note count of the remote instance
    /// </summary>
    int NotesCount { get; }
    
    /// <summary>
    ///     Our instance's reported following count to the remote
    /// </summary>
    int FollowingCount { get; }
    
    /// <summary>
    ///     Our instance's reported followers count to the remote
    /// </summary>
    int FollowersCount { get; }
    
    /// <summary>
    ///     Whether the instance is responding
    /// </summary>
    bool IsNotResponding { get; }
    
    /// <summary>
    ///     Whether the instance is suspended
    /// </summary>
    bool IsSuspended { get; }
    
    /// <summary>
    ///     Whether the instance is blocked
    /// </summary>
    bool IsBlocked { get; }
    
    /// <summary>
    ///     Whether the instance is silenced
    /// </summary>
    bool IsSilenced { get; }
    
    /// <summary>
    ///     Whether the instance is marked as nsfw
    /// </summary>
    bool IsNSFW { get; }
    
    /// <summary>
    ///     The suspension state of the instance
    /// </summary>
    SuspensionStateType SuspensionState { get; }
    
    /// <summary>
    ///     The name of the software (if it reports it)
    /// </summary>
    string? SoftwareName { get; }
    
    /// <summary>
    ///     The version of the software (if it reports it)
    /// </summary>
    string? SoftwareVersion { get; }
    
    /// <summary>
    ///     Whether the remote instance has open registration
    /// </summary>
    bool? OpenRegistrations { get; }
    
    /// <summary>
    ///     The remote instance's name (if it reports it)
    /// </summary>
    string? Name { get; }
    
    /// <summary>
    ///     The remote instance's description (if it reports it)
    /// </summary>
    string? Description { get; }
    
    /// <summary>
    ///     The remote instance's maintainer (if it reports it)
    /// </summary>
    string? MaintainerName { get; }
    
    /// <summary>
    ///     The contact email for the remote instance (if it reports it)
    /// </summary>
    string? MaintainerEmail { get; }
    
    /// <summary>
    ///     The remote instance's icon url (if it reports it)
    /// </summary>
    Uri? IconUrl { get; }
    
    /// <summary>
    ///     The remote instance's favicon url (if it reports it)
    /// </summary>
    Uri? FaviconUrl { get; }
    
    /// <summary>
    ///     The remote instance's theme color (if it reports it)
    /// </summary>
    string? ThemeColor { get; }
    
    /// <summary>
    ///     When the remote instance was last updated (if ever)
    /// </summary>
    DateTime? LastUpdatedAt { get; }
    
    /// <summary>
    ///     When the last request was received from the remote instance to our
    ///     local instance
    /// </summary>
    DateTime? LastRequestReceivedAt { get; }
    
    /// <summary>
    ///     The moderation note of this instance
    /// </summary>
    /// <remarks>
    ///     I think this is only not null if the user is an admin, I would have
    /// to double-check
    /// </remarks>
    string? ModerationNote { get; }

    /// <summary>
    ///     Sends a request to local instance to refresh metadata of remote instance
    /// </summary>
    Task RefreshMetadata();
    
    /// <summary>
    ///     Silences the instance
    /// </summary>
    Task SilenceAsync();
    
    /// <summary>
    ///     Unsilences the instance
    /// </summary>
    Task UnsilenceAsync();
    
    /// <summary>
    ///     Suspends the instance
    /// </summary>
    Task SuspendAsync();
    
    /// <summary>
    ///     Unsuspends the instance
    /// </summary>
    Task UnsuspendAsync();
    
    /// <summary>
    ///     Marks instance as nsfw
    /// </summary>
    Task MarkNSFW();
    
    /// <summary>
    ///     Unmarks instance as nsfw
    /// </summary>
    Task UnmarkNSFW();

    /// <summary>
    ///     Deletes all federated files from this instance !!! THIS IS IRREVERSIBLE !!!
    /// </summary>
    Task DeleteAllFiles();

    /// <summary>
    ///     Destroys the follow relation to this instance !!! THIS IS IRREVERSIBLE !!!
    /// </summary>
    Task RemoveAllFollowing();
}