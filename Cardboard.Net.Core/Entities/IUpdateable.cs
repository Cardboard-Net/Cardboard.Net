namespace Cardboard;

/// <summary>
///     Defines whether the object is updateable or not.
/// </summary>
public interface IUpdateable
{
    /// <summary>
    ///     Updates this object's properties with its current state.
    /// </summary>
    Task UpdateAsync();
}