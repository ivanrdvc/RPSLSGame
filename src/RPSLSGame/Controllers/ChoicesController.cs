using Microsoft.AspNetCore.Mvc;
using RPSLSGame.Services;

namespace RPSLSGame.Controllers;

[ApiController]
[Route("[controller]")]
public class ChoicesController : ControllerBase
{
    private readonly IChoiceService _choiceService;

    public ChoicesController(IChoiceService choiceService)
    {
        _choiceService = choiceService;
    }

    [HttpGet("choices")]
    public IActionResult GetChoices()
    {
        var choices = _choiceService.GetChoices();

        return Ok(choices);
    }

    [HttpGet("choice")]
    public IActionResult GetRandomChoice()
    {
        var choice = _choiceService.GetRandomChoice();

        return Ok(choice);
    }
}
