using Microsoft.Extensions.Logging;
using RestSharp;

namespace Cardboard.Net.Rest.Interceptors;

public class StatusInterceptor(ILogger<StatusInterceptor> logger)  : RestSharp.Interceptors.Interceptor 
{
    private ILogger Logger { get; } = logger;

    public override ValueTask AfterRequest(RestResponse response, CancellationToken cancellationToken)
    {
        Logger.LogDebug("Got HTTP {status} response on {method} {endpoint}", 
            response.StatusCode, response.Request.Method, response.Request.Resource);
        return base.AfterRequest(response, cancellationToken);
    }
}