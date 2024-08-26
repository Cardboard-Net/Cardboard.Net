using Microsoft.Extensions.Logging;
using RestSharp;

namespace Cardboard.Net.Rest.Interceptors;

public class RawJsonInterceptor(ILogger<RawJsonInterceptor> logger) : RestSharp.Interceptors.Interceptor
{
    private ILogger Logger { get; } = logger;

    public override ValueTask BeforeDeserialization(RestResponse response, CancellationToken cancellationToken)
    {
        Logger.LogDebug("Received from server: {data}", response.Content);
        return base.BeforeDeserialization(response, cancellationToken);
    }
}