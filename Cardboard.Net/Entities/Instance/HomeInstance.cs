using Cardboard.Net.Clients;
using Cardboard.Net.Entities.Users;

namespace Cardboard.Net.Entities;

/// <summary>
/// The instance the account resides on
/// </summary>
public class HomeInstance
{
    internal BaseMisskeyClient Misskey { get; set; }
    
    public Meta? Meta { get; internal set; }

    /// <summary>
    /// Updates the meta for this class, returning the meta object it grabbed
    /// </summary>
    /// <returns></returns>
    public async Task<Meta> RefreshMetaAsync()
        => this.Meta = await this.Misskey.ApiClient.GetMetaAsync();
    
    public Stats? Stats { get; internal set; }
    
    /// <summary>
    /// Updates the stats for this class, returning the stats object it grabbed
    /// </summary>
    /// <returns></returns>
    public async Task<Stats> RefreshStatsAsync()
        => this.Stats = await this.Misskey.ApiClient.GetStatsAsync();
    
    /// <summary>
    /// Gets a list of ips for a given user
    /// </summary>
    /// <param name="userId">The user id</param>
    /// <returns></returns>
    public async Task<IReadOnlyList<AdminUserIp>> GetUserIpsAsync(string userId)
        => await this.Misskey.ApiClient.GetUserIpsAsync(userId);
    
    /// <summary>
    /// Add a relay to the server
    /// </summary>
    /// <param name="inbox">The url to the relay's inbox</param>
    /// <returns></returns>
    public async Task<Relay?> AddRelayAsync(Uri inbox)
        => await this.Misskey.ApiClient.AddRelayAsync(inbox);
    
    /// <summary>
    /// List all relays on the instance
    /// </summary>
    /// <returns></returns>
    public async Task<IReadOnlyList<Relay>> GetRelaysAsync()
        => await this.Misskey.ApiClient.GetRelaysAsync();

    /// <summary>
    /// Removes a relay from the server
    /// </summary>
    /// <param name="inbox"></param>
    public async Task DeleteRelayAsync(Uri inbox)
        => await this.Misskey.ApiClient.DeleteRelayAsync(inbox);

    /// <summary>
    /// Gets the server info from the instance
    /// </summary>
    /// <returns></returns>
    public async Task<ServerInfo?> GetServerInfoAsync()
        => await this.Misskey.ApiClient.GetServerInfoAsync();

    /// <summary>
    /// Gets the admin server info from the instance
    /// </summary>
    /// <returns></returns>
    public async Task<AdminServerInfo?> GetAdminServerInfoAsync()
        => await this.Misskey.ApiClient.GetAdminServerInfoAsync();
    
    /// <summary>
    /// Deletes a user
    /// </summary>
    /// <param name="userId">The id of the user to delete</param>
    /// <param name="selfdelete">overrides default behavior (throwing an exception) to allow user to delete itself</param>
    public async Task DeleteUserAsync(string userId, bool selfdelete = false)
        => await this.Misskey.ApiClient.DeleteUserAsync(userId, selfdelete);
    
    //TODO: Implement
    public async Task<Announcement> GetAnnouncementAsync(string announcementId)
        => throw new NotImplementedException();
    
    //TODO: Implement
    public async Task<IReadOnlyList<Announcement>> GetAnnouncementsAsync()
        => throw new NotImplementedException();
    
    //TODO: Implement
    public async Task<Invite> CreateInviteAsync()
        => throw new NotImplementedException();
    
    //TODO: Implement
    public async Task<IReadOnlyList<Invite>> GetInvitesAsync()
        => throw new NotImplementedException();
    
    //TODO: Implement
    public async Task DeleteInviteAsync(string inviteId)
        => throw new NotImplementedException();
     
    //TODO: Implement
    public async Task DeleteInviteAsync(Invite invite)
        => throw new NotImplementedException();
}