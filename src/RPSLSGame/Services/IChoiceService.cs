using RPSLSGame.Models;

namespace RPSLSGame.Services;

public interface IChoiceService
{
    /// <summary>
    /// Asynchronously retrieves all available choices.
    /// </summary>
    /// <returns>
    /// The task result contains a list of <see cref="ChoiceModel"/> representing all available choices.
    /// </returns>
    Task<List<ChoiceModel>> GetChoicesAsync();

    /// <summary>
    /// Asynchronously retrieves a random choice.
    /// </summary>
    /// <returns>
    /// The task result contains a <see cref="ChoiceModel"/> representing the randomly selected choice.
    /// </returns>
    Task<ChoiceModel> GetRandomChoiceAsync();
}
