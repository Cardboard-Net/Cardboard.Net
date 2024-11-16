using Cardboard.Errors;

namespace Cardboard.Exceptions;

public class MisskeyException(IMisskeyError error) : Exception($"{error.Kind} Error! {error.Message}");