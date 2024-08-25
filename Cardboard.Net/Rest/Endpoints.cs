namespace Cardboard.Net.Rest;

internal static class Endpoints
{
    #region Self

    public const string SELF_USER = "/api/i";
    public const string SELF_UPDATE = "/api/i/update";
    public const string SELF_FAVORITES = "/api/i/favorites";
    public const string SELF_ACHIEVEMENT_CLAIM = "/api/i/claim-achievement";
    public const string SELF_READ_ANNOUNCEMENT = "/api/i/read-announcement";
    
    #endregion
    
    #region Notes
    
    public const string NOTE_CREATE = "/api/notes/create";
    public const string NOTE_DELETE = "/api/notes/delete";
    public const string NOTE_SHOW = "/api/notes/show";
    public const string NOTE_REACTS_CREATE = "/api/notes/reactions/create";
    public const string NOTE_REACTS_DELETE = "/api/notes/reactions/delete";
    
    #endregion
    
    #region Users
    
    public const string USERS_SHOW = "/api/users/show";
    public const string USERS_SEARCH = "/api/users/search";
    public const string ADMIN_SILENCE_USER = "/api/admin/silence-user";
    public const string ADMIN_UNSILENCE_USER = "/api/admin/unsilence-user";
    public const string ADMIN_SUSPEND_USER = "/api/admin/suspend-user";
    public const string ADMIN_UNSUSPEND_USER = "/api/admin/unsuspend-user";
    public const string FOLLOW_CREATE = "/api/following/create";
    public const string FOLLOW_DELETE = "/api/following/delete";
    public const string PIN_NOTE = "/api/i/pin";
    public const string UNPIN_NOTE = "/api/i/unpin";
    
    #endregion
    
    #region Emoji

    public const string EMOJI = "/api/emoji";
    
    #endregion
    
    #region AvatarDecorations

    public const string ADMIN_AVATAR_DECORATIONS_LIST = "/api/admin/avatar-decorations/list";
    public const string AVATAR_DECORATIONS_GET = "/api/get-avatar-decorations";
    
    #endregion
    
    #region Drive
    
    public const string DRIVE = "/api/drive";
    public const string DRIVE_FILE_SHOW = "/api/drive/files/show";
    public const string DRIVE_FILE_CREATE = "/api/drive/files/create";
    public const string DRIVE_FILE_DELETE = "/api/drive/files/delete";
    public const string DRIVE_FOLDERS = "/api/drive/folders";
    public const string DRIVE_FOLDER_SHOW = "/api/drive/folders/show";
    public const string DRIVE_FOLDER_FIND = "/api/drive/folders/create";
    public const string DRIVE_FOLDER_CREATE = "/api/drive/folders/create";
    public const string DRIVE_FOLDER_DELETE = "/api/drive/folders/delete";
    
    #endregion
    
    #region HomeInstance
    
    public const string INSTANCE_USERS_ONLINE = "/api/get-online-users-count";
    public const string INSTANCE_PING = "/api/ping";
    public const string INSTANCE_META = "/api/meta";
    public const string INSTANCE_STATS = "/api/stats";
    public const string INSTANCE_SERVERINFO = "/api/server-info";
    public const string INSTANCE_ANNOUNCEMENTS = "/api/announcements";
    public const string INSTANCE_ANNOUNCEMENTS_SHOW = "/api/announcements/show";
    public const string ADMIN_INSTANCE_ANNOUNCEMENTS_DELETE = "/api/announcements/delete";
    public const string ADMIN_INSTANCE_ANNOUNCEMENTS_CREATE = "/api/announcements/create";
    public const string ADMIN_INSTANCE_ANNOUNCEMENTS_UPDATE = "/api/announcements/update";
    public const string ADMIN_INSTANCE_SERVERINFO = "/api/admin/server-info";
    public const string ADMIN_INSTANCE_META = "/api/admin/meta";
    public const string ADMIN_USER_IPS = "/api/admin/get-user-ips";
    public const string ADMIN_ACCOUNTS_DELETE = "/api/admin/accounts/delete";
    public const string ADMIN_RELAY_ADD = "/api/admin/relays/add";
    public const string ADMIN_RELAY_LIST = "/api/admin/relays/list";
    public const string ADMIN_RELAY_REMOVE = "/api/admin/relays/remove";

    #endregion
}