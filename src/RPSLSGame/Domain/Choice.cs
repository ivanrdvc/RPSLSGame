using RPSLSGame.Data;

namespace RPSLSGame.Domain;

public class Choice : AuditEntity
{
    public int Id { get; init; }
    public required string Name { get; init; }
}
