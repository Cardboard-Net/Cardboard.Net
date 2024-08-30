using Cardboard;
using Cardboard.Net.Rest;
using Cardboard.Notes;
using Cardboard.Rest;
using Cardboard.Rest.Notes;

MisskeyRestClient client = new MisskeyRestClient(new MisskeyConfig());
await client.LoginAsync("no", new Uri("https://transfem.social/"));

// with love <3
RestUser user = await client.GetUserAsync("9q2zjh6ygage07bk");
Console.WriteLine(user.Username);

PollBuilder poll = new PollBuilder();
poll.AddChoice("Red");
poll.AddChoice("Green");
poll.AddChoice("Blue");
poll.AddChoice("Other");
poll.ExpiresAfter = TimeSpan.FromDays(7);
RestNote? hello = await client.CreateNoteAsync("What's your favorite color?", poll: poll.Build());