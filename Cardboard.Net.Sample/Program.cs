using Cardboard;
using Cardboard.Net.Rest;
using Cardboard.Rest;

MisskeyRestClient client = new MisskeyRestClient(new MisskeyConfig());
await client.LoginAsync("no", new Uri("https://transfem.social/"));

// with love <3
RestUser user = await client.GetUserAsync("9q2zjh6ygage07bk");
Console.WriteLine(user.Username); 