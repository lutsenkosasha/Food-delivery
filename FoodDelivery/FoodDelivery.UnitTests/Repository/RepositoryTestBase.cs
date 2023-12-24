using FoodDelivery.DataAccess;
using FoodDelivery.WebAPI.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicMenu.UnitTests.Repository;

public class RepositoryTestsBase
{
    protected readonly FoodDeliverySettings Settings;
    protected readonly IDbContextFactory<FoodDeliveryDbContext> DbContextFactory;
    protected readonly IServiceProvider ServiceProvider;
    public RepositoryTestsBase()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        Settings = FoodDeliverySettingsReader.Read(configuration);
        ServiceProvider = ConfigureServiceProvider();

        DbContextFactory = ServiceProvider.GetRequiredService<IDbContextFactory<FoodDeliveryDbContext>>();
    }

    private IServiceProvider ConfigureServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContextFactory<FoodDeliveryDbContext>(
            options => { options.UseSqlServer(Settings.FoodDeliveryDbContextConnectionString); },
            ServiceLifetime.Scoped);
        return serviceCollection.BuildServiceProvider();
    }
}