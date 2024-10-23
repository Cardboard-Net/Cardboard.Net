using Cardboard.Exceptions;

namespace Cardboard.Errors;

/// <summary>
///     Represents an error given when trying to perform certain actions on an
/// account that does not have the moderator role assigned.
/// </summary>
public class NotModeratorError() : IMisskeyError
{
    ///<inheritdoc/>
    public string Message => "You are not assigned to a moderator role.";
    
    ///<inheritdoc/>
    public ErrorCodeType Code => ErrorCodeType.PermissionDenied;
    
    ///<inheritdoc/>
    public string Id => "d33d5333-db36-423d-a8f9-1a2b9549da41";
    
    ///<inheritdoc/>
    public ErrorKindType Kind => ErrorKindType.Permission;

    public void Throw()
        => throw new NotModeratorException(this);
}