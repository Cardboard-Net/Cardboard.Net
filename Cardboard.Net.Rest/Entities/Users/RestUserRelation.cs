using Cardboard.Users;

using Model = Cardboard.Net.Rest.API.UserRelation;

namespace Cardboard.Rest;

[Flags]
internal enum RelationFlags : int
{
    None = 0,
    OutgoingFollowReq = 1 << 0,
    IncomingFollowReq = 1 << 1,
    Followed          = 1 << 2,
    Following         = 1 << 3,
    Blocked           = 1 << 4,
    Blocking          = 1 << 5,
    Muted             = 1 << 6,
    RenoteMuted       = 1 << 7
}

public class RestUserRelation : RestEntity<string>, IUserRelation, IUpdateable
{
    private RelationFlags _relationFlags = RelationFlags.None;
    
    /// <inheritdoc/>
    public bool HasOutgoingFollowRequest
    {
        get => _relationFlags.HasFlag(RelationFlags.OutgoingFollowReq);
        private set => SetFlag(value, RelationFlags.OutgoingFollowReq);
    }
    
    /// <inheritdoc/>
    public bool HasIncomingFollowRequest
    {
        get => _relationFlags.HasFlag(RelationFlags.IncomingFollowReq);
        private set => SetFlag(value, RelationFlags.IncomingFollowReq);
    }
    
    /// <inheritdoc/>
    public bool IsFollowed
    {
        get => _relationFlags.HasFlag(RelationFlags.Followed);
        private set => SetFlag(value, RelationFlags.Followed);
    }
    
    /// <inheritdoc/>
    public bool IsFollowing
    {
        get => _relationFlags.HasFlag(RelationFlags.Following);
        private set => SetFlag(value, RelationFlags.Following);
    }

    /// <inheritdoc/>
    public bool IsBlocked
    {
        get => _relationFlags.HasFlag(RelationFlags.Blocked);
        private set => SetFlag(value, RelationFlags.Blocked);
    }

    /// <inheritdoc/>
    public bool IsBlocking
    {
        get => _relationFlags.HasFlag(RelationFlags.Blocking);
        private set => SetFlag(value, RelationFlags.Blocking);
    }

    /// <inheritdoc/>
    public bool IsMuted
    {
        get => _relationFlags.HasFlag(RelationFlags.Muted);
        private set => SetFlag(value, RelationFlags.Muted);
    }

    /// <inheritdoc/>
    public bool IsRenoteMuted
    {
        get => _relationFlags.HasFlag(RelationFlags.RenoteMuted);
        private set => SetFlag(value, RelationFlags.RenoteMuted);
    }

    // old habits die hard.
    internal void SetFlag(bool value, RelationFlags flag)
    {
        _relationFlags = value ? _relationFlags | flag : _relationFlags & ~flag;
    }
    
    public RestUserRelation(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    internal static RestUserRelation Create(BaseMisskeyClient client, Model model)
    {
        RestUserRelation entity = new(client, model.Id);
        entity.Update(model);
        return entity;
    }

    internal void Update(Model model)
    {
        HasIncomingFollowRequest = model.HasIncomingFollowRequest;
        HasOutgoingFollowRequest = model.HasOutgoingFollowRequest;
        IsFollowed = model.IsFollowed;
        IsFollowing = model.IsFollowing;
        IsBlocked = model.IsBlocked;
        IsBlocking = model.IsBlocking;
        IsMuted = model.IsMuted;
        IsRenoteMuted = model.IsRenoteMuted;
    }
    
    public async Task UpdateAsync()
    {
        var model = await Misskey.ApiClient.GetUserRelation(this.Id).ConfigureAwait(false);

        if (model == null)
            return;
        
        Update(model);
    }
}