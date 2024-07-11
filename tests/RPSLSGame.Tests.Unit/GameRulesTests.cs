using FluentAssertions;
using RPSLSGame.Domain;

namespace RPSLSGame.Tests.Unit;

public class GameRulesTests
{
    [Theory]
    [InlineData(ChoiceEnum.Rock, ChoiceEnum.Scissors)]
    [InlineData(ChoiceEnum.Rock, ChoiceEnum.Lizard)]
    [InlineData(ChoiceEnum.Paper, ChoiceEnum.Rock)]
    [InlineData(ChoiceEnum.Paper, ChoiceEnum.Spock)]
    [InlineData(ChoiceEnum.Scissors, ChoiceEnum.Paper)]
    [InlineData(ChoiceEnum.Scissors, ChoiceEnum.Lizard)]
    [InlineData(ChoiceEnum.Lizard, ChoiceEnum.Paper)]
    [InlineData(ChoiceEnum.Lizard, ChoiceEnum.Spock)]
    [InlineData(ChoiceEnum.Spock, ChoiceEnum.Rock)]
    [InlineData(ChoiceEnum.Spock, ChoiceEnum.Scissors)]
    public void DetermineWinner_PlayerWins_ReturnsWin(ChoiceEnum playerChoice,
        ChoiceEnum computerChoice)
    {
        // Act
        var result = GameRules.DetermineWinner(playerChoice, computerChoice);

        // Assert
        result.Should().Be("win");
    }

    [Theory]
    [InlineData(ChoiceEnum.Rock, ChoiceEnum.Paper)]
    [InlineData(ChoiceEnum.Rock, ChoiceEnum.Spock)]
    [InlineData(ChoiceEnum.Paper, ChoiceEnum.Scissors)]
    [InlineData(ChoiceEnum.Paper, ChoiceEnum.Lizard)]
    [InlineData(ChoiceEnum.Scissors, ChoiceEnum.Rock)]
    [InlineData(ChoiceEnum.Scissors, ChoiceEnum.Spock)]
    [InlineData(ChoiceEnum.Lizard, ChoiceEnum.Rock)]
    [InlineData(ChoiceEnum.Lizard, ChoiceEnum.Scissors)]
    [InlineData(ChoiceEnum.Spock, ChoiceEnum.Paper)]
    [InlineData(ChoiceEnum.Spock, ChoiceEnum.Lizard)]
    public void DetermineWinner_PlayerLoses_ReturnsLose(ChoiceEnum playerChoice,
        ChoiceEnum computerChoice)
    {
        // Act
        var result = GameRules.DetermineWinner(playerChoice, computerChoice);

        // Assert
        result.Should().Be("lose");
    }

    [Theory]
    [InlineData(ChoiceEnum.Rock)]
    [InlineData(ChoiceEnum.Paper)]
    [InlineData(ChoiceEnum.Scissors)]
    [InlineData(ChoiceEnum.Lizard)]
    [InlineData(ChoiceEnum.Spock)]
    public void DetermineWinner_Tie_ReturnsTie(ChoiceEnum choice)
    {
        // Act
        var result = GameRules.DetermineWinner(choice, choice);

        // Assert
        result.Should().Be("tie");
    }
}
