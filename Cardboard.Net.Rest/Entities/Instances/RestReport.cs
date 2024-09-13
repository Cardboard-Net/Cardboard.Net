using Cardboard.Instances;
using Cardboard.Net.Rest.API;
using Cardboard.Users;

namespace Cardboard.Rest.Instances;

public class RestReport : RestEntity<string>, IReport
{
    /// <inheritdoc/>
    public DateTime CreatedAt { get; private set; }
    
    /// <inheritdoc/>
    public string Comment { get; private set; }
    
    /// <inheritdoc/>
    public bool Resolved { get; private set; }
    
    /// <inheritdoc/>
    public bool Forwarded { get; internal set; }
    
    /// <summary>
    ///     A rest user representation of reporter
    /// </summary>
    public RestUserLite Reporter { get; private set; }
    
    /// <summary>
    ///     A rest user representation of reportee
    /// </summary>
    public RestUserLite Reportee { get; private set; }
    
    /// <summary>
    ///     A rest user representation of assignee
    /// </summary>
    public RestUserLite? Assignee { get; private set; }
    
    public RestReport(BaseMisskeyClient misskey, string id) : base(misskey, id) { }
    
    internal static RestReport Create(BaseMisskeyClient client, AbuseReport model)
    {
        RestReport entity = new(client, model.Id);
        entity.Update(model);
        return entity;
    }

    internal void Update(AbuseReport model)
    {
        CreatedAt = model.CreatedAt;
        Comment = model.Comment;
        Resolved = model.Resolved;
        Reporter = RestUserLite.Create(Misskey, model.Reporter);
        Reportee = RestUserLite.Create(Misskey, model.TargetUser);
        Assignee = model.Assignee != null
            ? RestUserLite.Create(Misskey, model.Assignee)
            : null;
    }
    
    public Task ResolveAsync(bool forward = false)
    {
        throw new NotImplementedException();
    }
    
    IUserLite IReport.Reporter => Reporter;
    IUserLite IReport.Reportee => Reportee;
    IUserLite? IReport.Assignee => Assignee;
}