using System.Buffers;
using System.Net;
using System.Text;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Cardboard.Net.Rest.Interceptors;

public class RequestInterceptor(ILogger<RequestInterceptor> logger) : RestSharp.Interceptors.Interceptor
{
    private ILogger Logger { get; } = logger;

    public override ValueTask BeforeHttpRequest(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
    {
        if (requestMessage.Method != HttpMethod.Post)
        {
            Logger.LogInformation($"\u2191 {requestMessage.Method} {requestMessage.RequestUri}");
            return base.BeforeHttpRequest(requestMessage, cancellationToken);
        }

        /*
         * We do not call reader.Close() as base will deal with the closing of
         * the stream. We have to reset the position after using the reader for
         * base to be able to read from the stream again. I spent 30+ minutes
         * dicking around with memorystream copying before finding out I can
         * just reset the position.
         */
        Stream content = requestMessage.Content!.ReadAsStream();
        byte[] rented = ArrayPool<byte>.Shared.Rent((int) content.Length);
        string body = string.Empty;
        try {
            content.ReadExactly(rented.AsSpan(0, (int) content.Length));
            content.Position = 0;
            body = Encoding.UTF8.GetString(rented.AsSpan(0, (int) content.Length));
        } finally {
            ArrayPool<byte>.Shared.Return(rented);
        }
        
        Logger.LogInformation($"\u2191 {requestMessage.Method} {requestMessage.RequestUri} {body}");

        return base.BeforeHttpRequest(requestMessage, cancellationToken);
    }
    
    public override ValueTask AfterHttpRequest(HttpResponseMessage responseMessage, CancellationToken cancellationToken)
    {
        if (responseMessage.StatusCode == HttpStatusCode.NoContent)
        {
            Logger.LogInformation($"\u2193 {responseMessage.StatusCode} {responseMessage.RequestMessage!.RequestUri}");
            return base.AfterHttpRequest(responseMessage, cancellationToken);
        }
        
        /*
         * We do not call reader.Close() as base will deal with the closing of
         * the stream. We have to reset the position after using the reader for
         * base to be able to read from the stream again. I spent 30+ minutes
         * dicking around with memorystream copying before finding out I can
         * just reset the position.
         */
        Stream content = responseMessage.Content!.ReadAsStream();
        byte[] rented = ArrayPool<byte>.Shared.Rent((int) content.Length);
        string body = string.Empty;
        try {
            content.ReadExactly(rented.AsSpan(0, (int) content.Length));
            content.Position = 0;
            body = Encoding.UTF8.GetString(rented.AsSpan(0, (int) content.Length));
        } finally {
            ArrayPool<byte>.Shared.Return(rented);
        }
        
        Logger.LogInformation($"\u2193 {responseMessage.StatusCode} {responseMessage.RequestMessage!.RequestUri} {body}");

        return base.AfterHttpRequest(responseMessage, cancellationToken);
    }

    public override ValueTask AfterRequest(RestResponse response, CancellationToken cancellationToken)
    {
        Logger.LogInformation($"{response.StatusCode} {response.Request.Method} {response.Request.Resource}");
        
        return base.AfterRequest(response, cancellationToken);
    }
}