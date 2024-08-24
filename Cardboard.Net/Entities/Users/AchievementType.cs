using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Net.Entities.Users;

/// <summary>
/// Represents all misskey achievements
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum AchievementType
{
    #region Notes
    
    /// <summary>
    /// Post your first note
    /// </summary>
    [EnumMember(Value = "notes1")]
    Notes1,
    /// <summary>
    /// Post 10 notes
    /// </summary>
    [EnumMember(Value = "notes10")]
    Notes10,
    /// <summary>
    /// Post 100 notes
    /// </summary>
    [EnumMember(Value = "notes100")]
    Notes100,
    /// <summary>
    /// Post 500 notes
    /// </summary>
    [EnumMember(Value = "notes500")]
    Notes500,
    /// <summary>
    /// Post 1,000 notes
    /// </summary>
    [EnumMember(Value = "notes1000")]
    Notes1000,
    /// <summary>
    /// Post 5,000 notes
    /// </summary>
    [EnumMember(Value = "notes5000")]
    Notes5000,
    /// <summary>
    /// Post 10,000 notes
    /// </summary>
    [EnumMember(Value = "notes10000")]
    Notes10000,
    /// <summary>
    /// Post 20,000 notes
    /// </summary>
    [EnumMember(Value = "notes20000")]
    Notes20000,
    /// <summary>
    /// Post 30,000 notes
    /// </summary>
    [EnumMember(Value = "notes30000")]
    Notes30000,
    /// <summary>
    /// Post 40,000 notes
    /// </summary>
    [EnumMember(Value = "notes40000")]
    Notes40000,
    /// <summary>
    /// Post 50,000 notes
    /// </summary>
    [EnumMember(Value = "notes50000")]
    Notes50000,
    /// <summary>
    /// Post 60,000 notes
    /// </summary>
    [EnumMember(Value = "notes60000")]
    Notes60000,
    /// <summary>
    /// Post 70,000 notes
    /// </summary>
    [EnumMember(Value = "notes70000")]
    Notes70000,
    /// <summary>
    /// Post 80,000 notes
    /// </summary>
    [EnumMember(Value = "notes80000")]
    Notes80000,
    /// <summary>
    /// Post 90,000 notes
    /// </summary>
    [EnumMember(Value = "notes90000")]
    Notes90000,
    /// <summary>
    /// Post 100,000 notes
    /// </summary>
    [EnumMember(Value = "notes100000")]
    Notes100000,
    
    #endregion
    #region Login
    
    /// <summary>
    /// Log in for a total of 3 days
    /// </summary>
    [EnumMember(Value = "login3")]
    Login3,
    /// <summary>
    /// Log in for a total of 7 days
    /// </summary>
    [EnumMember(Value = "login7")]
    Login7,
    /// <summary>
    /// Log in for a total of 15 days
    /// </summary>
    [EnumMember(Value = "login15")]
    Login15,
    /// <summary>
    /// Log in for a total of 30 days
    /// </summary>
    [EnumMember(Value = "login30")]
    Login30,
    /// <summary>
    /// Log in for a total of 60 days
    /// </summary>
    [EnumMember(Value = "login60")]
    Login60,
    /// <summary>
    /// Log in for a total of 100 days
    /// </summary>
    [EnumMember(Value = "login100")]
    Login100,
    /// <summary>
    /// Log in for a total of 200 days
    /// </summary>
    [EnumMember(Value = "login200")]
    Login200,
    /// <summary>
    /// Log in for a total of 300 days
    /// </summary>
    [EnumMember(Value = "login300")]
    Login300,
    /// <summary>
    /// Log in for a total of 400 days
    /// </summary>
    [EnumMember(Value = "login400")]
    Login400,
    /// <summary>
    /// Log in for a total of 500 days
    /// </summary>
    [EnumMember(Value = "login500")]
    Login500,
    /// <summary>
    /// Log in for a total of 600 days
    /// </summary>
    [EnumMember(Value = "login600")]
    Login600,
    /// <summary>
    /// Log in for a total of 700 days
    /// </summary>
    [EnumMember(Value = "login700")]
    Login700,
    /// <summary>
    /// Log in for a total of 800 days
    /// </summary>
    [EnumMember(Value = "login800")]
    Login800,
    /// <summary>
    /// Log in for a total of 900 days
    /// </summary>
    [EnumMember(Value = "login900")]
    Login900,
    /// <summary>
    /// Log in for a total of 1000 days
    /// </summary>
    [EnumMember(Value = "login1000")]
    Login1000,
    
    #endregion
    #region Following
    
    /// <summary>
    /// Follow a user
    /// </summary>
    [EnumMember(Value = "following1")]
    Following1,
    /// <summary>
    /// Follow 10 users
    /// </summary>
    [EnumMember(Value = "following10")]
    Following10,
    /// <summary>
    /// Follow 50 users
    /// </summary>
    [EnumMember(Value = "following50")]
    Following50,
    /// <summary>
    /// Follow 100 users
    /// </summary>
    [EnumMember(Value = "following100")]
    Following100,
    /// <summary>
    /// Follow 300 users
    /// </summary>
    [EnumMember(Value = "following300")]
    Following300,
    
    #endregion
    #region Followers
    
    /// <summary>
    /// Gain 1 follower
    /// </summary>
    [EnumMember(Value = "followers1")]
    Followers1,
    /// <summary>
    /// Gain 10 followers
    /// </summary>
    [EnumMember(Value = "followers10")]
    Followers10,
    /// <summary>
    /// Gain 50 followers
    /// </summary>
    [EnumMember(Value = "followers50")]
    Followers50,
    /// <summary>
    /// Gain 100 followers
    /// </summary>
    [EnumMember(Value = "followers100")]
    Followers100,
    /// <summary>
    /// Gain 300 followers
    /// </summary>
    [EnumMember(Value = "followers300")]
    Followers300,
    /// <summary>
    /// Gain 500 followers
    /// </summary>
    [EnumMember(Value = "followers500")]
    Followers500,
    /// <summary>
    /// Gain 1000 followers
    /// </summary>
    [EnumMember(Value = "followers1000")]
    Followers1000,
    
    #endregion
    #region Misc
    
    // TODO: FINISH THESE.
    
    /// <summary>
    /// One year has passed since your account was created
    /// </summary>
    [EnumMember(Value = "passedSinceAccountCreated1")]
    Anniversary1,
    /// <summary>
    /// Two years have passed since your account was created
    /// </summary>
    [EnumMember(Value = "passedSinceAccountCreated2")]
    Anniversary2,
    /// <summary>
    /// Three years have passed since your account was created
    /// </summary>
    [EnumMember(Value = "passedSinceAccountCreated3")]
    Anniversary3,
    /// <summary>
    /// Log in on your birthday
    /// </summary>
    [EnumMember(Value = "loggedInOnBirthday")]
    BirthdayLogin,
    /// <summary>
    /// Log in on new years
    /// </summary>
    [EnumMember(Value = "loggedInOnNewYearsDay")]
    NewYearsLogin,
    [EnumMember(Value = "noteClipped1")]
    NoteClipped,
    [EnumMember(Value = "noteFavorited1")]
    NoteFavorited,
    [EnumMember(Value = "")]
    SelfNoteFavorited,
    ProfileFilled,
    MarkedAsCat,
    CollectAchievements,
    ViewAchievements,
    ILoveMisskey,
    FoundTreasure,
    Client30Min,
    Client60Min,
    PostLate,
    PostAt0min0sec,
    SelfQuote,
    Hit120npm
    
    #endregion
}