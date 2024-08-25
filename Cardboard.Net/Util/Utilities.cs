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

    public static void CheckLimit(string nameof, int limit, int lowerBound = 0, int upperBound = 100)
    {
        if (limit > upperBound)
        {
            throw new ArgumentException($"{nameof} cannot exceed {upperBound}.", nameof);
        }

        if (limit < lowerBound)
        {
            throw new ArgumentException($"'{nameof}' cannot be less than {lowerBound}.", nameof);
        }
    }
}