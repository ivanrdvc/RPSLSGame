using Microsoft.AspNetCore.Mvc;
using RPSLSGame.Models;
using RPSLSGame.Services;

namespace RPSLSGame.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;
    private readonly IChoiceService _choiceService;

    public GameController(IGameService gameService, IChoiceService choiceService)
    {
        _gameService = gameService;
        _choiceService = choiceService;
    }

    /// <summary>
    /// Plays a game round against a computer opponent.
    /// </summary>
    /// <param name="request">The player's choice ID.</param>
    /// <returns>The game result.</returns>
    /// <response code="200">Returns the game result</response>
    /// <response code="400">If the player's choice ID is invalid</response>
    [HttpPost("play")]
    [ProducesResponseType(typeof(PlayResponse), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    public async Task<IActionResult> Play([FromBody] PlayRequest request)
    {
        var result =
            await _gameService.PlayGameAgainstComputerAsync(request.Player, request.PlayerId);

        return Ok(result);
    }

    /// <summary>
    /// Gets all available choices.
    /// </summary>
    /// <returns>A list of choices.</returns>
    /// <response code="200">Returns the list of choices</response>
    [HttpGet("choices")]
    [ProducesResponseType(typeof(List<ChoiceModel>), 200)]
    public async Task<IActionResult> GetChoices()
    {
        var choices = await _choiceService.GetChoicesAsync();

        return Ok(choices);
    }

    /// <summary>
    /// Gets a random choice.
    /// </summary>
    /// <returns>A random choice from the available choices.</returns>
    /// <response code="200">Returns the random choice</response>
    [HttpGet("choice")]
    [ProducesResponseType(typeof(ChoiceModel), 200)]
    public async Task<IActionResult> GetRandomChoice()
    {
        var choice = await _choiceService.GetRandomChoiceAsync();

        return Ok(choice);
    }
}
