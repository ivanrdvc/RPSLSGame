using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPSLSGame.Domain;

namespace RPSLSGame.Data.EntityConfigurations;

public class PlayerStatisticsEntityConfiguration : AuditEntityConfiguration<PlayerStatistics>
{
    public override void Configure(EntityTypeBuilder<PlayerStatistics> builder)
    {
        // Configure the primary key
        builder.HasKey(p => p.PlayerId);

        // Configure properties
        builder.Property(p => p.PlayerId)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(p => p.WinStreak)
            .IsRequired();

        builder.Property(p => p.TotalWins)
            .IsRequired();

        builder.Property(p => p.TotalLosses)
            .IsRequired();

        builder.Property(p => p.TotalTies)
            .IsRequired();

        builder.Property(p => p.LastGameResult)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.LastPlayedAt)
            .IsRequired();

        builder.HasIndex(p => p.WinStreak);
    }
}
