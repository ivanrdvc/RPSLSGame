using RPSLSGame.Domain;

namespace RPSLSGame.Models;

public class ChoiceModel
{
    /// <summary>
    /// The unique identifier for the choice.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// The name of the choice.
    /// Possible values are "Rock", "Paper", "Scissors", "Lizard", and "Spock".
    /// </summary>
    public string? Name { get; init; }

    public static ChoiceModel FromDomain(Choice choice)
    {
        return new ChoiceModel
        {
            Id = choice.Id,
            Name = choice.Name
        };
    }
}
