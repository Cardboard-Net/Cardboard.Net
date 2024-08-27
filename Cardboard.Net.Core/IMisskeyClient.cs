namespace Cardboard;

public interface IMisskeyClient : IDisposable
{
    /// <summary>
    /// Performs initialization, if it's not a websocket client this just
    /// populates fields such as CurrentUser and CurrentInstance
    /// </summary>
    /// <returns></returns>
    Task StartAsync();
    
    /// <summary>
    /// Disposes of anything that needs disposal, such as ending a websocket
    /// connection
    /// </summary>
    /// <returns></returns>
    Task StopAsync();
}