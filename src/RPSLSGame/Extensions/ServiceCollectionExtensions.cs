using RPSLSGame.Services;

namespace RPSLSGame.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddRPSLSGameServices(this IServiceCollection services)
    {
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<IChoiceService, ChoiceService>();
    }
}
