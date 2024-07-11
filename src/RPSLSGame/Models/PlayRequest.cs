using System.ComponentModel.DataAnnotations;

namespace RPSLSGame.Models;

public class PlayRequest
{
    /// <summary>
    /// The ID of the player's choice.
    /// </summary>
    [Required(ErrorMessage = "Player choice is required.")]
    [Range(1, 5)]
    public int Player { get; init; }

    /// <summary>
    /// The ID of the player (optional).
    /// </summary>
    public int? PlayerId { get; init; }
}
