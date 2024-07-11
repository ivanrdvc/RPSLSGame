using Microsoft.EntityFrameworkCore;
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

    public async Task<PlayResponse> PlayGameAgainstComputerAsync(int playerChoiceId, int? playerId)
    {
        var playerChoice = await GetPlayerChoiceAsync(playerChoiceId);
        var computerChoice = await _randomNumberService.FetchRandomNumberAsync();

        var result =
            GameRules.DetermineWinner((ChoiceEnum)playerChoice.Id, (ChoiceEnum)computerChoice);

        if (playerId != null)
        {
            await UpdatePlayerStatisticsAsync(playerId.Value, result);
        }

        return new PlayResponse
        {
            Player = playerChoiceId,
            Computer = computerChoice,
            Results = result
        };
    }

    public async Task<List<PlayerStatisticsModel>> GetTopPlayersAsync(int pageNumber, int pageSize)
    {
        var playerStatistics = await _context.PlayerStatistics
            .OrderByDescending(ps => ps.WinStreak)
            .ThenByDescending(ps => ps.LastPlayedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();

        return playerStatistics.Select(PlayerStatisticsModel.FromDomain).ToList();
    }

    public async Task ResetScoreboardAsync()
    {
        _context.PlayerStatistics.RemoveRange(_context.PlayerStatistics);
        
        await _context.SaveChangesAsync();
    }

    private async Task<Choice> GetPlayerChoiceAsync(int playerChoiceId)
    {
        var playerChoice = await _context.Choices.FindAsync(playerChoiceId);
        if (playerChoice == null)
        {
            throw new ArgumentException($"Invalid choice ID: {playerChoiceId}",
                nameof(playerChoiceId));
        }

        return playerChoice;
    }

    private async Task UpdatePlayerStatisticsAsync(int playerId, string result)
    {
        var playerStatistics = await _context.PlayerStatistics.FindAsync(playerId);
        if (playerStatistics == null)
        {
            playerStatistics = new PlayerStatistics()
            {
                PlayerId = playerId,
                WinStreak = result == "win" ? 1 : 0,
                TotalWins = result == "win" ? 1 : 0,
                TotalLosses = result == "lose" ? 1 : 0,
                TotalTies = result == "tie" ? 1 : 0,
                LastGameResult = result,
                LastPlayedAt = DateTime.UtcNow
            };

            await _context.PlayerStatistics.AddAsync(playerStatistics);
        }
        else
        {
            if (result == "win")
            {
                playerStatistics.WinStreak = playerStatistics.LastGameResult == "win"
                    ? playerStatistics.WinStreak + 1
                    : 1;
                playerStatistics.TotalWins++;
            }
            else if (result == "lose")
            {
                playerStatistics.WinStreak = 0;
                playerStatistics.TotalLosses++;
            }
            else if (result == "tie")
            {
                playerStatistics.TotalTies++;
            }

            playerStatistics.LastGameResult = result;
            playerStatistics.LastPlayedAt = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();
    }
}
