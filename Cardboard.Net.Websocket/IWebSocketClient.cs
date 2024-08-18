using System;

namespace Cardboard.Net.Websocket;

public interface IWebSocketClient : IDisposable
{
    bool IsConnected { get; }
    Task ConnectAsync(Uri uri);
    Task DisconnectAsync();
}
