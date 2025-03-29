namespace Cardboard;

public enum ConnectionState : byte
{
    /// <summary> The client has disconnected from the Misskey Instance. </summary>
    Disconnected,
    /// <summary> The client is connecting to Misskey Instance. </summary>
    Connecting,
    /// <summary> The client has established a connection to Misskey Instance. </summary>
    Connected,
    /// <summary> The client is disconnecting from Misskey Instance. </summary>
    Disconnecting
}