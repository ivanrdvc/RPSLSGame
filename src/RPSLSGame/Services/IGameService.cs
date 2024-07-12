using RPSLSGame.Models;

namespace RPSLSGame.Services;

public interface IGameService
{
    /// <summary>
    /// Plays a game round against a computer opponent.
    /// </summary>
    /// <param name="playerChoiceId">The ID of the player's choice.</param>
    /// <param name="playerId">The ID of the player.</param>
    /// <returns>A task that represents the asynchronous operation.
    /// The task result contains a <see cref="PlayResponse"/> object with the game result.</returns>
    /// <exception cref="ArgumentException">Thrown when the playerChoiceId is invalid.</exception>
    Task<PlayResponse> PlayGameAgainstComputerAsync(int playerChoiceId, int? playerId = null);

    /// <summary>
    /// Retrieves the top players based on their win streaks with pagination.
    /// </summary>
    /// <param name="pageNumber">The page number for pagination.</param>
    /// <param name="pageSize">The number of records per page.</param>
    /// <returns>A list of <see cref="PlayerStatisticsModel"/> representing the top players.</returns>
    Task<List<PlayerStatisticsModel>> GetTopPlayersAsync(int pageNumber, int pageSize);

    /// <summary>
    /// Resets the win streaks by clearing the win streak counts but keeps overall statistics.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ResetScoreboardAsync();
}
