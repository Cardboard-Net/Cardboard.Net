namespace Cardboard.Exceptions;

public class EmptyErrorBodyException() : Exception("Received an empty error body with an error HTTP status code! Assuming critical!");