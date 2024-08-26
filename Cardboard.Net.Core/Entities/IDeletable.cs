namespace Cardboard;

public interface IDeletable
{
    /// <summary>
    /// Deletes this object and all its children
    /// </summary>
    Task DeleteAsync();
}