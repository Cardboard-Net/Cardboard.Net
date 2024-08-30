using System.Collections.Immutable;

namespace Cardboard.Notes;

public class Poll : IPoll
{
    public DateTime? ExpiresAt { get; internal set; }
    internal TimeSpan? ExpiresAfter { get; set; }
    public ImmutableArray<PollChoice> Choices { get; internal set; }
    public bool MultipleChoice { get; internal set; }

    internal Poll(bool multipleChoice, ImmutableArray<PollChoice> choices, DateTime? expiresAt, TimeSpan? expiresAfter)
    {
        MultipleChoice = multipleChoice;
        Choices = choices;
        ExpiresAt = expiresAt;
        ExpiresAfter = expiresAfter;
    }
}