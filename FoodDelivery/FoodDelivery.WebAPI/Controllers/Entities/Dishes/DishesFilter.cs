namespace FoodDelivery.WebAPI.Controllers.Entities.Dishes;

public class DishesFilter
{
    public int? minimumPrice { get; set; }
    public int? maximumPrice { get; set; }
    public int? minimumNumberOfGrams { get; set; }
    public int? maximumNumberOfGrams { get; set; }
}
