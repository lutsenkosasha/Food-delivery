namespace FoodDelivery.WebAPI.Controllers.Entities.Orders;

public class UpdateOrderRequest
{
    public string Adress { get; set; }
    public DateTime DeliveryTime { get; set; }
    public int CostOfTheOrder { get; set; }

    public int UserID { get; set; }
    public int DishInOrderID { get; set; }
}
