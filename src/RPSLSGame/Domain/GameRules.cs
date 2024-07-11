namespace RPSLSGame.Domain;

public static class GameRules
{
    private static readonly Dictionary<ChoiceEnum, HashSet<ChoiceEnum>> WinningRules = new()
    {
        {
            ChoiceEnum.Rock, [ChoiceEnum.Scissors, ChoiceEnum.Lizard]
        },
        {
            ChoiceEnum.Paper, [ChoiceEnum.Rock, ChoiceEnum.Spock]
        },
        {
            ChoiceEnum.Scissors, [ChoiceEnum.Paper, ChoiceEnum.Lizard]
        },
        {
            ChoiceEnum.Lizard, [ChoiceEnum.Paper, ChoiceEnum.Spock]
        },
        {
            ChoiceEnum.Spock, [ChoiceEnum.Rock, ChoiceEnum.Scissors]
        }
    };

    public static string DetermineWinner(ChoiceEnum playerChoiceId, ChoiceEnum computerChoiceId)
    {
        if (playerChoiceId == computerChoiceId)
            return "tie";

        return WinningRules[playerChoiceId].Contains(computerChoiceId) ? "win" : "lose";
    }
}
