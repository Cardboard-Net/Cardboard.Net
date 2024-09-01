namespace Cardboard.Announcements;

/// <summary>
///     Announcements as seen by admin/announcements/list
/// </summary>
public interface IAdminAnnouncement : IAnnouncement, IDeletable
{
    /// <summary>
    ///     The amount of times this announcement has been read
    /// </summary>
    int Reads { get; }
}