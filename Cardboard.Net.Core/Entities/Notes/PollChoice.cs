namespace Cardboard.Notes;

public struct PollChoice
{
    public string Text { get; internal set; }
    public int? Votes { get; internal set; }
    public bool? IsVoted { get; internal set; }

    internal PollChoice(string text, int? votes = null, bool? isVoted = null)
    {
        Text = text;
        Votes = votes;
        IsVoted = isVoted;
    }
}