namespace Cardboard.Charts;

public class GenericChart
{
    /// <summary>
    ///     Total
    /// </summary>
    public IReadOnlyCollection<int> Total { get; internal init; } = [];
    
    /// <summary>
    ///     Increase
    /// </summary>
    public IReadOnlyCollection<int> Increase { get; internal init; } = [];
    
    /// <summary>
    ///     Decrease
    /// </summary>
    public IReadOnlyCollection<int> Decrease { get; internal init; } = [];
}

public class GenericNoteChart : GenericChart
{
    /// <summary>
    ///     Diffs
    /// </summary>
    public GenericNoteDiffs Diffs { get; internal init; } = new GenericNoteDiffs();
}

public class GenericNoteDiffs
{
    /// <summary>
    ///     Normal notes
    /// </summary>
    public IReadOnlyCollection<int> Normal { get; internal init; } = [];
    
    /// <summary>
    ///     Reply notes
    /// </summary>
    public IReadOnlyCollection<int> Reply { get; internal init; } = [];
    
    /// <summary>
    ///     Renotes
    /// </summary>
    public IReadOnlyCollection<int> Renote { get; internal init; } = [];
    
    /// <summary>
    ///     Notes with a file
    /// </summary>
    public IReadOnlyCollection<int> WithFile { get; internal init; } = [];
}

public class GenericDriveChart
{
    /// <summary>
    ///     Increased file count
    /// </summary>
    public IReadOnlyCollection<int> IncreaseCount { get; internal init; } = [];
    
    /// <summary>
    ///     Decreased file count
    /// </summary>
    public IReadOnlyCollection<int> DecreaseCount { get; internal init; } = [];
    
    /// <summary>
    ///     Increased drive usage
    /// </summary>
    public IReadOnlyCollection<ulong> IncreaseSize { get; internal init; } = [];
    
    /// <summary>
    ///     Decreased drive usage
    /// </summary>
    public IReadOnlyCollection<ulong> DecreaseSize { get; internal init; } = [];
}