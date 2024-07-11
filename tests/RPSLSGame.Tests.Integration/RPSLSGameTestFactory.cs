using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RPSLSGame.Common;
using RPSLSGame.Data;
using Testcontainers.PostgreSql;

namespace RPSLSGame.Tests.Integration;

public class RPSLSGameTestFactory : WebApplicationFactory<IProgramMarker>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer =
        new PostgreSqlBuilder()
            .WithImage("postgres:latest")
            .WithDatabase("game_test_db")
            .WithUsername("postgres")
            .WithPassword("root")
            .WithCleanUp(true)
            .Build();

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
    }

    public new Task DisposeAsync()
    {
        return _dbContainer.DisposeAsync().AsTask();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var descriptor = services
                .SingleOrDefault(d =>
                    d.ServiceType == typeof(DbContextOptions<GameDbContext>));

            if (descriptor != null) services.Remove(descriptor);

            services.AddDbContextFactory<GameDbContext>(options =>
                options.UseNpgsql(_dbContainer.GetConnectionString()));

            var serviceProvider = services.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<GameDbContext>();
            context.Database.EnsureCreated();
        });
    }
}
