using System.Collections.Immutable;

namespace Cardboard.Notes;

public class PollBuilder
{
    public bool MultipleChoice { get; set; }
    
    public DateTime? ExpiresAt
    {
        get => this.expiresAt;
        set
        {
            if (value != null && this.expiresAfter != null)
            {
                throw new ArgumentException("Cannot set expires at and expires after");
            }

            this.expiresAt = value;
        }
    }
    private DateTime? expiresAt;

    public TimeSpan? ExpiresAfter
    {
        get => this.expiresAfter;
        set
        {
            if (value != null && this.expiresAt != null)
            {
                throw new ArgumentException("Cannot set expires after and expires at");
            }

            this.expiresAfter = value;
        }
    }
    private TimeSpan? expiresAfter;

    public List<string> Choices
    {
        get => _choices;
        set
        {
            if (value == null)
                throw new ArgumentNullException(paramName: nameof(Choices), message: "Cannot set a poll's choice collection to null.");
            if (value.Count > 10)
                throw new ArgumentException(message: $"Field count must be less than or equal to 10.", paramName: nameof(Choices));
            _choices = value;
        }
    }
    private List<string> _choices = [];
    
    public PollBuilder AddChoice(string choice)
    {
        if (string.IsNullOrWhiteSpace(choice))
        {
            ArgumentNullException.ThrowIfNull(choice);

            throw new ArgumentException("Choice cannot be empty or whitespace", nameof(choice));
        }

        if (_choices.Contains(choice))
        {
            throw new ArgumentException("Cannot have duplicate choices");
        }
        
        this._choices.Add(choice);

        return this;
    }

    public Poll Build()
    {
        if (_choices.Count < 2)
        {
            throw new InvalidOperationException("You must have at least 2 choices.");
        }
        
        var choices = ImmutableArray.CreateBuilder<PollChoice>(_choices.Count);
        foreach (var t in _choices)
            choices.Add(new PollChoice(t));
        return new Poll(MultipleChoice, choices.ToImmutable(), expiresAt, expiresAfter);
    }
}