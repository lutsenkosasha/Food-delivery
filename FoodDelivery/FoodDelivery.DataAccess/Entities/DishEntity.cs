using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.DataAccess.Entities;

[Table("dishes")]
public class DishEntity : BaseEntity
{
    public string DishName { get; set; }
    public string Description { get; set; }
    public int NumberOfGrams { get; set; }
    public string NutritionalValue { get; set; }
    public int Price { get; set; }

    public int DishInOrderID { get; set; }
    public DishInOrderEntity DishInOrder { get; set; }
}
