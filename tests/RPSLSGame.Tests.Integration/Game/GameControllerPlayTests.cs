using System.Net.Http.Json;
using System.Text.Json;
using FluentAssertions;
using RPSLSGame.Models;
using RPSLSGame.Tests.Integration.Common;

namespace RPSLSGame.Tests.Integration.Game;

public class GameControllerPlayTests : IntegrationTest
{
    private readonly HttpClient _client;

    public GameControllerPlayTests(RPSLSGameTestFactory factory) : base(factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PlayGame_WithValidChoice_ReturnsValidResult()
    {
        // Arrange
        var playRequest = new PlayRequest { Player = 1 };

        // Act
        var response = await _client.PostAsJsonAsync("/api/game/play", playRequest);

        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var playResponse =
            JsonSerializer.Deserialize<PlayResponse>(responseString, JsonOptions.Default);

        playResponse.Should().NotBeNull();
        playResponse!.Player.Should().Be(playRequest.Player);
        playResponse.Computer.Should().BeInRange(1, 5);
        playResponse.Results.Should().NotBeNullOrWhiteSpace();
        playResponse.Results.Should().MatchRegex("^(win|lose|tie)$");
    }

    [Fact]
    public async Task PlayGame_WithInvalidChoice_ReturnsBadRequest()
    {
        // Arrange
        const int invalidChoice = 10;
        var playRequest = new PlayRequest { Player = invalidChoice };

        // Act
        var response = await _client.PostAsJsonAsync("/api/game/play", playRequest);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
    }
}
