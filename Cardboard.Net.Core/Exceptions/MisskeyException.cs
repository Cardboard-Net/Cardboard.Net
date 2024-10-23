using Cardboard.Errors;

namespace Cardboard.Exceptions;

public class MisskeyException : Exception
{
    public MisskeyException(IMisskeyError error) : base($"{error.Kind} Error! {error.Message}") {}
}