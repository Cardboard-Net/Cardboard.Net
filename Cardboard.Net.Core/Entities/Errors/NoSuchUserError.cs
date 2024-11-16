using Cardboard.Exceptions;

namespace Cardboard.Errors;

public class NoSuchUserError() : IMisskeyError
{
    ///<inheritdoc/>
    public string Message => "No such user.";

    ///<inheritdoc/>
    public ErrorCodeType Code => ErrorCodeType.NoSuchUser;
    
    ///<inheritdoc/>
    public string Id => "4362f8dc-731f-4ad8-a694-be5a88922a24";
    
    ///<inheritdoc/>
    public ErrorKindType Kind => ErrorKindType.Client;
    
    ///<inheritdoc/>
    public bool Critical => false;
    
    public void Throw()
        => throw new MisskeyException(this);
}