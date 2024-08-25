using Newtonsoft.Json;

namespace Cardboard.Net.Entities;

/// <summary>
/// Server info returned from the instance
/// </summary>
public class ServerInfo
{
    /// <summary>
    /// The name of the machine the instance is running on
    /// </summary>
    [JsonProperty("machine")]
    public required string Machine { get; init; }
    /// <summary>
    /// The cpu the instance is running on
    /// </summary>
    [JsonProperty("cpu")]
    public Cpu Cpu { get; init; }
    /// <summary>
    /// The amount of memory the instance has
    /// </summary>
    [JsonProperty("memory")]
    public Memory Memory { get; init; }
    /// <summary>
    /// The filesystem information of the instance
    /// </summary>
    [JsonProperty("filesystem")]
    public FileSystem FileSystem { get; init; }
}

/// <summary>
/// Server info returned from the instance as an admin
/// </summary>
public class AdminServerInfo : ServerInfo
{
    /// <summary>
    /// The operating system the instance is running on
    /// </summary>
    [JsonProperty("os")]
    public required string OperatingSystem { get; init; }
    /// <summary>
    /// The name of the node the instance is running on
    /// </summary>
    [JsonProperty("node")]
    public required string Node { get; init; }
    /// <summary>
    /// The psql connection string? I don't know.
    /// </summary>
    [JsonProperty("psql")]
    public required string PSql { get; init; }
    /// <summary>
    /// The network interface the instance is running on
    /// </summary>
    [JsonProperty("net")]
    public Network Network { get; init; }
}

/// <summary>
/// Represents the cpu of the instance
/// </summary>
public class Cpu
{
    /// <summary>
    /// Model of cpu
    /// </summary>
    [JsonProperty("model")]
    public required string Model { get; init; }
    /// <summary>
    /// The amount of cores
    /// </summary>
    [JsonProperty("cores")]
    public int Cores { get; init; }
}

public class Memory
{
    /// <summary>
    /// The amount of memory in bytes
    /// </summary>
    [JsonProperty("total")]
    public ulong Total { get; init; }
}

public class FileSystem
{
    public ulong Total { get; init; }
    public ulong Used { get; init; }
}

public class Network
{
    public required string Interface { get; init; }
}