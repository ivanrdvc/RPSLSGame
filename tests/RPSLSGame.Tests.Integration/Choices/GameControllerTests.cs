using System.Text.Json;
using FluentAssertions;
using RPSLSGame.Models;
using RPSLSGame.Tests.Integration.Common;

namespace RPSLSGame.Tests.Integration.Choices;

public class GameControllerTests : IntegrationTest
{
    private readonly HttpClient _client;

    public GameControllerTests(RPSLSGameTestFactory factory) : base(factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetChoices_ReturnsAllChoices()
    {
        // Act
        var response = await _client.GetAsync("api/game/choices");

        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var choices =
            JsonSerializer.Deserialize<List<ChoiceModel>>(responseString, JsonOptions.Default);

        choices.Should().HaveCount(5);
        choices.Should().Contain(c => c.Name == "Rock");
        choices.Should().Contain(c => c.Name == "Paper");
        choices.Should().Contain(c => c.Name == "Scissors");
        choices.Should().Contain(c => c.Name == "Lizard");
        choices.Should().Contain(c => c.Name == "Spock");
    }

    [Fact]
    public async Task GetRandomChoice_ReturnsValidChoice()
    {
        // Act
        var response = await _client.GetAsync("/api/Game/choice");

        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var choice = JsonSerializer.Deserialize<ChoiceModel>(responseString, JsonOptions.Default);

        choice.Should().NotBeNull();
        choice!.Name.Should().NotBeNullOrWhiteSpace();
    }
}
