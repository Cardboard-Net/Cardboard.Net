namespace Cardboard.Net.Rest;

internal static class Endpoints
{
    #region Self

    public const string SELF_USER = "/api/i";
    public const string SELF_UPDATE = "/api/i/update";
    public const string SELF_FAVORITES = "/api/i/favorites";
    
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
    public const string FOLLOW_CREATE = "/api/following/create";
    public const string FOLLOW_DELETE = "/api/following/delete";
    
    #endregion
    
    #region Emoji

    public const string EMOJI = "/api/emoji";
    
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
    
    public const string INSTANCE_USERS_ONLINE = "/api/get-online-users-count";
    public const string INSTANCE_PING = "/api/ping";
    public const string INSTANCE_META = "/api/meta";
    public const string INSTANCE_STATS = "/api/stats";
    public const string ADMIN_INSTANCE_META = "/api/admin/meta";
}