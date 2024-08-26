namespace Cardboard.Users;

public interface IUserInstance
{
    string? Name { get; }
    string? SoftwareName { get; }
    string? SoftwareVersion { get; }
    Uri? IconUrl { get; }
    Uri? FaviconUrl { get; }
    string? ThemeColor { get; }
}