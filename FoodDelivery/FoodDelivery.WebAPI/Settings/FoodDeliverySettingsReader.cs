namespace FoodDelivery.WebAPI.Settings
{
    public static class FoodDeliverySettingsReader
    {
        public static FoodDeliverySettings Read(IConfiguration configuration)
        {
            return new FoodDeliverySettings()
            {
                ServiceUri = configuration.GetValue<Uri>("Uri"),
                FoodDeliveryDbContextConnectionString = configuration.GetValue<string>("FoodDeliveryDbContext"),
                IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
                ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
                ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret")
            };
        }
    }
}
