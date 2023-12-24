namespace FoodDelivery.WebAPI.Settings
{
    public class FoodDeliverySettings
    {
        public Uri ServiceUri { get; set; }
        public string FoodDeliveryDbContextConnectionString { get; set; }
        public string IdentityServerUri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
