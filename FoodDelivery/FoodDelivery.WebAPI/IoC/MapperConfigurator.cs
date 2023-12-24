using FoodDelivery.BL.Mapper;
using FoodDelivery.WebAPI.Mapper;

namespace FoodDelivery.WebAPI.IoC;

public static class MapperConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<DishesBLProfile>();
            config.AddProfile<DishesServiceProfile>();
            config.AddProfile<UsersBLProfile>();
            config.AddProfile<UsersServiceProfile>();
        });
    }
}
