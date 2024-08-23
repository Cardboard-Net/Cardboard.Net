using RestSharp;

namespace Cardboard.Net.Rest.Interceptors;

public class StatusInterceptor : RestSharp.Interceptors.Interceptor 
{
    public override ValueTask AfterRequest(RestResponse response, CancellationToken cancellationToken)
    {
        Console.WriteLine($"{response.StatusCode} {response.Request.Method} {response.Request.Resource}");
        return base.AfterRequest(response, cancellationToken);
    }
}