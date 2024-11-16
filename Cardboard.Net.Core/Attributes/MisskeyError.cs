namespace Cardboard.Attributes;

[System.AttributeUsage(System.AttributeTargets.Class)]
public class MisskeyError : System.Attribute
{
    public required bool Critical { get; init; }
}