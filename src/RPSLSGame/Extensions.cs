using Microsoft.EntityFrameworkCore;
using RPSLSGame.Data;
using RPSLSGame.Services;

namespace RPSLSGame;

public static class Extensions
{
    public static void AddRPSLSGameServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<IChoiceService, ChoiceService>();
        services.AddScoped<IRandomNumberService, RandomNumberService>();

        var connectionString = configuration.GetConnectionString("game_db") ??
                               throw new InvalidOperationException(
                                   "Connection string 'game_db' not found.");

        services.AddDbContext<GameDbContext>(options => options.UseNpgsql(connectionString));
    }

    public static async Task InitializeDatabaseAsync(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        var configuration = services.GetRequiredService<IConfiguration>();
        var seedData = configuration.GetValue<bool>("Database:SeedData");

        if (seedData)
        {
            var dbContext = services.GetRequiredService<GameDbContext>();
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.Database.MigrateAsync();

            await DbInitializer.InitializeAsync(dbContext);
        }
    }
}
