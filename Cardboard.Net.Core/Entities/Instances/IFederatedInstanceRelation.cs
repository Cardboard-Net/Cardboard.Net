using Cardboard.Users;

namespace Cardboard.Instances;

/// <summary>
///     Represents a federated instance relation
/// </summary>
public interface IFederatedInstanceRelation : IMisskeyEntity
{
    /// <summary>
    ///     The date this relation was created
    /// </summary>
    DateTime CreatedAt { get; }
    
    /// <summary>
    ///     The followee in this relation
    /// </summary>
    IUser Followee { get; }
    
    /// <summary>
    ///     The follower in this relation
    /// </summary>
    IUser Follower { get; }
}