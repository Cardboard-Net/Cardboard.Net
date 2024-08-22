namespace Cardboard.Net.Rest;

internal static class Endpoints
{
    public const string NOTE_CREATE = "/api/notes/create";
    public const string NOTE_DELETE = "/api/notes/delete";
    public const string NOTE_SHOW = "/api/notes/show";
    public const string NOTE_REACTS_CREATE = "/api/notes/reactions/create";
    public const string NOTE_REACTS_DELETE = "/api/notes/reactions/delete";
    public const string USERS_SHOW = "/api/users/show";
    public const string USERS_SEARCH = "/api/users/search";
    public const string FOLLOW_CREATE = "/api/following/create";
    public const string FOLLOW_DELETE = "/api/following/delete";
    public const string INSTANCE_USERS_ONLINE = "/api/get-online-users-count";
    public const string INSTANCE_PING = "/api/ping";
    public const string INSTANCE_META = "/api/meta";
    public const string INSTANCE_STATS = "/api/stats";
    public const string ADMIN_INSTANCE_META = "/api/admin/meta";
}