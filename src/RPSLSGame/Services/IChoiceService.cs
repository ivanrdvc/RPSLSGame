using RPSLSGame.Models;

namespace RPSLSGame.Services;

public interface IChoiceService
{
    List<ChoiceModel> GetChoices();
    ChoiceModel GetRandomChoice();
}
