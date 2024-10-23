using Cardboard.Exceptions;

namespace Cardboard.Errors;

/// <summary>
///     Represents an error given when trying to perform certain actions on an
/// account that does not have the administrator role assigned.
/// </summary>
public class NotAdministratorError() : IMisskeyError
{
    ///<inheritdoc/>
    public string Message => "You are not assigned to an administrator role.";
    
    ///<inheritdoc/>
    public ErrorCodeType Code => ErrorCodeType.PermissionDenied;
    
    ///<inheritdoc/>
    public string Id => "c3d38592-54c0-429d-be96-5636b0431a61";
    
    ///<inheritdoc/>
    public ErrorKindType Kind => ErrorKindType.Permission;

    public void Throw()
        => throw new NotAdministratorException(this);
}