using Microsoft.Extensions.DependencyInjection;
using RPSLSGame.Data;

namespace RPSLSGame.Tests.Integration;

public abstract class IntegrationTest : IClassFixture<RPSLSGameTestFactory>, IDisposable
{
    protected readonly IServiceScope ServiceScope;
    protected readonly GameDbContext DbContext;

    protected IntegrationTest(RPSLSGameTestFactory factory)
    {
        ServiceScope = factory.Services.CreateScope();
        DbContext = ServiceScope.ServiceProvider.GetRequiredService<GameDbContext>();
    }

    public void Dispose()
    {
        ServiceScope?.Dispose();
        DbContext?.Dispose();
    }
}
