using RPSLSGame.Domain;

namespace RPSLSGame.Models;

public class PlayerStatisticsModel
{
    public int PlayerId { get; init; }
    public int WinStreak { get; init; }
    public int TotalWins { get; init; }
    public int TotalLosses { get; init; }
    public int TotalTies { get; init; }
    public string LastGameResult { get; init; } = string.Empty;
    public DateTime LastPlayedAt { get; init; }

    public static PlayerStatisticsModel FromDomain(PlayerStatistics playerStatistics)
    {
        return new PlayerStatisticsModel
        {
            PlayerId = playerStatistics.PlayerId,
            WinStreak = playerStatistics.WinStreak,
            TotalWins = playerStatistics.TotalWins,
            TotalLosses = playerStatistics.TotalLosses,
            TotalTies = playerStatistics.TotalTies,
            LastGameResult = playerStatistics.LastGameResult,
            LastPlayedAt = playerStatistics.LastPlayedAt
        };
    }
}
