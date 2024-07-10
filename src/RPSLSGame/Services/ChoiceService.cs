using RPSLSGame.Models;

namespace RPSLSGame.Services;

public class ChoiceService : IChoiceService
{
    private static readonly List<ChoiceModel> Choices = new()
    {
        new ChoiceModel { Id = 1, Name = "Rock" },
        new ChoiceModel { Id = 2, Name = "Paper" },
        new ChoiceModel { Id = 3, Name = "Scissors" },
        new ChoiceModel { Id = 4, Name = "Lizard" },
        new ChoiceModel { Id = 5, Name = "Spock" }
    };

    private readonly Random _random;

    public ChoiceService()
    {
        _random = new Random();
    }

    public List<ChoiceModel> GetChoices()
    {
        return Choices;
    }

    public ChoiceModel GetRandomChoice()
    {
        return Choices[_random.Next(Choices.Count)];
    }
}
