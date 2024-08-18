# cardboard.NET
a C# port of cardboard

# TODO:
* ### Work on rest client, I want to be able to POST/GET things to check entities
    * /api/notes/create
    * /api/notes/delete
    * PollBuilder for creating polls
    * PageBuilder for creating pages
* ### Work on websocket client, and the event dispatch + handling
    * Note creation event
    * Mention event
    * Follow event
    * Unfollow event (apparently?)
    * Figure out the rest of the events sent
* ### Work on creating a logger
    * I think that https://learn.microsoft.com/en-us/dotnet/core/extensions/logging might be the way to go since I am wanting to use DependencyInjection for registering services like the CommandHandler. Seems like this would be good to use, might be way better than discord.NET's approach. 
* ### Find contributors