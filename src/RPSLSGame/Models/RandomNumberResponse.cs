using System.Text.Json.Serialization;

namespace RPSLSGame.Models;

/// <summary>
/// Represents the response from the random number service.
/// </summary>
public class RandomNumberResponse
{
    /// <summary>
    /// Gets or sets the random number.
    /// </summary>
    [JsonPropertyName("random_number")]
    public int RandomNumber { get; init; }
}
