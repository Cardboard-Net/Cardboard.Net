using System.Runtime.CompilerServices;
using Cardboard.Net.Rest;
using Cardboard.Net.Rest.Interceptors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cardboard.Net.Clients;

public static class MisskeyClientExtensions
{
    public static IServiceCollection AddMisskeyClient(
        this IServiceCollection services, 
        IConfiguration configurationSection)
    {
        services.AddOptions<MisskeyClientOptions>()
            .Bind(configurationSection)
            .ValidateDataAnnotations();
        RegisterServices(services);
        
        return services;
    }

    public static IServiceCollection AddMisskeyClient(
        this IServiceCollection services,
        Action<MisskeyClientOptions> configurationOptions)
    {
        services.AddOptions<MisskeyClientOptions>()
            .Configure(configurationOptions)
            .ValidateDataAnnotations();
        RegisterServices(services);
        
        return services;
    }

    public static IServiceCollection AddMisskeyClient(
        this IServiceCollection services,
        MisskeyClientOptions configurationOptions)
    {
        services.AddOptions<MisskeyClientOptions>()
            .Configure(t =>
            {
                t.Token = configurationOptions.Token;
                t.Host = configurationOptions.Host;
            })
            .ValidateDataAnnotations();
        
        RegisterServices(services);
        return services;
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IMisskeyClient, MisskeyClient>();
        services.AddSingleton<MisskeyApiClient>();
        services.AddSingleton<RawJsonInterceptor>();
        services.AddSingleton<StatusInterceptor>();
    }
}