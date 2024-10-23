namespace Cardboard.Errors;

/// <summary>
///     Represents an unwrapped misskey error
/// </summary>
public interface IMisskeyError
{
    /// <summary>
    ///     The message of the error
    /// </summary>
    string Message { get; }
    
    /// <summary>
    ///     The error code type
    /// </summary>
    ErrorCodeType Code { get; }
    
    /// <summary>
    ///     The Id of the error
    /// </summary>
    string Id { get; }
    
    /// <summary>
    ///     The kind of error
    /// </summary>
    ErrorKindType Kind { get; }

    /// <summary>
    ///     Throws the corresponding exception to this error
    /// </summary>
    void Throw();
}