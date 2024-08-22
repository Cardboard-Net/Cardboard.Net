using System;
using RestSharp;

namespace Cardboard.Net.Rest.Interceptors;

public class RawJsonInterceptor : RestSharp.Interceptors.Interceptor 
{
    public override ValueTask BeforeDeserialization(RestResponse response, CancellationToken cancellationToken)
    {
        // yes. if it works it works
        Console.WriteLine(response.Content);
        return base.BeforeDeserialization(response, cancellationToken);
    }
}