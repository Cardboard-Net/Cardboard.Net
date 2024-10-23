using Cardboard.Exceptions;

namespace Cardboard.Errors;

/// <summary>
///     Represents an error given when trying to perform certain actions on an
/// account that has been migrated to another instance.
/// </summary>
public class AccountMigratedError() : IMisskeyError
{
    ///<inheritdoc/>
    public string Message => "You have moved your account.";
    
    ///<inheritdoc/>
    public ErrorCodeType Code => ErrorCodeType.AccountMoved;
    
    ///<inheritdoc/>
    public string Id => "56f20ec9-fd06-4fa5-841b-edd6d7d4fa31";
    
    ///<inheritdoc/>
    public ErrorKindType Kind => ErrorKindType.Permission;

    public void Throw()
        => throw new MisskeyException(this);
}