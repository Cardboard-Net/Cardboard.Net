using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace Cardboard.Net.Entities.Notes;

public class PollBuilder
{
    /// <summary>
    /// The poll choices
    /// </summary>
    public IReadOnlyList<string> Choices { get; }
    private readonly List<string> choices = [];

    public PollBuilder() => this.Choices = new ReadOnlyCollection<string>(this.choices);

    public DateTime? ExpiresAt
    {
        get => this.expiresAt;
        set
        {
            if (value != null && this.expiredAfter.HasValue)
            {
                throw new InvalidOperationException("Cannot set timespan AND datetime!");
            }
            
            this.expiresAt = value;
        }
    }
    private DateTime? expiresAt;
    
    public TimeSpan? ExpiredAfter
    {
        get => this.expiredAfter;
        set
        {
            if (value != null && this.expiresAt.HasValue)
            {
                throw new InvalidOperationException("Cannot set timespan AND datetime!");
            }
            
            this.expiredAfter = value;
        }
    }
    private TimeSpan? expiredAfter;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="choice"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public PollBuilder AddChoice(string choice)
    {
        if (string.IsNullOrWhiteSpace(choice))
        {
            ArgumentNullException.ThrowIfNull(choice);

            throw new ArgumentException("Value cannot be empty or whitespace.", nameof(choice));
        }

        if (this.choices.Contains(choice))
        {
            throw new InvalidOperationException("Cannot add choice more than once.");
        }
        
        // TODO: find if this is just misskey's webui limitation or what
        if (this.choices.Count > 10)
        {
            throw new InvalidOperationException("Cannot add more than 10 choices.");
        }
        
        this.choices.Add(choice);
        
        return this;
    }
    
    /// <summary>
    /// Removes a choice of the specified index from this embed.
    /// </summary>
    /// <param name="index">Index of the choice to remove.</param>
    /// <returns>This poll builder.</returns>
    public PollBuilder RemoveChoiceAt(int index)
    {
        this.choices.RemoveAt(index);
        return this;
    }

    /// <summary>
    /// Removes choices of the specified range from this embed.
    /// </summary>
    /// <param name="index">Index of the first choice to remove.</param>
    /// <param name="count">Number of choices to remove.</param>
    /// <returns>This poll builder.</returns>
    public PollBuilder RemoveChoiceRange(int index, int count)
    {
        this.choices.RemoveRange(index, count);
        return this;
    }

    /// <summary>
    /// Removes all fields from this embed.
    /// </summary>
    /// <returns>This embed builder.</returns>
    public PollBuilder ClearChoices()
    {
        this.choices.Clear();
        return this;
    }
    
    /// <summary>
    /// Builds into a Poll
    /// </summary>
    /// <returns>Poll</returns>
    public Poll Build()
    {
        Poll poll = new()
        {
            Choices = new ReadOnlyCollection<string>(new List<string>(this.choices))
        };
        return poll;
    }

    public static implicit operator Poll(PollBuilder builder)
        => builder.Build();
}