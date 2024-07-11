using Microsoft.EntityFrameworkCore;
using RPSLSGame.Data.EntityConfigurations;
using RPSLSGame.Domain;

namespace RPSLSGame.Data;

public class GameDbContext : DbContext
{
    public GameDbContext(DbContextOptions<GameDbContext> options) : base(options) { }

    public DbSet<Choice> Choices { get; init; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ChoiceEntityConfiguration());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var timestamp = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is not AuditEntity entity)
            {
                continue;
            }

            if (entry.State == EntityState.Added)
            {
                entity.CreatedAt = timestamp;
            }
            else if (entry.State == EntityState.Modified)
            {
                entity.UpdatedAt = timestamp;

                entry.Property(nameof(AuditEntity.CreatedAt)).IsModified = false;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
