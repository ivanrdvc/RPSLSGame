using RPSLSGame.Data;

namespace RPSLSGame.Domain;

public class PlayerStatistics : AuditEntity
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public int WinStreak { get; set; }
    public int TotalWins { get; set; }
    public int TotalLosses { get; set; }
    public int TotalTies { get; set; }
    public string LastGameResult { get; set; } = string.Empty;
    public DateTime LastPlayedAt { get; set; }
}
