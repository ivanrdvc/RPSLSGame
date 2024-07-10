using Microsoft.AspNetCore.Mvc;
using RPSLSGame.Models;
using RPSLSGame.Services;

namespace RPSLSGame.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpPost]
    public async Task<IActionResult> Play([FromBody] PlayRequest request)
    {
        throw new NotImplementedException();
    }
}
