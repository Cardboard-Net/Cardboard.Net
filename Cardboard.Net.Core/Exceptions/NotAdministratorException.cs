using Cardboard.Errors;

namespace Cardboard.Exceptions;

public class NotAdministratorException(NotAdministratorError err) : MisskeyException(err) { }