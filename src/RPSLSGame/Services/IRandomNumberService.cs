using RPSLSGame.Models;

namespace RPSLSGame.Services;

public interface IRandomNumberService
{
    /// <summary>
    /// Fetches a random number from an external service and maps it to a choice ID.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.
    /// The task result contains the choice ID, which is a value between 1 and 5.</returns>
    /// <exception cref="Exception">Thrown when the external service returns an invalid response or if there is an issue with the HTTP request.</exception>
    Task<int> FetchRandomNumberAsync();
}
