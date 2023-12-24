using FoodDelivery.BL.Dishes;
using FoodDelivery.DataAccess;

namespace FoodDelivery.WebAPI.IoC;

public class ServicesConfigurator
{
    public static void ConfigureService(IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); 
        services.AddScoped<IDishesProvider, DishesProvider>();
        services.AddScoped<IDishesManager, DishesManager>();
    }
}
