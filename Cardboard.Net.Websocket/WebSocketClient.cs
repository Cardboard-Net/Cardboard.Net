using System.Collections.ObjectModel;
using System.Net.WebSockets;
using System.Text;

namespace Cardboard.Net.Websocket;

public class WebSocketClient : IWebSocketClient
{

    private const int OutgoingChunkSize = 16384;
    private const int IncomingChunkSize = 16384;

    public IReadOnlyDictionary<string, string> DefaultHeaders { get; }

    public bool IsConnected 
        => this.IsConnected;

    private readonly Dictionary<string, string> defaultHeaders;

    private Task receiverTask;
    private CancellationTokenSource receiverTokenSource;
    private CancellationToken receiverToken;
    private readonly SemaphoreSlim senderLock;

    private CancellationTokenSource socketTokenSource;
    private CancellationToken socketToken;
    private ClientWebSocket ws;

    private volatile bool isClientClose = false;
    private volatile bool isConnected = false;
    private bool isDisposed = false;

    public WebSocketClient()
    {
        this.defaultHeaders = [];
        this.DefaultHeaders = new ReadOnlyDictionary<string, string>(this.defaultHeaders);

        this.receiverTokenSource = null;
        this.receiverToken = CancellationToken.None;
        this.senderLock = new SemaphoreSlim(1);

        this.socketTokenSource = null;
        this.socketToken = CancellationToken.None;
    }

    public async Task ConnectAsync(Uri uri)
    {
        // Disconnect first
        try
        {
            await DisconnectAsync();
        }
        catch { }

        // Disallow sending messages
        await this.senderLock.WaitAsync();

        try
        {
            // This can be null at this point
            this.receiverTokenSource?.Dispose();
            this.socketTokenSource?.Dispose();

            this.ws?.Dispose();
            this.ws = new ClientWebSocket();
            this.ws.Options.KeepAliveInterval = TimeSpan.Zero;
            if (this.defaultHeaders != null)
            {
                foreach ((string k, string v) in this.defaultHeaders)
                {
                    this.ws.Options.SetRequestHeader(k, v);
                }
            }

            this.receiverTokenSource = new CancellationTokenSource();
            this.receiverToken = this.receiverTokenSource.Token;

            this.socketTokenSource = new CancellationTokenSource();
            this.socketToken = this.socketTokenSource.Token;

            this.isClientClose = false;
            this.isDisposed = false;
            await this.ws.ConnectAsync(uri, this.socketToken);
            this.receiverTask = Task.Run(ReceiverLoopAsync, this.receiverToken);
        }
        finally
        {
            this.senderLock.Release();
        }
    }

    public async Task DisconnectAsync()
    {
        // Ensure that messages cannot be sent
        await this.senderLock.WaitAsync();

        try
        {
            this.isClientClose = true;
            if (this.ws != null && (this.ws.State == WebSocketState.Open || this.ws.State == WebSocketState.CloseReceived))
            {
                await this.ws.CloseOutputAsync((WebSocketCloseStatus)1000, "", CancellationToken.None);
            }

            if (this.receiverTask != null)
            {
                await this.receiverTask; // Ensure that receiving completed
            }

            if (this.isConnected)
            {
                this.isConnected = false;
            }

            if (!this.isDisposed)
            {
                // Cancel all running tasks
                if (this.socketToken.CanBeCanceled)
                {
                    this.socketTokenSource?.Cancel();
                }

                this.socketTokenSource?.Dispose();

                if (this.receiverToken.CanBeCanceled)
                {
                    this.receiverTokenSource?.Cancel();
                }

                this.receiverTokenSource?.Dispose();

                this.isDisposed = true;
            }
        }
        catch { }
        finally
        {
            this.senderLock.Release();
        }
    }

    public async Task SendMessageAsync(string message)
    {
        if (this.ws == null)
        {
            return;
        }

        if (this.ws.State is not WebSocketState.Open and not WebSocketState.CloseReceived)
        {
            return;
        }

        byte[] bytes = Encoding.UTF8.GetBytes(message);
        await this.senderLock.WaitAsync();
        try
        {
            int len = bytes.Length;
            int segCount = len / OutgoingChunkSize;
            if (len % OutgoingChunkSize != 0)
            {
                segCount++;
            }

            for (int i = 0; i < segCount; i++)
            {
                int segStart = OutgoingChunkSize * i;
                int segLen = Math.Min(OutgoingChunkSize, len - segStart);

                await this.ws.SendAsync(new ArraySegment<byte>(bytes, segStart, segLen), WebSocketMessageType.Text, i == segCount - 1, CancellationToken.None);
            }
        }
        finally
        {
            this.senderLock.Release();
        }
    }

    public bool AddDefaultHeader(string name, string value)
    {
        this.defaultHeaders[name] = value;
        return true;
    }

    public bool RemoveDefaultHeader(string name)
        => this.defaultHeaders.Remove(name);

    internal async Task ReceiverLoopAsync()
    {
        await Task.Yield();

        CancellationToken token = this.receiverToken;
        ArraySegment<byte> buffer = new(new byte[IncomingChunkSize]);

        try
        {
            using MemoryStream bs = new();
            while (!token.IsCancellationRequested)
            {
                // See https://github.com/RogueException/Discord.Net/commit/ac389f5f6823e3a720aedd81b7805adbdd78b66d
                // for explanation on the cancellation token

                WebSocketReceiveResult result;
                byte[] resultBytes;
                do
                {
                    result = await this.ws.ReceiveAsync(buffer, CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        break;
                    }

                    bs.Write(buffer.Array, 0, result.Count);
                }
                while (!result.EndOfMessage);

                resultBytes = new byte[bs.Length];
                bs.Position = 0;
                bs.Read(resultBytes, 0, resultBytes.Length);
                bs.Position = 0;
                bs.SetLength(0);

                if (!this.isConnected && result.MessageType != WebSocketMessageType.Close)
                {
                    this.isConnected = true;
                }

                if (result.MessageType == WebSocketMessageType.Binary)
                {

                }
                else if (result.MessageType == WebSocketMessageType.Text)
                {

                }
                else // close
                {
                    if (!this.isClientClose)
                    {
                        WebSocketCloseStatus code = result.CloseStatus.Value;
                        code = code is WebSocketCloseStatus.NormalClosure or WebSocketCloseStatus.EndpointUnavailable
                            ? (WebSocketCloseStatus)4000
                            : code;

                        await this.ws.CloseOutputAsync(code, result.CloseStatusDescription, CancellationToken.None);
                    }
                    break;
                }
            }
        }
        catch (Exception ex)
        {
        }

        // Don't await or you deadlock
        // DisconnectAsync waits for this method
        _ = DisconnectAsync();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}