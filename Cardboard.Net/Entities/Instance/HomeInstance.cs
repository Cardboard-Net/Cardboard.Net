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