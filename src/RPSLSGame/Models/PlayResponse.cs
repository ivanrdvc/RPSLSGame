namespace RPSLSGame.Models;

public class PlayResponse
{
    /// <summary>
    /// The result of the game round.
    /// Possible values are "Win", "Lose", and "Tie".
    /// </summary>
    public string Result { get; init; }

    /// <summary>
    /// The ID of the player's choice.
    /// </summary>
    public int Player { get; init; }

    /// <summary>
    /// The ID of the computer's choice.
    /// </summary>
    public int Computer { get; init; }
}
