using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class Stats
{
    [JsonProperty("notesCount")]
    public ulong NotesCount { get; set; }

    [JsonProperty("originalNotesCount")]
    public ulong OriginalNotesCount { get; set; }
    
    [JsonProperty("usersCount")]
    public ulong UsersCount { get; set; }

    [JsonProperty("originalUsersCount")]
    public ulong OriginalUsersCount { get; set; }
    
    [JsonProperty("instances")]
    public ulong InstancesCount { get; set; }
    
    [JsonProperty("driveUsageLocal")]
    public ulong DriveUsageLocal { get; set; }
    
    [JsonProperty("driveUsageRemote")]
    public ulong DriveUsageRemote { get; set; }
}