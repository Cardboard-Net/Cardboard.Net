namespace Cardboard.Net.Util;

public static class Utilities
{
    public static void NullOrWhitespaceCheck(string nameof, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            ArgumentNullException.ThrowIfNull(value);

            throw new ArgumentException($"{nameof} cannot be empty or whitespace.", nameof);
        }
    }
}