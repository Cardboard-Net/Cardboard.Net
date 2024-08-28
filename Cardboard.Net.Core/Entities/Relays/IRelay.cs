namespace Cardboard.Relays;

public interface IRelay : IMisskeyEntity, IDeletable
{
    /// <summary>
    /// The inbox url of the relay
    /// </summary>
    Uri? Inbox { get; }
    /// <summary>
    /// The status of the relay
    /// </summary>
    RelayStatusType Status { get; }
}