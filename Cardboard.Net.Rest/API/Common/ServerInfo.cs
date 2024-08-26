using Newtonsoft.Json;

namespace Cardboard.Net.Rest.API;

internal class ServerInfo
{
    [JsonProperty("machine")]
    public string Machine { get; set; }
    
    [JsonProperty("cpu")]
    public Cpu Cpu { get; set; }

    [JsonProperty("memory")]
    public Memory Memory { get; set; }

    [JsonProperty("filesystem")]
    public FileSystem FileSystem { get; init; }
}

internal class AdminServerInfo : ServerInfo
{
    [JsonProperty("os")]
    public string OperatingSystem { get; set; }
    
    [JsonProperty("node")]
    public string Node { get; set; }

    [JsonProperty("psql")]
    public string PSql { get; set; }

    [JsonProperty("net")]
    public Network Network { get; set; }
}

internal class Cpu
{
    [JsonProperty("model")]
    public string Model { get; set; }
    
    [JsonProperty("cores")]
    public int Cores { get; set; }
}

internal class Memory
{
    [JsonProperty("total")]
    public ulong Total { get; set; }
}

internal class FileSystem
{
    [JsonProperty("total")]
    public ulong Total { get; set; }
    
    [JsonProperty("used")]
    public ulong Used { get; set; }
}

internal class Network
{
    [JsonProperty("interface")]
    public string Interface { get; set; }
}