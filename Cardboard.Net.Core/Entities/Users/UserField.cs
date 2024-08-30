namespace Cardboard.Users;

public class UserField : IUserField
{
    /// <summary>
    /// The name of the field
    /// </summary>
    public string Name { get; internal set; }
    
    /// <summary>
    /// The corresponding value of the field
    /// </summary>
    public string Description { get; internal set; }

    public UserField(string name, string description)
    {
        Name = name;
        Description = description;
    }
}