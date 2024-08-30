# cardboard.NET
A C# library for interfacing with Misskey (and forks). API has been tested against a sharkey instance. Library was inspired by the following projects: [kitsu-org/cardboard](https://github.com/kitsu-org/cardboard) & [discord-net/discord.net](https://github.com/discord-net/Discord.Net)


# Using
```
MisskeyRestClient client = new MisskeyRestClient();
await client.LoginAsync("", new Uri("https://transfem.social/"));
```

TODO: Make more advanced examples as the library develops, include them in docs.