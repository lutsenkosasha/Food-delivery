namespace FoodDelivery.WebAPI.Controllers.Entities.Orders;

public class OrdersFilter
{
    public DateTime? minimumDeliveryTime { get; set; }
    public DateTime? maximumDeliveryTime { get; set; }
    public int? minimumCostOfTheOrder { get; set; }
    public int? maximumCostOfTheOrder { get; set; }
}
