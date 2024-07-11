using RPSLSGame.Domain;

namespace RPSLSGame.Data;

public static class DbInitializer
{
    public static async Task InitializeAsync(GameDbContext context)
    {
        if (context.Choices.Any())
        {
            return;
        }

        var timestamp = DateTime.UtcNow;

        var choices = new[]
        {
            new Choice { Id = 1, Name = "Rock", CreatedAt = timestamp },
            new Choice { Id = 2, Name = "Paper", CreatedAt = timestamp },
            new Choice { Id = 3, Name = "Scissors", CreatedAt = timestamp },
            new Choice { Id = 4, Name = "Lizard", CreatedAt = timestamp  },
            new Choice { Id = 5, Name = "Spock", CreatedAt = timestamp  }
        };

        foreach (var c in choices)
        {
            context.Choices.Add(c);
        }

        await context.SaveChangesAsync();
    }
}

