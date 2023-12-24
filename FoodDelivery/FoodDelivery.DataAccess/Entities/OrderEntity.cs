using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.DataAccess.Entities;

[Table("orders")]
public class OrderEntity : BaseEntity
{
    public string Adress { get; set; }
    public DateTime DeliveryTime { get; set; }
    public int CostOfTheOrder { get; set; }

    public int UserID { get; set; }
    public UserEntity User { get; set; }

    public int DishInOrderID { get; set; }
    public DishInOrderEntity DishInOrder { get; set; }
}
