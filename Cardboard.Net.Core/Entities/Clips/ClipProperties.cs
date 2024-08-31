namespace Cardboard.Clips;

public class ClipProperties
{
    /// <summary>
    ///     Gets or sets the name of the clip
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">Throws an exception if you exceed 100 characters.</exception>
    public string? Name
    {
        get => this.name;
        set
        {
            if (value?.Length > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Name cannot be greater than 100 characters.");
            }
            
            if (value == string.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Name cannot be an empty string, set to null to avoid modifying!");
            }

            this.name = value;
        }
    }
    private string? name;

    /// <summary>
    ///     Gets or sets the description of the clip
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">Throws an exception if you exceed 2048 characters.</exception>
    public string? Description
    {
        get => this.description;
        set
        {
            if (value?.Length > 2048)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Description cannot be greater than 100 characters.");
            }

            if (value == string.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Description cannot be an empty string, set to null to avoid modifying!");
            }

            this.description = value;
        }
    }
    private string? description;
    
    /// <summary>
    ///     Gets or sets the clip's visibility to the public
    /// </summary>
    public bool IsPublic { get; set; }
}