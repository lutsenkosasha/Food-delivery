using Microsoft.EntityFrameworkCore;
using FoodDelivery.DataAccess;

namespace FoodDelivery.WebAPI.IoC
{
    public class DbContextConfigurator
    {
        public static void ConfigureService(IServiceCollection services, Settings.FoodDeliverySettings settings)
        {
            services.AddDbContextFactory<FoodDeliveryDbContext>(
            options => { options.UseSqlServer(settings.FoodDeliveryDbContextConnectionString); },
            ServiceLifetime.Scoped);
        }

        public static void ConfigureApplication(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<FoodDeliveryDbContext>>();
            using var context = contextFactory.CreateDbContext();
            context.Database.Migrate();
        }
    }
}
