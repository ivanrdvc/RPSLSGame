using RPSLSGame.Data;
using RPSLSGame.Domain;
using RPSLSGame.Models;

namespace RPSLSGame.Services;

public class GameService : IGameService
{
    private readonly GameDbContext _context;
    private readonly IRandomNumberService _randomNumberService;

    public GameService(GameDbContext context, IRandomNumberService randomNumberService)
    {
        _context = context;
        _randomNumberService = randomNumberService;
    }

    public async Task<PlayResponse> PlayGameAgainstComputerAsync(int playerChoiceId)
    {
        var playerChoice = await _context.Choices.FindAsync(playerChoiceId);
        if (playerChoice == null)
        {
            throw new ArgumentException($"Invalid choice ID: {playerChoiceId}",
                nameof(playerChoiceId));
        }

        int computerChoiceId;
        try
        {
            computerChoiceId = await _randomNumberService.FetchRandomNumberAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Failed to determine the computer's choice. Please try again later.", ex);
        }

        var result = GameRules.DetermineWinner((ChoiceEnum)playerChoiceId, (ChoiceEnum)computerChoiceId);

        return new PlayResponse
        {
            Result = result,
            Player = playerChoice.Id,
            Computer = computerChoiceId
        };
    }
}
