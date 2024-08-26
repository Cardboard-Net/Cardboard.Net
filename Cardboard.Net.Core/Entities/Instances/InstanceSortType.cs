using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cardboard.Instances;

/// <summary>
/// The sort types for federated instances
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum InstanceSortType
{
    /// <summary>
    /// Pubsub ascending
    /// </summary>
    [EnumMember(Value = "+pubSub")]
    PubSubAscending,
    /// <summary>
    /// Pubsub descending
    /// </summary>
    [EnumMember(Value = "-pubSub")]
    PubSubDescending,
    /// <summary>
    /// Notes ascending
    /// </summary>
    [EnumMember(Value = "+notes")]
    NotesAscending,
    /// <summary>
    /// Notes descending
    /// </summary>
    [EnumMember(Value = "-notes")]
    NotesDescending,
    /// <summary>
    /// Users ascending
    /// </summary>
    [EnumMember(Value = "+users")]
    UsersAscending,
    /// <summary>
    /// Users descending
    /// </summary>
    [EnumMember(Value = "-users")]
    UsersDescending,
    /// <summary>
    /// Following ascending
    /// </summary>
    [EnumMember(Value = "+following")]
    FollowingAscending,
    /// <summary>
    /// Following descending
    /// </summary>
    [EnumMember(Value = "-following")]
    FollowingDescending,
    /// <summary>
    /// Followers ascending
    /// </summary>
    [EnumMember(Value = "+followers")]
    FollowersAscending,
    /// <summary>
    /// Followers descending
    /// </summary>
    [EnumMember(Value = "-followers")]
    FollowersDescending,
    /// <summary>
    /// First retrieved at ascending
    /// </summary>
    [EnumMember(Value = "+firstRetrievedAt")]
    FirstRetrievedAscending,
    /// <summary>
    /// First retrieved at descending
    /// </summary>
    [EnumMember(Value = "-firstRetrievedAt")]
    FirstRetrievedDescending,
    /// <summary>
    /// Latest request received at ascending
    /// </summary>
    [EnumMember(Value = "+latestRequestReceivedAt")]
    LatestReceivedAtAscending,
    /// <summary>
    /// Latest request received at descending
    /// </summary>
    [EnumMember(Value = "-latestRequestReceivedAt")]
    LatestReceivedAtDescending
}