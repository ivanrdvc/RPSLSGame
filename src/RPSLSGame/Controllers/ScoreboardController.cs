using Microsoft.AspNetCore.Mvc;
using RPSLSGame.Models;
using RPSLSGame.Services;

namespace RPSLSGame.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScoreboardController : ControllerBase
{
    private readonly IGameService _gameService;

    public ScoreboardController(IGameService gameService)
    {
        _gameService = gameService;
    }

    /// <summary>
    /// Gets the top players based on their win streaks with pagination.
    /// </summary>
    /// <param name="paginationParameters">The pagination parameters</param>
    /// <returns>A list of top players.</returns>
    /// <response code="200">Returns the list of top players</response>
    /// <response code="400">If the pagination parameters are invalid</response>
    [HttpGet("top-players")]
    [ProducesResponseType(typeof(List<PlayerStatisticsModel>), 200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetTopPlayers(
        [FromQuery] PaginationParameters paginationParameters)
    {
        var topPlayers = await _gameService.GetTopPlayersAsync(
            paginationParameters.PageNumber,
            paginationParameters.PageSize);

        return Ok(topPlayers);
    }

    /// <summary>
    /// Resets the scoreboard by clearing all player streaks.
    /// </summary>
    /// <returns>A response indicating the result of the operation.</returns>
    /// <response code="204">Scoreboard reset successfully</response>
    [HttpDelete("reset")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> ResetScoreboard()
    {
        await _gameService.ResetScoreboardAsync();

        return NoContent();
    }

    /// <summary>
    /// Gets the overall statistics for a specific player.
    /// </summary>
    /// <param name="playerId">The ID of the player.</param>
    /// <returns>The statistics of the player.</returns>
    /// <response code="200">Returns the player's statistics</response>
    /// <response code="404">If the player is not found</response>
    [HttpGet("player-stats/{playerId}")]
    [ProducesResponseType(typeof(PlayerStatisticsModel), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetPlayerStatistics(int playerId)
    {
        var playerStats = await _gameService.GetPlayerStatisticsAsync(playerId);

        return Ok(playerStats);
    }
}
