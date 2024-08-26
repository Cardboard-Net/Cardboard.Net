using System.ComponentModel.DataAnnotations;

namespace Cardboard.Net.Clients;

public class MisskeyClientOptions
{
    [Required]
    public string Token { get; set; }
    [Required]
    public Uri Host { get; set; }
}