using RPSLSGame.Models;

namespace RPSLSGame.Services;

public interface IGameService
{
    /// <summary>
    /// Plays a game round against a computer opponent.
    /// </summary>
    /// <param name="playerChoiceId">The ID of the player's choice.</param>
    /// <returns>A task that represents the asynchronous operation.
    /// The task result contains a <see cref="PlayResponse"/> object with the game result.</returns>
    /// <exception cref="ArgumentException">Thrown when the playerChoiceId is invalid.</exception>
    Task<PlayResponse> PlayGameAgainstComputerAsync(int playerChoiceId);
}
