using FoodDelivery.BL.Auth;
using FoodDelivery.BL.Dishes;
using FoodDelivery.BL.Users;
using FoodDelivery.DataAccess;
using FoodDelivery.DataAccess.Entities;
using FoodDelivery.WebAPI.Settings;
using Microsoft.AspNetCore.Identity;

namespace FoodDelivery.WebAPI.IoC;

public class ServicesConfigurator
{
    public static void ConfigureService(IServiceCollection services, FoodDeliverySettings settings)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
        services.AddScoped<IDishesProvider, DishesProvider>();
        services.AddScoped<IDishesManager, DishesManager>();

        services.AddScoped<IUsersProvider, UsersProvider>();
        services.AddScoped<IUsersManager, UsersManager>();

        services.AddScoped<IAuthProvider>(x =>
                new AuthProvider(x.GetRequiredService<SignInManager<UserEntity>>(),
                    x.GetRequiredService<UserManager<UserEntity>>(),
                    x.GetRequiredService<IHttpClientFactory>(),
                    settings.IdentityServerUri,
                    settings.ClientId,
                    settings.ClientSecret));
    }
}
