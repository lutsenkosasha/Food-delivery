namespace FoodDelivery.BL.Dishes.Entities;

public class DishesModelFilter
{
    public int? minimumPrice { get; set; }
    public int? maximumPrice { get; set; }
    public int? minimumNumberOfGrams { get; set; }
    public int? maximumNumberOfGrams { get; set; }
}
