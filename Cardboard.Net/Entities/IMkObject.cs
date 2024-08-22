namespace Cardboard.Net.Entities;

/// <summary>
/// Interface for all misskey objects to inherit from
/// </summary>
public interface IMkObject
{
    /// <summary>
    /// misskey:id corresponding to the object
    /// </summary>
    public string Id { get; }
}
