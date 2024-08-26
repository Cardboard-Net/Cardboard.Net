// See https://aka.ms/new-console-template for more information

using Cardboard.Net.Clients;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddMisskeyClient(builder.Configuration.GetSection("misskey"));
builder.Services.AddHostedService<SomeService>();
var app = builder.Build();

// example of using this in a dependency injected context (ie. from the hosted service we registered in the container)
app.Run();

internal class SomeService : IHostedService
{
    private IMisskeyClient Client { get; }
    private ILogger Logger { get; }

    public SomeService(IMisskeyClient client, ILogger<SomeService> logger)
    {
        Client = client;
        Logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var post = await Client.GetNoteAsync("9xdykkc8a67e002j");
        Logger.LogInformation("Got note by {author}: {text}", post.AuthorId, post.Text);
        Logger.LogInformation("Current user: {user}", (await Client.GetCurrentUserAsync())?.Name);
        Logger.LogInformation("Current instance: {instance}", (await Client.GetCurrentInstanceAsync())?.Meta?.Name);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}