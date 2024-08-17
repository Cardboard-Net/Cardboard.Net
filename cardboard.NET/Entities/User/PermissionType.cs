namespace cardboard
{
    /// <summary>
    /// Enum representing misskey permission types
    /// </summary>
    public enum PermissionType
    {
        // User Reads

        /// <summary>
        /// Access to read account properties
        /// </summary>
        ReadAccount,
        /// <summary>
        /// Access to read blocks
        /// </summary>
        ReadBlocks,
        /// <summary>
        /// Access to read drive
        /// </summary>
        ReadDrive,
        /// <summary>
        /// Access to read favorites
        /// </summary>
        ReadFavorites,
        /// <summary>
        /// Access to read following
        /// </summary>
        ReadFollowing,
        /// <summary>
        /// Access to read direct messages
        /// </summary>
        ReadMessaging,
        /// <summary>
        /// Access to read mutes
        /// </summary>
        ReadMutes,
        /// <summary>
        /// Access to read notifications
        /// </summary>
        ReadNotification,
        /// <summary>
        /// Access to read reactions
        /// </summary>
        ReadReaction,
        /// <summary>
        /// Access to read pages
        /// </summary>
        ReadPages,
        /// <summary>
        /// Access to read page likes
        /// </summary>
        ReadPageLikes,
        /// <summary>
        /// Access to read user groups
        /// </summary>
        ReadUserGroups,
        /// <summary>
        /// Access to read channels
        /// </summary>
        ReadChannels,
        /// <summary>
        /// Access to read gallery
        /// </summary>
        ReadGallery,
        /// <summary>
        ///  Access to read gallery likes
        /// </summary>
        ReadGalleryLikes,
        /// <summary>
        /// Access to read flash
        /// </summary>
        ReadFlash,
        /// <summary>
        /// Access to read flash likes
        /// </summary>
        ReadFlashLikes,
        /// <summary>
        /// Access to read invite codes
        /// </summary>
        ReadInviteCodes,
        /// <summary>
        /// Access to read clip favorites
        /// </summary>
        ReadClipFavorite,
        /// <summary>
        /// Access to read federation information
        /// </summary>
        ReadFederation,

        // User Writes
        
        /// <summary>
        ///  Access to write account properties
        /// </summary>
        WriteAccount,
        /// <summary>
        /// Access to write blocks
        /// </summary>
        WriteBlocks,
        /// <summary>
        /// Access to write drive
        /// </summary>
        WriteDrive,
        /// <summary>
        /// Access to write favorites
        /// </summary>
        WriteFavorites,
        /// <summary>
        /// Access to write following
        /// </summary>
        WriteFollowing,
        /// <summary>
        /// Access to write direct messages
        /// </summary>
        WriteMessaging,
        /// <summary>
        /// Access to create/modify mutes
        /// </summary>
        WriteMutes,
        /// <summary>
        /// Access to create notifications
        /// </summary>
        WriteNotification,
        /// <summary>
        /// Access to react
        /// </summary>
        WriteReaction,
        /// <summary>
        /// Access to vote in polls
        /// </summary>
        WriteVotes,
        /// <summary>
        /// Access to create pages
        /// </summary>
        WritePages,
        /// <summary>
        /// Access to like pages
        /// </summary>
        WritePageLikes,
        /// <summary>
        /// Access to create user groups
        /// </summary>
        WriteUserGroups,
        /// <summary>
        /// Access to create channels
        /// </summary>
        WriteChannels,
        /// <summary>
        /// Access to write gallery
        /// </summary>
        WriteGallery,
        /// <summary>
        /// Access to write gallery likes
        /// </summary>
        WriteGalleryLikes,
        /// <summary>
        /// Access to write flash
        /// </summary>
        WriteFlash,
        /// <summary>
        /// Access to write flash likes
        /// </summary>
        WriteFlashLikes,
        /// <summary>
        /// Access to create invite codes
        /// </summary>
        WriteInviteCodes,
        /// <summary>
        /// Access to favorite clips
        /// </summary>
        WriteClipFavorite,
        /// <summary>
        /// Access to create abuse reports
        /// </summary>
        WriteReportAbuse,

        // Admin Reads

        /// <summary>
        /// Access to read abuse reports
        /// </summary>
        ReadAdminAbuseReports,
        /// <summary>
        /// Access to index stats
        /// </summary>
        ReadAdminIndexStats,
        /// <summary>
        /// Access to table stats
        /// </summary>
        ReadAdminTableStats,
        /// <summary>
        /// Access to read user IPs
        /// </summary>
        ReadAdminUserIps,
        /// <summary>
        /// Access to read instance metadata
        /// </summary>
        ReadAdminMeta,
        /// <summary>
        /// Access to server info
        /// </summary>
        ReadAdminServerInfo,
        /// <summary>
        /// Access to read from audit log
        /// </summary>
        ReadAdminShowModerationLog,
        /// <summary>
        /// Access to show a user
        /// </summary>
        ReadAdminShowUser,
        /// <summary>
        /// Access to read roles
        /// </summary>
        ReadAdminRoles,
        /// <summary>
        /// Access to read relays
        /// </summary>
        ReadAdminRelays,
        /// <summary>
        /// Access to read invite codes
        /// </summary>
        ReadAdminInviteCodes,
        /// <summary>
        /// Access to read archived announcements
        /// </summary>
        ReadAdminAnnouncements,
        /// <summary>
        /// Access to read avatar decorations
        /// </summary>
        ReadAdminAvatarDecorations,
        /// <summary>
        /// Access to read account
        /// </summary>
        ReadAdminAccount,
        /// <summary>
        /// Access to read emoji
        /// </summary>
        ReadAdminEmoji,
        /// <summary>
        /// Access to read the job queue
        /// </summary>
        ReadAdminQueue,
        /// <summary>
        /// Access to admin file view
        /// </summary>
        ReadAdminDrive,
        /// <summary>
        /// Access to advertisement settings
        /// </summary>
        ReadAdminAd,

        // Admin Writes

        /// <summary>
        /// Access to delete accounts
        /// </summary>
        WriteAdminDeleteAccount,
        /// <summary>
        /// Access to delete user files
        /// </summary>
        WriteAdminDeleteAllFilesOfAUser,
        /// <summary>
        /// Access to force password resets
        /// </summary>
        WriteAdminResetPassword,
        /// <summary>
        /// Access to resolve abuse reports
        /// </summary>
        WriteadminResolveAbuseReport,
        /// <summary>
        /// Access to send email
        /// </summary>
        WriteAdminSendEmail,
        /// <summary>
        /// Access to suspend users
        /// </summary>
        WriteAdminSuspendUser,
        /// <summary>
        /// Access to force unset avatar
        /// </summary>
        WriteAdminUnsetUserAvatar,
        /// <summary>
        /// Access to force unset banner
        /// </summary>
        WriteAdminUnsetUserBanner,
        /// <summary>
        /// Access to unsuspend a user
        /// </summary>
        WriteAdminUnsuspendUser,
        /// <summary>
        /// Access to create/modify instance metadata
        /// </summary>
        WriteAdminMeta,
        /// <summary>
        /// Access to create/modify user notes
        /// </summary>
        WriteAdminUserNote,
        /// <summary>
        /// Access to create/modify roles
        /// </summary>
        WriteAdminRoles,
        /// <summary>
        /// Access to create/modify relays
        /// </summary>
        WriteAdminRelays,
        /// <summary>
        /// Access to create/modify invite codes
        /// </summary>
        WriteAdminInviteCodes,
        /// <summary>
        /// Access to make announcements
        /// </summary>
        WriteAdminAnnouncements,
        /// <summary>
        /// Access to create avatar decorations
        /// </summary>
        WriteAdminAvatarDecorations,
        /// <summary>
        /// Access to create accounts
        /// </summary>
        WriteadminAccount,
        /// <summary>
        /// Access to create/modify emojis
        /// </summary>
        WriteAdminEmoji,
        /// <summary>
        /// Access to create/modify job queue
        /// </summary>
        WriteAdminQueue,
        /// <summary>
        /// Access to create/modify promotions
        /// </summary>
        WriteAdminPromo,
        /// <summary>
        /// Access to admin drive
        /// </summary>
        WriteAdminDrive,
        /// <summary>
        /// Access to create/modify ads
        /// </summary>
        WriteAdminAd
    }
}