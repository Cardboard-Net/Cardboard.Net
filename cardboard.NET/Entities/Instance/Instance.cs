namespace cardboard
{
    /// <summary>
    /// Types for sorting users
    /// </summary>
    public enum UserSortType
    {
        /// <summary>
        /// Following, ascending
        /// </summary>
        FollowerAsc,
        /// <summary>
        /// Following, descending
        /// </summary>
        FollowerDesc,
        /// <summary>
        /// Created At, ascending
        /// </summary>
        CreatedAtAsc,
        /// <summary>
        /// Created at, descending
        /// </summary>
        CreatedAtDesc,
        /// <summary>
        /// Updated at, ascending
        /// </summary>
        UpdatedAtAsc,
        /// <summary>
        /// Updated at, descending
        /// </summary>
        UpdatedAtDesc
    }

    /// <summary>
    /// State of the user
    /// </summary>
    public enum UserStateType
    {
        /// <summary>
        /// All users
        /// </summary>
        All,
        /// <summary>
        /// Alive users
        /// </summary>
        Alive
    }

    /// <summary>
    /// Origin of the user
    /// </summary>
    public enum UserOriginType
    {
        /// <summary>
        /// Both Local + Remote
        /// </summary>
        Combined,
        /// <summary>
        /// Local only
        /// </summary>
        Local,
        /// <summary>
        /// Remote only
        /// </summary>
        Remote
    }

    public class Instance 
    {
        public List<Announcement> GetAnnouncements()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an announcement from the current instance
        /// </summary>
        /// <param name="id">id of the announcement</param>
        /// <returns>An announcement object</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Announcement GetAnnouncement(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the amount of currently online users
        /// </summary>
        /// <returns>An integer representing the total online users</returns>
        /// <exception cref="NotImplementedException"></exception>
        public int GetOnlineUsersCount()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates an invite
        /// </summary>
        /// <returns>An invite object</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Invite CreateInvite()
        {
            throw new NotImplementedException();
        }

        public List<Invite> GetInvites(int limit)
        {
            throw new NotImplementedException();
        }

        public List<Invite> GetInvites(int limit, string sinceId)
        {
            throw new NotImplementedException();
        }
        public List<Invite> GetInvites(int limit, string sinceId, string untilId)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers(int limit = 10)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers(int limit = 10, int offset = 0)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers(UserSortType sort, int limit = 10, int offset = 0)
        {
            throw new NotImplementedException();
        }
    }
}