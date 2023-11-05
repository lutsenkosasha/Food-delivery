namespace FoodDelivery.WebAPI.Settings
{
    public static class FoodDeliverySettingsReader
    {
        public static FoodDeliverySettings Read(IConfiguration configuration)
        {

            return new FoodDeliverySettings();
        }
    }
}
