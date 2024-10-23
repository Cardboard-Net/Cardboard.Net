using Cardboard.Errors;

namespace Cardboard.Exceptions;

public class NotModeratorException(NotModeratorError err) : MisskeyException(err);